using TradingCompany.DAL.Models;

namespace TradingCompany.DAL.Interfaces;

public interface IItemRepository : IRepository<Item>
{
    IEnumerable<Item> Search(string text);
    IEnumerable<Item> GetSortedByName(bool descending = false);
    void Deactivate(int id);
}