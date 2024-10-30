using Domain.Models;

namespace Infra.Interfaces;

public interface IFormRepository : IRepository<Form>
{
    Task<Form> GetFormByCpf(string cpf);
}