namespace db_relationships_csharp_study.Data;

using Microsoft.EntityFrameworkCore;
using db_relationships_csharp_study.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<Backpack> Backpacks { get; set; }

    public DbSet<Character> Characters { get; set; }

    public DbSet<Weapon> Weapons { get; set; }

    public DbSet<Faction> Factions { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}
