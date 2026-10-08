using TradingCompany.DAL.Models;

namespace TradingCompany.DAL.Interfaces;

public interface IAuctionRepository : IRepository<Auction>
{
    IEnumerable<Auction> GetActive();
    IEnumerable<Auction> GetFinished();
    void Deactivate(int id);
}