using TradingCompany.DAL.Interfaces;
using TradingCompany.DAL.Models;

namespace TradingCompany.DAL.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(TradingCompanyContext context) : base(context) { }
}