using TradingCompany.DAL.Models;
using TradingCompany.DAL.Repositories;
using Xunit;

namespace TradingCompany.DAL.Tests;

public class ConditionRepositoryTests : TestBase
{
    private ConditionRepository Repo => new(Context);

    [Fact]
    public void GetAll_ReturnsData() => Assert.True(Repo.GetAll().Any());

    [Fact]
    public void Add_And_GetById_Works()
    {
        var c = new Condition { Name = "Тестовий стан" };
        Repo.Add(c);
        Assert.NotNull(Repo.GetById(c.Id));
    }

    [Fact]
    public void Update_ChangesName()
    {
        var c = new Condition { Name = "Стан A" };
        Repo.Add(c);
        c.Name = "Стан B";
        Repo.Update(c);
        Assert.Equal("Стан B", Repo.GetById(c.Id)!.Name);
    }

    [Fact]
    public void Delete_RemovesEntity()
    {
        var c = new Condition { Name = "Видалити" };
        Repo.Add(c);
        Repo.Delete(c.Id);
        Assert.Null(Repo.GetById(c.Id));
    }
}