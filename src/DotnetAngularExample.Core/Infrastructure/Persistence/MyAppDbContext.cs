using DotnetAngularExample.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetAngularExample.Core.Infrastructure.Persistence;

public class MyAppDbContext : DbContext
{
    public MyAppDbContext(DbContextOptions<MyAppDbContext> options)
        :base(options)
    {
        
    }

    public DbSet<Customer> Customers => Set<Customer>();
}