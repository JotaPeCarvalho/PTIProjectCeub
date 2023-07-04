using Microsoft.EntityFrameworkCore;
using WebProjectPTI.Models;
using WebProjectPTI.Repositorios.Interfaces;
using WebProjectPTI.Helper;

namespace WebProjectPTI.Repositorios
{
    public class AlunoRepositorio : RepositorioBase, IAlunoRepositorio
    {
        private readonly SessionHelper _session = new SessionHelper();
        public async Task<Aluno> CriarAsync(Aluno aluno)
        {
            Professor prof = _session.SearchUserSession();

            aluno.ProfessorId = prof.Id_Professor;

            await _db.Aluno.AddAsync(aluno);
           await _db.SaveChangesAsync();

            return aluno;
        }

        public async Task<List<Aluno>> GetAllAsync()
        {
            Professor prof = _session.SearchUserSession();

            return await _db.Aluno
                      .AsNoTracking()
                      .Where(x => x.ProfessorId == prof.Id_Professor)
                      .ToListAsync();
        }

        public async Task<Aluno> GetByIdAsync(int id)
        {
            return await _db.Aluno
                     .FirstOrDefaultAsync(x => x.Id_Aluno == id);
        }

        public object GetByName(string prefix)
        {
            var alunos = (from aluno in _db.Aluno
                          where aluno.Nome.StartsWith(prefix)
                          select new
                          {
                              label = aluno.Nome,
                              val = aluno.Id_Aluno
                          }).ToList();

            return (alunos);
        }
    }
}
