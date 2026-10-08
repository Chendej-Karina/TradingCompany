using TradingCompany.DAL.Models;

namespace TradingCompany.DAL.Interfaces;

public interface IBidRepository : IRepository<Bid>
{
    IEnumerable<Bid> GetByAuction(int auctionId);
}