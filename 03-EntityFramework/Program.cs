using System;
using Projeto.Models;
using Projeto.Repositories;

namespace Projeto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var repo = new EstudanteRepository();

            Console.WriteLine("=== INSERINDO ESTUDANTE ===");
            repo.Adicionar(new Estudante { Nome = "Joao Silva", Idade = 22 });
            Console.WriteLine("Estudante inserido com sucesso.\n");

            Console.WriteLine("=== LISTANDO ESTUDANTES ===");
            foreach (var e in repo.Listar())
                Console.WriteLine($"{e.Id} - {e.Nome} - {e.Idade}");

            Console.WriteLine("\n=== BUSCANDO POR ID ===");
            var est = repo.BuscarPorId(1);
            Console.WriteLine(est != null ? $"Encontrado: {est.Nome}" : "Nao encontrado.");

            Console.WriteLine("\n=== ATUALIZANDO ===");
            repo.Atualizar(new Estudante { Id = 1, Nome = "Maria Oliveira", Idade = 25 });

            Console.WriteLine("=== LISTA FINAL ===");
            foreach (var e in repo.Listar())
                Console.WriteLine($"{e.Id} - {e.Nome} - {e.Idade}");
        }
    }
}
