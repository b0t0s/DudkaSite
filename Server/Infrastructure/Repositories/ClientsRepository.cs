using Microsoft.EntityFrameworkCore;
using Site.Server.Application;
using Site.Server.Domain;
using Site.Server.Domain.Entities;

namespace Site.Server.Infrastructure.Repositories;

public class ClientsRepository : IRepository<Customer>
{
    private readonly SiteDbContext _context;

    public ClientsRepository(SiteDbContext context)
    {
        _context = context;
    }

    public Customer GetItem(int id)
    {
        return _context.Clients.Find(id);
    }

    public List<Customer> GetItems()
    {
        return _context.Clients.ToList();
    }

    public void Add(Customer item)
    {
        _context.Clients.Add(item);
        _context.SaveChanges();
    }

    public void Update(Customer item)
    {
        _context.Clients.Update(item);
        _context.SaveChanges();
    }

    public void AddOrUpdate(Customer item)
    {
        var existingProduct = _context.Clients
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
            _context.Clients.Remove(product);
            _context.SaveChanges();
        }
    }
}