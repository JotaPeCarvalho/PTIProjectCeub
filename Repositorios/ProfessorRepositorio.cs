using WebProjectPTI.Repositorios;
using WebProjectPTI.Models;
using WebProjectPTI.Repositorios.Interfaces;
using WebProjectPTI.Helper;

namespace WebProjectPTI.Repositorios
{
    public class ProfessorRepositorio : RepositorioBase, IProfessorRepositorio
    {
        private readonly SessionHelper _session = new SessionHelper();

        public async Task<Professor> Criar(Professor professor)
        {
            await _db.Professor.AddAsync(professor);
            await _db.SaveChangesAsync();

            return professor;
        }

        public async Task<Professor> GetProfessorLogado()
        {
            return _session.SearchUserSession();
        }
    }
}
