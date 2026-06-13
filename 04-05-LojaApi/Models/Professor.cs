using System.Collections.Generic;
namespace _04_05_LojaApi.Models
{
 public class Professor
 {
 public int Id { get; set; }
 public string Nome { get; set; }
 public List<Curso> Cursos { get; set; } = new List<Curso>();
 }
}
