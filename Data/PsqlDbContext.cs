using EFPostTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EFPostTest.Data;

public class PsqlDbContext : DbContext
{
    public PsqlDbContext(DbContextOptions<PsqlDbContext> options) : base(options) { }
    
    public DbSet<Jacket> JacketsTable { get; set; }
    public DbSet<Collection> CollectionsTable { get; set; }
}