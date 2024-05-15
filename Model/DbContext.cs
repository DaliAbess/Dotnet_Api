using Microsoft.EntityFrameworkCore;
using Api_Dotnet.Model;



namespace Api_Dotnet.Models;

public class DeparementContext : DbContext
{
    public DeparementContext(DbContextOptions<DeparementContext> options)
        : base(options)
    {
    }

    public DbSet<Department> Departments { get; set; } = null!;
}

