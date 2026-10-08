using TradingCompany.DAL.Models;
using TradingCompany.DAL.Repositories;
using Xunit;

namespace TradingCompany.DAL.Tests;

public class ItemRepositoryTests : TestBase
{
    private ItemRepository Repo => new(Context);

    private Item NewItem(string name) => new()
    {
        Name = name,
        Description = "Опис",
        CategoryId = Context.Categories.First().Id,
        ConditionId = Context.Conditions.First().Id,
        IsActive = true
    };

    [Fact]
    public void GetAll_ReturnsData() => Assert.True(Repo.GetAll().Any());

    [Fact]
    public void Add_And_GetById_Works()
    {
        var i = NewItem("Тестовий товар");
        Repo.Add(i);
        Assert.NotNull(Repo.GetById(i.Id));
    }

    [Fact]
    public void Update_ChangesName()
    {
        var i = NewItem("Старий");
        Repo.Add(i);
        i.Name = "Новий";
        Repo.Update(i);
        Assert.Equal("Новий", Repo.GetById(i.Id)!.Name);
    }

    [Fact]
    public void Delete_RemovesEntity()
    {
        var i = NewItem("Видалити");
        Repo.Add(i);
        Repo.Delete(i.Id);
        Assert.Null(Repo.GetById(i.Id));
    }

    [Fact]
    public void Search_FindsByName()
    {
        Repo.Add(NewItem("УнікальнийТовар123"));
        Assert.Single(Repo.Search("УнікальнийТовар123"));
    }

    [Fact]
    public void GetSortedByName_IsSorted()
    {
        var names = Repo.GetSortedByName().Select(i => i.Name).ToList();
        var expected = names.OrderBy(n => n, StringComparer.Ordinal).ToList();
        Assert.Equal(names.Count, expected.Count);
    }

    [Fact]
    public void Deactivate_SetsIsActiveFalse()
    {
        var i = NewItem("Деактивувати");
        Repo.Add(i);
        Repo.Deactivate(i.Id);
        Assert.False(Repo.GetById(i.Id)!.IsActive);
    }
}