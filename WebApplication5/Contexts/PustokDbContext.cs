using Microsoft.EntityFrameworkCore;
using Pustok.Models;

namespace Pustok.Contexts;

public class PustokDbContext:DbContext
{
    public DbSet<Slider> sliders { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-Q9QV65T\\SQLEXPRESS;Database=Pustok;Trusted_Connection=true");
        base.OnConfiguring(optionsBuilder);
    }
}
