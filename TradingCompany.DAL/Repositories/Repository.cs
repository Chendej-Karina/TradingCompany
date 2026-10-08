using Microsoft.EntityFrameworkCore;
using TradingCompany.DAL.Interfaces;
using TradingCompany.DAL.Models;

namespace TradingCompany.DAL.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly TradingCompanyContext _context;
    protected readonly DbSet<T> _set;

    public Repository(TradingCompanyContext context)
    {
        _context = context;
        _set = context.Set<T>();
    }

    public virtual IEnumerable<T> GetAll() => _set.ToList();

    public virtual T? GetById(int id) => _set.Find(id);

    public virtual void Add(T entity)
    {
        _set.Add(entity);
        _context.SaveChanges();
    }

    public virtual void Update(T entity)
    {
        _set.Update(entity);
        _context.SaveChanges();
    }

    public virtual void Delete(int id)
    {
        var entity = _set.Find(id);
        if (entity == null) return;
        _set.Remove(entity);
        _context.SaveChanges();
    }
}