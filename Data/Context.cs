using Microsoft.EntityFrameworkCore;
using WebProjectPTI.Helper;
using WebProjectPTI.Models;

namespace WebProjectPTI.Data
{
    public class Context : DbContext
    {

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Aula> Aula { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(Ambiente.DataBaseConnection);


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Aula>()
                .HasOne(a => a.Professor) // Propriedade de navegação para Professor
                .WithMany() // Não há propriedade de coleção em Professor
                .HasForeignKey(a => a.Id_Professor); // Chave estrangeira para Professor

            modelBuilder.Entity<Aula>()
                .HasOne(a => a.Aluno) // Propriedade de navegação para Aluno
                .WithMany() // Não há propriedade de coleção em Aluno
                .HasForeignKey(a => a.Id_Aluno); // Chave estrangeira para Aluno
        }

    }

}
