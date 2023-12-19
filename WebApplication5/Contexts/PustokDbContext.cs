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
    public DbSet<ProductImages> ProductImages { get; set; }
    public DbSet<Setting>Settings { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Setting>().HasData(new Setting
        {
            Address="Baku,Ayna Sultanova st.211",
            Email="leman26@gmail.com",
            Number1="+994558283289",
            Number2="+994509999999",
            Logo="assets/img/logo.png",
            AccountIcon= "<i class='fa fa-user-o'></i>",
            Id = 1
        });
        base.OnModelCreating(modelBuilder);
    }
}