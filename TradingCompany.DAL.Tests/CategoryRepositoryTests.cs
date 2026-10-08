using TradingCompany.DAL.Models;
using TradingCompany.DAL.Repositories;
using Xunit;

namespace TradingCompany.DAL.Tests;

public class CategoryRepositoryTests : TestBase
{
    private CategoryRepository Repo => new(Context);

    [Fact]
    public void GetAll_ReturnsData() => Assert.True(Repo.GetAll().Any());

    [Fact]
    public void Add_And_GetById_Works()
    {
        var c = new Category { Name = "Тестова категорія" };
        Repo.Add(c);
        var found = Repo.GetById(c.Id);
        Assert.NotNull(found);
        Assert.Equal("Тестова категорія", found!.Name);
    }

    [Fact]
    public void Update_ChangesName()
    {
        var c = new Category { Name = "Стара назва" };
        Repo.Add(c);
        c.Name = "Нова назва";
        Repo.Update(c);
        Assert.Equal("Нова назва", Repo.GetById(c.Id)!.Name);
    }

    [Fact]
    public void Delete_RemovesEntity()
    {
        var c = new Category { Name = "Для видалення" };
        Repo.Add(c);
        Repo.Delete(c.Id);
        Assert.Null(Repo.GetById(c.Id));
    }
}