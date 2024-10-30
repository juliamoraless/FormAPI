using System.Linq.Expressions;
using Domain.Models;
using Infra.Context;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class FormRepository: Repository<Form>, IFormRepository
{
    public FormRepository(FormContext context) : base(context)
    {
        
    }
    
    public async Task<Form> GetFormByCpf(string cpf)
    {
        return await _context.Forms
            .AsNoTracking()
            .Include(f => f.Attachments)
            .FirstOrDefaultAsync(f => f.Cpf == cpf);
    }

    
}