using TradingCompany.DAL.Models;
using TradingCompany.DAL.Repositories;
using Xunit;

namespace TradingCompany.DAL.Tests;

public class CurrencyRepositoryTests : TestBase
{
    private CurrencyRepository Repo => new(Context);

    [Fact]
    public void GetAll_ReturnsData() => Assert.True(Repo.GetAll().Any());

    [Fact]
    public void Add_And_GetById_Works()
    {
        var c = new Currency { Code = "TST", Name = "Тестова валюта" };
        Repo.Add(c);
        Assert.NotNull(Repo.GetById(c.Id));
    }

    [Fact]
    public void Update_ChangesName()
    {
        var c = new Currency { Code = "TS2", Name = "Стара" };
        Repo.Add(c);
        c.Name = "Нова";
        Repo.Update(c);
        Assert.Equal("Нова", Repo.GetById(c.Id)!.Name);
    }

    [Fact]
    public void Delete_RemovesEntity()
    {
        var c = new Currency { Code = "TS3", Name = "Видалити" };
        Repo.Add(c);
        Repo.Delete(c.Id);
        Assert.Null(Repo.GetById(c.Id));
    }
}