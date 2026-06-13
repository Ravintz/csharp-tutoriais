using Microsoft.EntityFrameworkCore;
using _04_05_LojaApi.Models;
namespace _04_05_LojaApi.Data
{
 public class AppDbContext : DbContext
 {
 public AppDbContext(DbContextOptions<AppDbContext> options)
 : base(options) { }
 
 public DbSet<Produto> Produtos { get; set; }
 public DbSet<ClienteApi> ClientesApi { get; set; }

 public DbSet<ProdutoAtividade> ProdutosAtividade { get; set; }
 public DbSet<Cliente> Clientes { get; set; }
 public DbSet<Curso> Cursos { get; set; }
 public DbSet<ItemEstoque> ItensEstoque { get; set; }
 public DbSet<Professor> Professores { get; set; }
 public DbSet<Pedido> Pedidos { get; set; }
 public DbSet<ItemPedido> ItensPedido { get; set; }
 }
}

