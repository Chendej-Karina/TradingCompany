using TradingCompany.DAL.Interfaces;
using TradingCompany.DAL.Models;

namespace TradingCompany.DAL.Repositories;

public class BidRepository : Repository<Bid>, IBidRepository
{
    public BidRepository(TradingCompanyContext context) : base(context) { }

    public IEnumerable<Bid> GetByAuction(int auctionId)
    {
        return _set.Where(b => b.AuctionId == auctionId).ToList();
    }
}