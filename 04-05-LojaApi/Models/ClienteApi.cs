using System.ComponentModel.DataAnnotations;
namespace _04_05_LojaApi.Models
{
 public class ClienteApi
 {
 [Key]
 public int Codigo { get; set; }
 public string Nome { get; set; }
 public string Email { get; set; }
 public string Telefone { get; set; }
 }
}
