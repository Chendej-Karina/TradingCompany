using Microsoft.EntityFrameworkCore;
using TradingCompany.DAL.Interfaces;
using TradingCompany.DAL.Models;

namespace TradingCompany.DAL.Repositories;

public class ItemRepository : Repository<Item>, IItemRepository
{
    public ItemRepository(TradingCompanyContext context) : base(context) { }

    public IEnumerable<Item> Search(string text)
    {
        return _set
            .Where(i => i.Name.Contains(text) ||
                        (i.Description != null && i.Description.Contains(text)))
            .ToList();
    }

    public IEnumerable<Item> GetSortedByName(bool descending = false)
    {
        return descending
            ? _set.OrderByDescending(i => i.Name).ToList()
            : _set.OrderBy(i => i.Name).ToList();
    }

    public void Deactivate(int id)
    {
        var item = _set.Find(id);
        if (item == null) return;
        item.IsActive = false;
        _context.SaveChanges();
    }
}