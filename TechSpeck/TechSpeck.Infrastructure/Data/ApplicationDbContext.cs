using Microsoft.EntityFrameworkCore;
using TechSpeck.Domain.Entities;

namespace TechSpeck.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;
} 