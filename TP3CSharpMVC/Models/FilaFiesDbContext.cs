using Microsoft.EntityFrameworkCore;
using TP3CSharpMVC.Models;

namespace TP3CSharpMVC.Models
{
    public class FilaFiesDbContext : DbContext
    {
        public FilaFiesDbContext(DbContextOptions<FilaFiesDbContext> options) : base(options)
        {

        }

        public DbSet<AlunoModel> Alunos { get; set; }
        public DbSet<CursoModel> Cursos { get; set; }
        public DbSet<TP3CSharpMVC.Models.ProfessorModel>? ProfessorModel { get; set; }
    }
}
