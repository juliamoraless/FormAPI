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
}