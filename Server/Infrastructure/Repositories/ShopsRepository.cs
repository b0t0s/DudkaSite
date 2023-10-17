using Microsoft.EntityFrameworkCore;
using Site.Server.Application;
using Site.Server.Domain;
using Site.Server.Domain.Entities;

namespace Site.Server.Infrastructure.Repositories;

public class ShopsRepository : IRepository<Shop>
{
    private readonly SiteDbContext _context;

    public ShopsRepository(SiteDbContext context)
    {
        _context = context;
    }

    public Shop GetItem(int id)
    {
        return _context.Places.Find(id);
    }

    public List<Shop> GetItems()
    {
        return _context.Places.ToList();
    }

    public void Add(Shop item)
    {
        _context.Places.Add(item);
        _context.SaveChanges();
    }

    public void Update(Shop item)
    {
        _context.Places.Update(item);
        _context.SaveChanges();
    }

    public void AddOrUpdate(Shop item)
    {
        var existingStorage = _context.Places
            .AsNoTracking()
            .FirstOrDefault(p => p.Name == item.Name);

        if (existingStorage != null)
            // Update the entity if it exists
            _context.Entry(existingStorage).CurrentValues.SetValues(item);
        else
            // Add the entity if it doesn't exist
            _context.Places.Add(item);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var storage = GetItem(id);
        if (storage != null)
        {
            _context.Places.Remove(storage);
            _context.SaveChanges();
        }
    }
}