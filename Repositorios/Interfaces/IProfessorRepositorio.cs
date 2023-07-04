using WebProjectPTI.Models;

namespace WebProjectPTI.Repositorios.Interfaces
{
    public interface IProfessorRepositorio
    {
        Task<Professor> Criar(Professor professor);

        Task<Professor> GetProfessorLogado();
    }
}
