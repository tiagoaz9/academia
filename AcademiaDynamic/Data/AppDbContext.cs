using AcademiaDynamic.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AcademiaDynamic.Data;

public class AppDbContext: IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
    }

    public DbSet<Aula> Aulas { get; set; }
    public DbSet<Plano> Planos { get; set; }
    public DbSet<Product> Products { get; set; }
}