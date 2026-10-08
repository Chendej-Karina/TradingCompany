using TradingCompany.DAL.Models;
using TradingCompany.DAL.Repositories;
using Xunit;

namespace TradingCompany.DAL.Tests;

public class AuctionRepositoryTests : TestBase
{
    private AuctionRepository Repo => new(Context);

    private Auction NewAuction() => new()
    {
        ItemId = Context.Items.First().Id,
        CurrencyId = Context.Currencies.First().Id,
        StartDate = DateTime.Now,
        EndDate = DateTime.Now.AddDays(5),
        StartPrice = 100,
        BuyoutPrice = 500,
        IsActive = true
    };

    [Fact]
    public void GetAll_ReturnsData() => Assert.True(Repo.GetAll().Any());

    [Fact]
    public void Add_And_GetById_Works()
    {
        var a = NewAuction();
        Repo.Add(a);
        Assert.NotNull(Repo.GetById(a.Id));
    }

    [Fact]
    public void Update_ChangesStartPrice()
    {
        var a = NewAuction();
        Repo.Add(a);
        a.StartPrice = 999;
        Repo.Update(a);
        Assert.Equal(999, Repo.GetById(a.Id)!.StartPrice);
    }

    [Fact]
    public void Delete_RemovesEntity()
    {
        var a = NewAuction();
        Repo.Add(a);
        Repo.Delete(a.Id);
        Assert.Null(Repo.GetById(a.Id));
    }

    [Fact]
    public void GetActive_ContainsNewActiveAuction()
    {
        var a = NewAuction();
        Repo.Add(a);
        Assert.Contains(Repo.GetActive(), x => x.Id == a.Id);
    }

    [Fact]
    public void Deactivate_MovesAuctionToFinished()
    {
        var a = NewAuction();
        Repo.Add(a);
        Repo.Deactivate(a.Id);
        Assert.Contains(Repo.GetFinished(), x => x.Id == a.Id);
        Assert.DoesNotContain(Repo.GetActive(), x => x.Id == a.Id);
    }
}