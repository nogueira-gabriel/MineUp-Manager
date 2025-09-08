using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

List<Jogo> jogos = new List<Jogo>();
List<Periferico> perifericos = new List<Periferico>();
List<Venda> vendas = new List<Venda>();

public struct Jogo
{
    public string Nome;
    public string Genero;
    public int Quantidade;
    public double Preco;

    public override string ToString()
    {
        return $"Nome: {Nome}, Gênero: {Genero}, Quantidade: {Quantidade}, Preço: {Preco:C}";
    }

    public void cadastrarNomeJogo()
    {
        string? read;
        do{
            Console.WriteLine("Digite o nome:");
            read = Console.ReadLine();
            if(read != null){
                Nome = read;
                break;
            }
        }while(true);
    }

    public void cadastrarGeneroJogo(){
        string? read;
        do{
            Console.WriteLine("Digite o genero:");
            read = Console.ReadLine();
        }while(read==null);
    }

    public void cadastrarQuantidadeJogo(){
        string? read;
        do{
            Console.WriteLine("Digite a quantidade:");
            read = Console.ReadLine();
        }while(read==null);
    }

    public void cadastrarPrecoJogo(){
        string? read;
        bool erro = false;
        do{
            Console.WriteLine("Digite o preço:");
            read = Console.ReadLine();
            while(!double.TryParse(read, out Preco)){
                Console.WriteLine("Erro! Digite um número");
                erro = true;

            }
        }while(read==null && (erro == true));
    }

    public void cadastrarJogo(List<Jogo> jogos){
        cadastrarNomeJogo();
        cadastrarGeneroJogo();
        cadastrarQuantidadeJogo();
        cadastrarPrecoJogo();

        Jogo jogo = new Jogo();

        jogos.Add(jogo);
    }
}

public struct Periferico
{
    public string Nome;
    public string Tipo;
    public int Quantidade;
    public double Preco;

    public override string ToString()
    {
        return $"Nome: {Nome}, Tipo: {Tipo}, Quantidade: {Quantidade}, Preço: {Preco:C}";
    }
}

public struct Venda
{
    public string Produto;
    public int Quantidade;
    public double PrecoUnitario;

    public override string ToString()
    {
        return $"Produto: {Produto}, Quantidade: {Quantidade}, Preço Unitário: {PrecoUnitario:C}";
    }

}

static void SalvarJogos()
{
    try
    {
        using (StreamWriter writer = new StreamWriter("jogos.txt"))
        {
            foreach (var jogo in jogos)
            {
                writer.WriteLine($"{jogo.Nome},{jogo.Genero},{jogo.Quantidade},{jogo.Preco}");
            }
        }
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Erro ao salvar jogos: {ex.Message}");
        Console.ResetColor();
    }
}

static void CarregarJogos()
{
    if (File.Exists("jogos.txt"))
    {
        try
        {
            jogos.Clear();
            foreach (var line in File.ReadAllLines("jogos.txt"))
            {
                var parts = line.Split(',');
                if (parts.Length == 4)
                {
                    jogos.Add(new Jogo
                    {
                        Nome = parts[0],
                        Genero = parts[1],
                        Quantidade = int.Parse(parts[2]),
                        Preco = double.Parse(parts[3])
                    });
                }
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Erro ao carregar jogos: {ex.Message}");
            Console.ResetColor();
        }
    }
}

static void SalvarPerifericos()
{
    try
    {
        using (StreamWriter writer = new StreamWriter("perifericos.txt"))
        {
            foreach (var periferico in perifericos)
            {
                writer.WriteLine($"{periferico.Nome},{periferico.Tipo},{periferico.Quantidade},{periferico.Preco}");
            }
        }
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Erro ao salvar periféricos: {ex.Message}");
        Console.ResetColor();
    }
}

static void CarregarPerifericos()
{
    if (File.Exists("perifericos.txt"))
    {
        try
        {
            perifericos.Clear();
            foreach (var line in File.ReadAllLines("perifericos.txt"))
            {
                var parts = line.Split(',');
                if (parts.Length == 4)
                {
                    perifericos.Add(new Periferico
                    {
                        Nome = parts[0],
                        Tipo = parts[1],
                        Quantidade = int.Parse(parts[2]),
                        Preco = double.Parse(parts[3])
                    });
                }
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Erro ao carregar periféricos: {ex.Message}");
            Console.ResetColor();
        }
    }
}

static void SalvarVendas()
{
    try
    {
        using (StreamWriter writer = new StreamWriter("vendas.txt"))
        {
            foreach (var venda in vendas)
            {
                writer.WriteLine($"{venda.Produto},{venda.Quantidade},{venda.PrecoUnitario}");
            }
        }
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Erro ao salvar vendas: {ex.Message}");
        Console.ResetColor();
    }
}

static void CarregarVendas()
{
    if (File.Exists("vendas.txt"))
    {
        try
        {
            vendas.Clear();
            foreach (var line in File.ReadAllLines("vendas.txt"))
            {
                var parts = line.Split(',');
                if (parts.Length == 3)
                {
                    vendas.Add(new Venda
                    {
                        Produto = parts[0],
                        Quantidade = int.Parse(parts[1]),
                        PrecoUnitario = double.Parse(parts[2])
                    });
                }
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Erro ao carregar vendas: {ex.Message}");
            Console.ResetColor();
        }
    }
}

