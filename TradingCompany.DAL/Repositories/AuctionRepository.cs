using TradingCompany.DAL.Interfaces;
using TradingCompany.DAL.Models;

namespace TradingCompany.DAL.Repositories;

public class AuctionRepository : Repository<Auction>, IAuctionRepository
{
    public AuctionRepository(TradingCompanyContext context) : base(context) { }

    public IEnumerable<Auction> GetActive()
    {
        var now = DateTime.Now;
        return _set.Where(a => a.IsActive && a.EndDate > now).ToList();
    }

    public IEnumerable<Auction> GetFinished()
    {
        var now = DateTime.Now;
        return _set.Where(a => !a.IsActive || a.EndDate <= now).ToList();
    }

    public void Deactivate(int id)
    {
        var auction = _set.Find(id);
        if (auction == null) return;
        auction.IsActive = false;
        _context.SaveChanges();
    }
}