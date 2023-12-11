using Pustok.Models;
using Microsoft.EntityFrameworkCore;
using Pustok.Models;
using System.Drawing;

namespace Pustok.Contexts;

public class PustokDbContext : DbContext
{
    public PustokDbContext(DbContextOptions opt) : base(opt) { }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}