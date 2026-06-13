namespace _04_05_LojaApi.Models
{
 public class Curso
 {
 public int Id { get; set; }
 public required string Nome { get; set; }
 public int CargaHoraria { get; set; }
 
 public int? ProfessorId { get; set; }
    public Professor? Professor { get; set; }
    }
}