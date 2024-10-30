using Domain.Models;
using Infra.Context;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class AttachmentRepository: Repository<Attachment>, IAttachmentRepository
{
    
    public AttachmentRepository(FormContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Attachment>> GetAttachamentByForm(int formId)
    {
        return await _context.Attachments
            .AsNoTracking()
            .Include(a => a.Form)
            .ThenInclude(f => f.Name)
            .Where(a => a.FormId == formId)
            .ToListAsync();
    }

    
}