using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapping;

public class FormMapping: IEntityTypeConfiguration<Form>
{
    public void Configure(EntityTypeBuilder<Form> builder)
    {
        builder.HasKey(f => f.Id); 

        builder.Property(f => f.Name) 
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(200);

        builder.Property(f => f.Cpf)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(11);
						
        //relação 1 : N / Form : Attachments
        builder.HasMany(f => f.Attachments)
            .WithOne(a => a.Form)
            .HasForeignKey(a => a.FormId);
    }
}