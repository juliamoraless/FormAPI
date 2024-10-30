using Domain.Models;

namespace Infra.Interfaces;

public interface IAttachmentRepository : IRepository<Attachment>
{
    Task<IEnumerable<Attachment>> GetAttachamentByForm(int formId);
}