using TradingCompany.DAL.Models;
using TradingCompany.DAL.Repositories;
using Xunit;

namespace TradingCompany.DAL.Tests;

public class BidRepositoryTests : TestBase
{
    private BidRepository Repo => new(Context);

    private Bid NewBid() => new()
    {
        AuctionId = Context.Auctions.First().Id,
        Amount = 777,
        BidDate = DateTime.Now
    };

    [Fact]
    public void GetAll_ReturnsData() => Assert.True(Repo.GetAll().Any());

    [Fact]
    public void Add_And_GetById_Works()
    {
        var b = NewBid();
        Repo.Add(b);
        Assert.NotNull(Repo.GetById(b.Id));
    }

    [Fact]
    public void Update_ChangesAmount()
    {
        var b = NewBid();
        Repo.Add(b);
        b.Amount = 888;
        Repo.Update(b);
        Assert.Equal(888, Repo.GetById(b.Id)!.Amount);
    }

    [Fact]
    public void Delete_RemovesEntity()
    {
        var b = NewBid();
        Repo.Add(b);
        Repo.Delete(b.Id);
        Assert.Null(Repo.GetById(b.Id));
    }

    [Fact]
    public void GetByAuction_ReturnsBidsOfAuction()
    {
        var b = NewBid();
        Repo.Add(b);
        Assert.Contains(Repo.GetByAuction(b.AuctionId), x => x.Id == b.Id);
    }
}