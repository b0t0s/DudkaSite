using Microsoft.EntityFrameworkCore;
using Site.Server.Application;
using Site.Server.Domain;
using Site.Server.Domain.Entities;

namespace Site.Server.Infrastructure.Repositories;

public class OrdersRepository : IRepository<Order>
{
    private readonly SiteDbContext _context;

    public OrdersRepository(SiteDbContext context)
    {
        _context = context;
    }

    public Order GetItem(int id)
    {
        return _context.Orders.Find(id);
    }

    public List<Order> GetItems()
    {
        return _context.Orders.ToList();
    }

    public void Add(Order item)
    {
        _context.Orders.Add(item);
        _context.SaveChanges();
    }

    public void Update(Order item)
    {
        _context.Orders.Update(item);
        _context.SaveChanges();
    }

    public void AddOrUpdate(Order item)
    {
        var existingProduct = _context.Orders
            .AsNoTracking()
            .FirstOrDefault(p => p.Id == item.Id);

        if (existingProduct != null)
            _context.Entry(item).State = EntityState.Modified;
        else
            _context.Entry(item).State = EntityState.Added;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var product = GetItem(id);
        if (product != null)
        {
            _context.Orders.Remove(product);
            _context.SaveChanges();
        }
    }
}