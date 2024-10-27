using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context;

public class FormContext : DbContext
{
    public FormContext(DbContextOptions<FormContext> options) : base(options)
    {
        
    }

    public DbSet<Form> Forms { get; set; }
    public DbSet<Attachment> Attachments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(e => e.GetProperties()
                         .Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(100)");
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FormContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}