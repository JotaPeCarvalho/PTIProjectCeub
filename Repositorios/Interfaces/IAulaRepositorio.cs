using WebProjectPTI.Infra.Enum;
using WebProjectPTI.Models;

namespace WebProjectPTI.Repositorios.Interfaces
{
    public interface IAulaRepositorio
    {
        Task<List<Aula>> RetornaAulasProximas();

        Task<Aula> Add(Aula aula);

        Task<Aula> GetById(int id);

        Task<DiaAulaEnum> GetDiaDaSemana();

        Task<bool> Delete(int id);
    }
}
