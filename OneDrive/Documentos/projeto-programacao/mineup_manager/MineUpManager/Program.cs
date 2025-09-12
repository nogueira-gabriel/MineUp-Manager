using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MineUpManager
{

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
        public DateTime DataVenda;

        public override string ToString()
        {
            return $"Produto: {Produto}, Quantidade: {Quantidade}, Preço Unitário: {PrecoUnitario:C}, Data: {DataVenda:dd/MM/yyyy HH:mm}";
        }
    }

    class Program
    {
        
        static List<Jogo> jogos = new List<Jogo>();
        static List<Periferico> perifericos = new List<Periferico>();
        static List<Venda> vendas = new List<Venda>();

        static void SalvarJogos()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("jogos.txt"))
                {
                    foreach (var jogo in jogos)
                    {
                        writer.WriteLine($"{jogo.Nome}|{jogo.Genero}|{jogo.Quantidade}|{jogo.Preco}");
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
                    string[] linhas = File.ReadAllLines("jogos.txt");
                    
                    foreach (string linha in linhas)
                    {
                        if (!string.IsNullOrWhiteSpace(linha))
                        {
                            string[] dados = linha.Split('|');
                            if (dados.Length == 4)
                            {
                                Jogo novoJogo = new Jogo
                                {
                                    Nome = dados[0],
                                    Genero = dados[1],
                                    Quantidade = int.Parse(dados[2]),
                                    Preco = double.Parse(dados[3])
                                };
                                jogos.Add(novoJogo);
                            }
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
                        writer.WriteLine($"{periferico.Nome}|{periferico.Tipo}|{periferico.Quantidade}|{periferico.Preco}");
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
                    string[] linhas = File.ReadAllLines("perifericos.txt");
                    
                    foreach (string linha in linhas)
                    {
                        if (!string.IsNullOrWhiteSpace(linha))
                        {
                            string[] dados = linha.Split('|');
                            if (dados.Length == 4)
                            {
                                Periferico novoPeriferico = new Periferico
                                {
                                    Nome = dados[0],
                                    Tipo = dados[1],
                                    Quantidade = int.Parse(dados[2]),
                                    Preco = double.Parse(dados[3])
                                };
                                perifericos.Add(novoPeriferico);
                            }
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
                        writer.WriteLine($"{venda.Produto}|{venda.Quantidade}|{venda.PrecoUnitario}|{venda.DataVenda:yyyy-MM-dd HH:mm:ss}");
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
                    string[] linhas = File.ReadAllLines("vendas.txt");
                    
                    foreach (string linha in linhas)
                    {
                        if (!string.IsNullOrWhiteSpace(linha))
                        {
                            string[] dados = linha.Split('|');
                            if (dados.Length == 4)
                            {
                                Venda novaVenda = new Venda
                                {
                                    Produto = dados[0],
                                    Quantidade = int.Parse(dados[1]),
                                    PrecoUnitario = double.Parse(dados[2]),
                                    DataVenda = DateTime.Parse(dados[3])
                                };
                                vendas.Add(novaVenda);
                            }
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

        static bool ValidarTexto(string texto, string nomeCampo)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Erro: {nomeCampo} não pode estar vazio!");
                Console.ResetColor();
                return false;
            }
            return true;
        }

        static bool ValidarNumeroPositivo(int numero, string nomeCampo)
        {
            if (numero < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Erro: {nomeCampo} deve ser um número positivo!");
                Console.ResetColor();
                return false;
            }
            return true;
        }

        static bool ValidarPrecoPositivo(double preco)
        {
            if (preco <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: Preço deve ser um valor positivo!");
                Console.ResetColor();
                return false;
            }
            return true;
        }

        static void CadastrarJogo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║          CADASTRAR JOGO           ║");
            Console.WriteLine("╚═══════════════════════════════════╝");
            Console.ResetColor();

            try
            {
                Console.Write("\nDigite o nome do jogo: ");
                string nome = Console.ReadLine();
                if (!ValidarTexto(nome, "Nome do jogo")) return;

                // Verificar se já existe um jogo com esse nome
                if (jogos.Any(j => j.Nome.ToLower() == nome.ToLower()))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Aviso: Já existe um jogo com esse nome!");
                    Console.ResetColor();
                }

                Console.Write("Digite o gênero do jogo: ");
                string genero = Console.ReadLine();
                if (!ValidarTexto(genero, "Gênero")) return;

                Console.Write("Digite a quantidade em estoque: ");
                if (!int.TryParse(Console.ReadLine(), out int quantidade))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Erro: Quantidade deve ser um número válido!");
                    Console.ResetColor();
                    return;
                }
                if (!ValidarNumeroPositivo(quantidade, "Quantidade")) return;

                Console.Write("Digite o preço (R$): ");
                if (!double.TryParse(Console.ReadLine(), out double preco))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Erro: Preço deve ser um número válido!");
                    Console.ResetColor();
                    return;
                }
                if (!ValidarPrecoPositivo(preco)) return;

                Jogo novoJogo = new Jogo
                {
                    Nome = nome,
                    Genero = genero,
                    Quantidade = quantidade,
                    Preco = preco
                };

                jogos.Add(novoJogo);
                SalvarJogos();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n✓ Jogo cadastrado com sucesso!");
                Console.WriteLine($"Detalhes: {novoJogo}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                Console.ResetColor();
            }
        }

        static void CadastrarPeriferico()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║       CADASTRAR PERIFÉRICO       ║");
            Console.WriteLine("╚═══════════════════════════════════╝");
            Console.ResetColor();

            try
            {
                Console.Write("\nDigite o nome do periférico: ");
                string nome = Console.ReadLine();
                if (!ValidarTexto(nome, "Nome do periférico")) return;

                // Verificar se já existe um periférico com esse nome
                if (perifericos.Any(p => p.Nome.ToLower() == nome.ToLower()))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Aviso: Já existe um periférico com esse nome!");
                    Console.ResetColor();
                }

                Console.Write("Digite o tipo do periférico (Mouse, Teclado, Headset, etc.): ");
                string tipo = Console.ReadLine();
                if (!ValidarTexto(tipo, "Tipo")) return;

                Console.Write("Digite a quantidade em estoque: ");
                if (!int.TryParse(Console.ReadLine(), out int quantidade))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Erro: Quantidade deve ser um número válido!");
                    Console.ResetColor();
                    return;
                }
                if (!ValidarNumeroPositivo(quantidade, "Quantidade")) return;

                Console.Write("Digite o preço (R$): ");
                if (!double.TryParse(Console.ReadLine(), out double preco))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Erro: Preço deve ser um número válido!");
                    Console.ResetColor();
                    return;
                }
                if (!ValidarPrecoPositivo(preco)) return;

                Periferico novoPeriferico = new Periferico
                {
                    Nome = nome,
                    Tipo = tipo,
                    Quantidade = quantidade,
                    Preco = preco
                };

                perifericos.Add(novoPeriferico);
                SalvarPerifericos();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n✓ Periférico cadastrado com sucesso!");
                Console.WriteLine($"Detalhes: {novoPeriferico}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                Console.ResetColor();
            }
        }

        static void ConsultarProduto()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║        CONSULTAR PRODUTO         ║");
            Console.WriteLine("╚═══════════════════════════════════╝");
            Console.ResetColor();

            Console.Write("\nDigite o nome do produto (ou parte dele): ");
            string termoPesquisa = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(termoPesquisa))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: Digite um termo para pesquisar!");
                Console.ResetColor();
                return;
            }

            bool encontrouAlgum = false;

            // Buscar jogos
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n--- JOGOS ENCONTRADOS ---");
            Console.ResetColor();

            foreach (var jogo in jogos)
            {
                if (jogo.Nome.ToLower().Contains(termoPesquisa.ToLower()) || 
                    jogo.Genero.ToLower().Contains(termoPesquisa.ToLower()))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"🎮 {jogo}");
                    Console.ResetColor();
                    encontrouAlgum = true;
                }
            }

            // Buscar periféricos
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n--- PERIFÉRICOS ENCONTRADOS ---");
            Console.ResetColor();

            foreach (var periferico in perifericos)
            {
                if (periferico.Nome.ToLower().Contains(termoPesquisa.ToLower()) || 
                    periferico.Tipo.ToLower().Contains(termoPesquisa.ToLower()))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"🖱️ {periferico}");
                    Console.ResetColor();
                    encontrouAlgum = true;
                }
            }

            if (!encontrouAlgum)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Nenhum produto encontrado com esse termo!");
                Console.ResetColor();
            }
        }
        static void ExcluirProduto()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║         EXCLUIR PRODUTO          ║");
            Console.WriteLine("╚═══════════════════════════════════╝");
            Console.ResetColor();

            Console.Write("\nDigite o nome exato do produto: ");
            string nome = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: Digite o nome do produto!");
                Console.ResetColor();
                return;
            }

            bool produtoEncontrado = false;

            // Procurar jogo
            for (int i = 0; i < jogos.Count; i++)
            {
                if (jogos[i].Nome.ToLower() == nome.ToLower())
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nJogo encontrado: {jogos[i]}");
                    Console.ResetColor();
                    
                    Console.Write("Tem certeza que deseja excluir? (s/n): ");
                    string confirmacao = Console.ReadLine();
                    
                    if (confirmacao.ToLower() == "s" || confirmacao.ToLower() == "sim")
                    {
                        jogos.RemoveAt(i);
                        SalvarJogos();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("✓ Jogo excluído com sucesso!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Operação cancelada.");
                        Console.ResetColor();
                    }
                    produtoEncontrado = true;
                    break;
                }
            }

            // Procurar periférico se não encontrou jogo
            if (!produtoEncontrado)
            {
                for (int i = 0; i < perifericos.Count; i++)
                {
                    if (perifericos[i].Nome.ToLower() == nome.ToLower())
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\nPeriférico encontrado: {perifericos[i]}");
                        Console.ResetColor();
                        
                        Console.Write("Tem certeza que deseja excluir? (s/n): ");
                        string confirmacao = Console.ReadLine();
                        
                        if (confirmacao.ToLower() == "s" || confirmacao.ToLower() == "sim")
                        {
                            perifericos.RemoveAt(i);
                            SalvarPerifericos();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("✓ Periférico excluído com sucesso!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Operação cancelada.");
                            Console.ResetColor();
                        }
                        produtoEncontrado = true;
                        break;
                    }
                }
            }

            if (!produtoEncontrado)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Produto não encontrado!");
                Console.ResetColor();
            }
        }

        static void RealizarVenda()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║         REALIZAR VENDA           ║");
            Console.WriteLine("╚═══════════════════════════════════╝");
            Console.ResetColor();

            try
            {
                Console.Write("\nDigite o nome do produto: ");
                string nomeProduto = Console.ReadLine();
                if (!ValidarTexto(nomeProduto, "Nome do produto")) return;

                Console.Write("Digite a quantidade: ");
                if (!int.TryParse(Console.ReadLine(), out int quantidadeVenda))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Erro: Quantidade deve ser um número válido!");
                    Console.ResetColor();
                    return;
                }

                if (quantidadeVenda <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Erro: Quantidade deve ser maior que zero!");
                    Console.ResetColor();
                    return;
                }

                bool vendaRealizada = false;

                // Procurar jogo
                for (int i = 0; i < jogos.Count; i++)
                {
                    if (jogos[i].Nome.ToLower() == nomeProduto.ToLower())
                    {
                        if (jogos[i].Quantidade >= quantidadeVenda)
                        {
                            // Atualizar estoque
                            Jogo jogoAtualizado = jogos[i];
                            jogoAtualizado.Quantidade -= quantidadeVenda;
                            jogos[i] = jogoAtualizado;

                            // Registrar venda
                            Venda novaVenda = new Venda
                            {
                                Produto = nomeProduto,
                                Quantidade = quantidadeVenda,
                                PrecoUnitario = jogos[i].Preco,
                                DataVenda = DateTime.Now
                            };
                            vendas.Add(novaVenda);

                            // Salvar dados
                            SalvarJogos();
                            SalvarVendas();

                            double valorTotal = quantidadeVenda * jogos[i].Preco;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\n✓ Venda realizada com sucesso!");
                            Console.WriteLine($"Produto: {nomeProduto}");
                            Console.WriteLine($"Quantidade: {quantidadeVenda}");
                            Console.WriteLine($"Valor unitário: {jogos[i].Preco:C}");
                            Console.WriteLine($"Valor total: {valorTotal:C}");
                            Console.WriteLine($"Estoque restante: {jogos[i].Quantidade}");
                            Console.ResetColor();
                            vendaRealizada = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"❌ Estoque insuficiente! Disponível: {jogos[i].Quantidade}");
                            Console.ResetColor();
                            vendaRealizada = true;
                        }
                        break;
                    }
                }

                // Procurar periférico se não encontrou jogo
                if (!vendaRealizada)
                {
                    for (int i = 0; i < perifericos.Count; i++)
                    {
                        if (perifericos[i].Nome.ToLower() == nomeProduto.ToLower())
                        {
                            if (perifericos[i].Quantidade >= quantidadeVenda)
                            {
                                // Atualizar estoque
                                Periferico perifericoAtualizado = perifericos[i];
                                perifericoAtualizado.Quantidade -= quantidadeVenda;
                                perifericos[i] = perifericoAtualizado;

                                // Registrar venda
                                Venda novaVenda = new Venda
                                {
                                    Produto = nomeProduto,
                                    Quantidade = quantidadeVenda,
                                    PrecoUnitario = perifericos[i].Preco,
                                    DataVenda = DateTime.Now
                                };
                                vendas.Add(novaVenda);

                                // Salvar dados
                                SalvarPerifericos();
                                SalvarVendas();

                                double valorTotal = quantidadeVenda * perifericos[i].Preco;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\n✓ Venda realizada com sucesso!");
                                Console.WriteLine($"Produto: {nomeProduto}");
                                Console.WriteLine($"Quantidade: {quantidadeVenda}");
                                Console.WriteLine($"Valor unitário: {perifericos[i].Preco:C}");
                                Console.WriteLine($"Valor total: {valorTotal:C}");
                                Console.WriteLine($"Estoque restante: {perifericos[i].Quantidade}");
                                Console.ResetColor();
                                vendaRealizada = true;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"❌ Estoque insuficiente! Disponível: {perifericos[i].Quantidade}");
                                Console.ResetColor();
                                vendaRealizada = true;
                            }
                            break;
                        }
                    }
                }

                if (!vendaRealizada)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❌ Produto não encontrado!");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                Console.ResetColor();
            }
        }

        static void GerarRelatorioVendas()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║       RELATÓRIO DE VENDAS        ║");
            Console.WriteLine("╚═══════════════════════════════════╝");
            Console.ResetColor();

            if (vendas.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n⚠️ Nenhuma venda registrada ainda!");
                Console.ResetColor();
                return;
            }

            double totalGeral = 0;
            double totalJogos = 0;
            double totalPerifericos = 0;
            int qtdVendasJogos = 0;
            int qtdVendasPerifericos = 0;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n--- HISTÓRICO DE VENDAS ---");
            Console.ResetColor();

            foreach (var venda in vendas.OrderByDescending(v => v.DataVenda))
            {
                double valorVenda = venda.Quantidade * venda.PrecoUnitario;
                totalGeral += valorVenda;

                // Verificar se é jogo ou periférico
                bool ehJogo = jogos.Any(j => j.Nome.ToLower() == venda.Produto.ToLower());
                if (ehJogo)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("🎮 ");
                    totalJogos += valorVenda;
                    qtdVendasJogos++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("🖱️ ");
                    totalPerifericos += valorVenda;
                    qtdVendasPerifericos++;
                }

                Console.ResetColor();
                Console.WriteLine($"{venda} | Total: {valorVenda:C}");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n--- RESUMO POR CATEGORIA ---");
            Console.ResetColor();
            Console.WriteLine($"🎮 Jogos: {qtdVendasJogos} vendas - Faturamento: {totalJogos:C}");
            Console.WriteLine($"🖱️ Periféricos: {qtdVendasPerifericos} vendas - Faturamento: {totalPerifericos:C}");
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n💰 FATURAMENTO TOTAL: {totalGeral:C}");
            Console.WriteLine($"📊 TOTAL DE VENDAS: {vendas.Count}");
            Console.ResetColor();
        }

        static void ImprimirEstoque()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║         ESTOQUE ATUAL            ║");
            Console.WriteLine("╚═══════════════════════════════════╝");
            Console.ResetColor();

            // Exibir jogos
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n--- JOGOS EM ESTOQUE ---");
            Console.ResetColor();

            if (jogos.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Nenhum jogo cadastrado.");
                Console.ResetColor();
            }
            else
            {
                double valorTotalJogos = 0;
                int quantidadeTotalJogos = 0;

                foreach (var jogo in jogos.OrderBy(j => j.Nome))
                {
                    if (jogo.Quantidade == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("❌ [SEM ESTOQUE] ");
                    }
                    else if (jogo.Quantidade <= 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("⚠️ [ESTOQUE BAIXO] ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("✅ ");
                    }

                    Console.ResetColor();
                    Console.WriteLine($"🎮 {jogo}");
                    
                    valorTotalJogos += jogo.Quantidade * jogo.Preco;
                    quantidadeTotalJogos += jogo.Quantidade;
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Subtotal Jogos: {quantidadeTotalJogos} unidades - Valor: {valorTotalJogos:C}");
                Console.ResetColor();
            }

            // Exibir periféricos
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n--- PERIFÉRICOS EM ESTOQUE ---");
            Console.ResetColor();

            if (perifericos.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Nenhum periférico cadastrado.");
                Console.ResetColor();
            }
            else
            {
                double valorTotalPerifericos = 0;
                int quantidadeTotalPerifericos = 0;

                foreach (var periferico in perifericos.OrderBy(p => p.Nome))
                {
                    if (periferico.Quantidade == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("❌ [SEM ESTOQUE] ");
                    }
                    else if (periferico.Quantidade <= 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("⚠️ [ESTOQUE BAIXO] ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("✅ ");
                    }

                    Console.ResetColor();
                    Console.WriteLine($"🖱️ {periferico}");
                    
                    valorTotalPerifericos += periferico.Quantidade * periferico.Preco;
                    quantidadeTotalPerifericos += periferico.Quantidade;
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Subtotal Periféricos: {quantidadeTotalPerifericos} unidades - Valor: {valorTotalPerifericos:C}");
                Console.ResetColor();
            }

            // Resumo geral
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n--- RESUMO GERAL DO ESTOQUE ---");
            Console.WriteLine($"Total de produtos: {jogos.Count + perifericos.Count}");
            Console.WriteLine($"Total de itens: {jogos.Sum(j => j.Quantidade) + perifericos.Sum(p => p.Quantidade)}");
            Console.WriteLine($"Valor total em estoque: {(jogos.Sum(j => j.Quantidade * j.Preco) + perifericos.Sum(p => p.Quantidade * p.Preco)):C}");
            Console.ResetColor();
        }

        static void MenuCadastro()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("╔═══════════════════════════════════╗");
                Console.WriteLine("║        MENU DE CADASTRO          ║");
                Console.WriteLine("╚═══════════════════════════════════╝");
                Console.ResetColor();

                Console.WriteLine("\n1 - Cadastrar Jogo");
                Console.WriteLine("2 - Cadastrar Periférico");
                Console.WriteLine("0 - Voltar ao Menu Principal");
                Console.Write("\nEscolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarJogo();
                        break;
                    case "2":
                        CadastrarPeriferico();
                        break;
                    case "0":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida!");
                        Console.ResetColor();
                        break;
                }

                if (opcao != "0")
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        static void MenuConsultaExclusao()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔═══════════════════════════════════╗");
                Console.WriteLine("║    MENU CONSULTA/EXCLUSÃO        ║");
                Console.WriteLine("╚═══════════════════════════════════╝");
                Console.ResetColor();

                Console.WriteLine("\n1 - Consultar Produto");
                Console.WriteLine("2 - Excluir Produto");
                Console.WriteLine("0 - Voltar ao Menu Principal");
                Console.Write("\nEscolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ConsultarProduto();
                        break;
                    case "2":
                        ExcluirProduto();
                        break;
                    case "0":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida!");
                        Console.ResetColor();
                        break;
                }

                if (opcao != "0")
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        static void ExibirSobre()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    SOBRE O SISTEMA                      ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine("\n🎮 MINEUP MANAGER - Sistema de Gerenciamento de Estoque");
            Console.WriteLine("📚 Projeto Acadêmico - 4º Período de Engenharia de Software");
            Console.WriteLine("🏗️ Arquitetura: Sistema Monolítico sem Orientação a Objetos");
            Console.WriteLine("💾 Persistência: Arquivos de texto (.txt)");
            Console.WriteLine("🖥️ Interface: Console com cores");
            Console.WriteLine("⚙️ Tecnologia: C# .NET");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n--- FUNCIONALIDADES ---");
            Console.ResetColor();
            Console.WriteLine("✅ RF01: Cadastro de jogos e periféricos");
            Console.WriteLine("✅ RF02: Consulta de produtos");
            Console.WriteLine("✅ RF03: Exclusão de produtos");
            Console.WriteLine("✅ RF04: Realização de vendas");
            Console.WriteLine("✅ RF05: Relatórios de vendas");
            Console.WriteLine("✅ RF06: Visualização de estoque");
            Console.WriteLine("✅ RF07: Sistema de menus intuitivo");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n--- CARACTERÍSTICAS TÉCNICAS ---");
            Console.ResetColor();
            Console.WriteLine("✅ RNF01: Arquitetura monolítica");
            Console.WriteLine("✅ RNF02: Uso exclusivo de structs, listas e funções");
            Console.WriteLine("✅ RNF03: Persistência em arquivos .txt");
            Console.WriteLine("✅ RNF04: Interface colorida no console");
            Console.WriteLine("✅ RNF05: Carregamento automático de dados");
            Console.WriteLine("✅ RNF06: Tratamento completo de erros");

            Console.WriteLine("\n📧 Desenvolvido por Gabriel Nogueira e Daniel Ângelo");
            Console.WriteLine("📅 Versão 1.0 - 2025");
        }

        static void Main(string[] args)
        {
            // RNF05: Carregar dados na inicialização
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("🚀 Inicializando GameUp Store...");
            Console.ResetColor();
            
            CarregarJogos();
            CarregarPerifericos();
            CarregarVendas();
            
            Console.WriteLine("✅ Sistema iniciado com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();

            // Loop principal do menu
            while (true)
            {
                Console.Clear();
                
                // Cabeçalho do sistema
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                      MINEUP MANAGER                       ║");
                Console.WriteLine("║              Sistema de Gestão de Estoque               ║");
                Console.WriteLine("║                 Jogos & Periféricos                     ║");
                Console.WriteLine("╚══════════════════════════════════════════════════════════╝");
                Console.ResetColor();

                // Informações rápidas do sistema
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"📊 Jogos: {jogos.Count} | Periféricos: {perifericos.Count} | Vendas: {vendas.Count}");
                Console.ResetColor();

                // Menu principal
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n═══════════════ MENU PRINCIPAL ═══════════════");
                Console.ResetColor();
                
                Console.WriteLine("1  - 📝 Cadastrar Produtos");
                Console.WriteLine("2  - 💰 Realizar Venda");
                Console.WriteLine("3  - 📦 Visualizar Estoque");
                Console.WriteLine("4  - 🔍 Consultar/Excluir Produtos");
                Console.WriteLine("5  - 📊 Relatório de Vendas");
                Console.WriteLine("6  - ℹ️  Sobre o Sistema");
                Console.WriteLine("0  - 🚪 Sair do Sistema");
                
                Console.Write("\n🎯 Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        MenuCadastro();
                        break;
                    case "2":
                        RealizarVenda();
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "3":
                        ImprimirEstoque();
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "4":
                        MenuConsultaExclusao();
                        break;
                    case "5":
                        GerarRelatorioVendas();
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "6":
                        ExibirSobre();
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "0":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
                        Console.WriteLine("║                 OBRIGADO POR USAR O                     ║");
                        Console.WriteLine("║                    MINEUP MANAGER!                       ║");
                        Console.WriteLine("║                                                          ║");
                        Console.WriteLine("║              Sistema finalizado com sucesso             ║");
                        Console.WriteLine("╚══════════════════════════════════════════════════════════╝");
                        Console.ResetColor();
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("❌ Opção inválida! Tente novamente.");
                        Console.ResetColor();
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}