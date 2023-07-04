using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using WebProjectPTI.Infra.Enum;
using WebProjectPTI.Models;
using WebProjectPTI.Repositorios.Interfaces;

namespace WebProjectPTI.Repositorios
{
    public class AulaRepositorio : RepositorioBase, IAulaRepositorio
    {
        public async Task<List<Aula>> RetornaAulasProximas()
        {
            DateTime dataAtual = DateTime.Now;
            DateTime dataFutura = DateTime.Now.AddDays(5);

            return await _db.Aula.Where(x => x.DataMesAula > dataAtual && x.DataMesAula < dataFutura)
                           .OrderBy(x => x.DataMesAula)
                           .Include(x => x.Aluno)
                           .ToListAsync();
        }

        public async Task<Aula> Add(Aula aula)
        {
           await _db.Aula.AddAsync(aula);
           await _db.SaveChangesAsync();

            return aula;
        }

        public async Task<DiaAulaEnum> GetDiaDaSemana()
        {
            return DiaAulaEnum.Quinta;
        }

        public async Task<Aula> GetById(int id)
        {
            return await _db.Aula.Where(x => x.Id_Aula == id)
                                 .Include(x => x.Aluno)
                                 .Include(x => x.Professor)
                                 .FirstOrDefaultAsync();
        }

        public async Task<bool> Delete(int id)
        {
            Aula aulaById = await GetById(id);

            _db.Aula.Remove(aulaById);
            await _db.SaveChangesAsync();

            return true;

        }
    }
}
