using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Estudante> Estudantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = "server=localhost;port=3306;database=escola;user=root;password=Louis2610!";
            optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));
        }
    }
}
