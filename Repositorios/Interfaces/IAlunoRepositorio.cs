using WebProjectPTI.Models;

namespace WebProjectPTI.Repositorios.Interfaces
{
    public interface IAlunoRepositorio
    {
        Task<Aluno> GetByIdAsync(int id);
        Task<List<Aluno>> GetAllAsync();
        Task<Aluno> CriarAsync(Aluno aluno);

        object GetByName(string prefix);
    }
}
