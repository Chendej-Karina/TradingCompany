using TradingCompany.DAL.Interfaces;
using TradingCompany.DAL.Models;

namespace TradingCompany.DAL.Repositories;

public class ConditionRepository : Repository<Condition>, IConditionRepository
{
    public ConditionRepository(TradingCompanyContext context) : base(context) { }
}