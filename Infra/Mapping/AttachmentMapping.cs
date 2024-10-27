using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapping;

public class AttachmentMapping: IEntityTypeConfiguration<Attachment>
{
    public void Configure(EntityTypeBuilder<Attachment> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.Form)
            .WithMany(f => f.Attachments)
            .HasForeignKey(a => a.FormId);
    }
}