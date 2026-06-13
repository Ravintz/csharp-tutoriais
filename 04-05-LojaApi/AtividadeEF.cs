using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using _04_05_LojaApi.Data;
using _04_05_LojaApi.Models;

public static class AtividadesEF
{
    public static void Executar(AppDbContext context)
    {
        Atividade1_Produto(context);
        Atividade2_Cliente(context);
        Atividade3_Curso(context);
        Atividade4_Estoque(context);
        Atividade5_ProfessorCursos(context);
        Atividade6_PedidoItens(context);
        Console.WriteLine("\n=== Todas as atividades executadas ===");
    }

    static void Atividade1_Produto(AppDbContext context)
    {
        Console.WriteLine("\n===== ATIVIDADE 1: Produto (CRUD) =====");
        context.ProdutosAtividade.AddRange(
            new ProdutoAtividade { Nome = "Caneta",  Preco = 2.50 },
            new ProdutoAtividade { Nome = "Caderno", Preco = 15.90 },
            new ProdutoAtividade { Nome = "Mochila", Preco = 120.00 }
        );
        context.SaveChanges();

        Console.WriteLine("Produtos cadastrados:");
        foreach (var prod in context.ProdutosAtividade.ToList())
            Console.WriteLine($"  {prod.Id} - {prod.Nome} - R$ {prod.Preco}");

        var primeiro = context.ProdutosAtividade.First();
        primeiro.Preco = 3.00;
        context.SaveChanges();
        Console.WriteLine($"Atualizado: {primeiro.Nome} agora R$ {primeiro.Preco}");

        double minimo = 10.0;
        Console.WriteLine($"Produtos acima de R$ {minimo}:");
        foreach (var prod in context.ProdutosAtividade.Where(p => p.Preco > minimo).ToList())
            Console.WriteLine($"  {prod.Nome} - R$ {prod.Preco}");
    }

    static void Atividade2_Cliente(AppDbContext context)
    {
        Console.WriteLine("\n===== ATIVIDADE 2: Cliente =====");
        AdicionarCliente(context, "Ana",   "ana@email.com");
        AdicionarCliente(context, "Bruno", "email-invalido");

        Console.WriteLine("Clientes cadastrados:");
        foreach (var cli in context.Clientes.ToList())
            Console.WriteLine($"  {cli.Id} - {cli.Nome} - {cli.Email}");

        var busca = context.Clientes.FirstOrDefault(c => c.Email == "ana@email.com");
        Console.WriteLine(busca != null
            ? $"Encontrado por email: {busca.Nome}"
            : "Cliente nao encontrado.");
    }

    static void AdicionarCliente(AppDbContext context, string nome, string email)
    {
        if (!email.Contains("@") || !email.Contains("."))
        {
            Console.WriteLine($"  Email invalido para {nome}: '{email}' (nao salvo)");
            return;
        }
        context.Clientes.Add(new Cliente { Nome = nome, Email = email });
        context.SaveChanges();
        Console.WriteLine($"  Cliente {nome} salvo.");
    }

    static void Atividade3_Curso(AppDbContext context)
    {
        Console.WriteLine("\n===== ATIVIDADE 3: Cursos =====");
        context.Cursos.AddRange(
            new Curso { Nome = "Logica",         CargaHoraria = 40 },
            new Curso { Nome = "Banco de Dados", CargaHoraria = 60 },
            new Curso { Nome = "C#",             CargaHoraria = 80 },
            new Curso { Nome = "Algoritmos",     CargaHoraria = 30 },
            new Curso { Nome = "Web",            CargaHoraria = 50 }
        );
        context.SaveChanges();

        Console.WriteLine("Cursos com carga >= 50h:");
        foreach (var c in context.Cursos.Where(c => c.CargaHoraria >= 50).ToList())
            Console.WriteLine($"  {c.Nome} ({c.CargaHoraria}h)");

        Console.WriteLine("Cursos ordenados por nome:");
        foreach (var c in context.Cursos.OrderBy(c => c.Nome).ToList())
            Console.WriteLine($"  {c.Nome}");
    }

    static void Atividade4_Estoque(AppDbContext context)
    {
        Console.WriteLine("\n===== ATIVIDADE 4: Estoque =====");
        context.ItensEstoque.AddRange(
            new ItemEstoque { Nome = "Teclado", Quantidade = 10 },
            new ItemEstoque { Nome = "Monitor", Quantidade = 3 }
        );
        context.SaveChanges();

        BaixarEstoque(context, "Teclado", 4);
        BaixarEstoque(context, "Monitor", 5);

        Console.WriteLine("Itens com estoque baixo (< 5):");
        foreach (var item in context.ItensEstoque.Where(i => i.Quantidade < 5).ToList())
            Console.WriteLine($"  {item.Nome}: {item.Quantidade}");
    }

    static void BaixarEstoque(AppDbContext context, string nome, int qtd)
    {
        var item = context.ItensEstoque.FirstOrDefault(i => i.Nome == nome);
        if (item == null) { Console.WriteLine($"  {nome} nao existe."); return; }

        if (item.Quantidade - qtd < 0)
        {
            Console.WriteLine($"  Baixa de {qtd} em {nome} negada (estoque ficaria negativo).");
            return;
        }
        item.Quantidade -= qtd;
        context.SaveChanges();
        Console.WriteLine($"  {nome}: baixa de {qtd}, restam {item.Quantidade}.");
    }

    static void Atividade5_ProfessorCursos(AppDbContext context)
    {
        Console.WriteLine("\n===== ATIVIDADE 5: Professor e Cursos (1:N) =====");
        var professor = new Professor
        {
            Nome = "Carlos Silva",
            Cursos = new List<Curso>
            {
                new Curso { Nome = "C# Basico",        CargaHoraria = 40 },
                new Curso { Nome = "Entity Framework", CargaHoraria = 30 }
            }
        };
        context.Professores.Add(professor);
        context.SaveChanges();

        var professores = context.Professores
            .Include(prof => prof.Cursos)
            .ToList();

        foreach (var prof in professores)
        {
            Console.WriteLine($"Professor: {prof.Nome}");
            foreach (var curso in prof.Cursos)
                Console.WriteLine($"  - {curso.Nome} ({curso.CargaHoraria}h)");
        }
    }

    static void Atividade6_PedidoItens(AppDbContext context)
    {
        Console.WriteLine("\n===== ATIVIDADE 6: Pedido e Itens (1:N) =====");

        var pedido = new Pedido
        {
            Data = DateTime.Now,
            Itens = new List<ItemPedido> { new ItemPedido { Produto = "Notebook", Quantidade = 1 }, new ItemPedido { Produto = "Mouse", Quantidade = 2 } }
        };

        context.Pedidos.Add(pedido);
        context.SaveChanges();

        var pedidos = context.Pedidos
            .Include(ped => ped.Itens)
            .ToList();

        foreach (var ped in pedidos)
        {
            Console.WriteLine($"Pedido {ped.Id} - {ped.Data:dd/MM/yyyy HH:mm}");
            foreach (var item in ped.Itens)
                Console.WriteLine($"  {item.Produto} x{item.Quantidade}");

            int total = ped.Itens.Sum(i => i.Quantidade);
            Console.WriteLine($"  Total de itens no pedido: {total}");
        }
    }
}