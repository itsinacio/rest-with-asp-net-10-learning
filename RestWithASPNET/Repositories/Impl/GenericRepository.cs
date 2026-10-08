using Microsoft.EntityFrameworkCore;
using RestWithASPNET.Model.Base;
using RestWithASPNET.Model.Context;

namespace RestWithASPNET.Repositories.Impl;

public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
    private MSSQLContext _context;
    private DbSet<T> _dataset;
    public GenericRepository(MSSQLContext context)
    {
        _context = context;
        _dataset = context.Set<T>();
    }
    public T Create(T item)
    {
        _dataset.Add(item);
        _context.SaveChanges();
        return item;
    }
    public T FindById(long id)
    {
        return _dataset.Find(id);
    }
    public List<T> FindAll()
    {
        return _dataset.ToList();
    }
    public T Update(T item)
    {
        var existingItem = _dataset.Find(item.Id);
        if (existingItem == null) return null;
        _context.Entry(existingItem).CurrentValues.SetValues(item);
        _context.SaveChanges();
        return item;
    }
    public void Delete(long id)
    {
        var existingItem = _dataset.Find(id);
        if(existingItem == null) return ;
        _dataset.Remove(existingItem);
        _context.SaveChanges();
    }
    public bool Existis(long id)
    {
        return _dataset.Any(x => x.Id == id);
    }
}
