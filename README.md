markdown
# 🎮 MineUp Manager - Sistema de Gerenciamento de Estoque e Vendas

## 📋 Sobre o Projeto

O **GameUp Store** é um sistema monolítico de gerenciamento de estoque e vendas desenvolvido especificamente para uma loja fictícia especializada em **jogos** e **periféricos**. Este projeto foi desenvolvido como parte do currículo acadêmico do **4º período de Engenharia de Software**, seguindo rigorosamente os princípios de programação estruturada **sem orientação a objetos (POO)**.

### 🎯 Objetivo

Criar um sistema completo para gerenciar estoque e vendas utilizando apenas **structs**, **listas** e **funções**, com persistência de dados em arquivos locais, demonstrando competência em programação estruturada e organização de código por camadas funcionais.

---

## 🏗️ Arquitetura do Sistema

### Arquitetura Monolítica por Camadas Funcionais

```
┌─────────────────────────────────────────┐
│          CAMADA DE INTERFACE            │
│         (Console com Menus)             │
├─────────────────────────────────────────┤
│       CAMADA DE LÓGICA DE NEGÓCIO       │
│    (Validações e Regras de Negócio)     │
├─────────────────────────────────────────┤
│        CAMADA DE PERSISTÊNCIA           │
│        (Arquivos .txt locais)           │
├─────────────────────────────────────────┤
│          CAMADA DE DADOS                │
│       (Structs: Jogo, Periférico,      │
│            Venda)                       │
└─────────────────────────────────────────┘
```

### 📊 Estruturas de Dados

#### 🎮 Struct Jogo
```csharp
public struct Jogo
{
    public string Nome;      // Nome do jogo
    public string Genero;    // Gênero (RPG, FPS, etc.)
    public int Quantidade;   // Quantidade em estoque
    public double Preco;     // Preço unitário
}
```

#### 🖱️ Struct Periférico
```csharp
public struct Periferico
{
    public string Nome;      // Nome do periférico
    public string Tipo;      // Tipo (Mouse, Teclado, etc.)
    public int Quantidade;   // Quantidade em estoque
    public double Preco;     // Preço unitário
}
```

#### 💰 Struct Venda
```csharp
public struct Venda
{
    public string Produto;        // Nome do produto vendido
    public int Quantidade;        // Quantidade vendida
    public double PrecoUnitario;  // Preço na data da venda
    public DateTime DataVenda;    // Data e hora da venda
}
```

---

## ⚙️ Requisitos Funcionais (RF)

| RF | Descrição | Status |
|---|---|---|
| **RF01** | Cadastro de jogos com validação completa | ✅ |
| **RF02** | Cadastro de periféricos com validação completa | ✅ |
| **RF03** | Consulta de produtos por nome/gênero/tipo | ✅ |
| **RF04** | Exclusão de produtos com confirmação do usuário | ✅ |
| **RF05** | Realização de vendas com controle de estoque | ✅ |
| **RF06** | Relatórios detalhados de vendas por categoria | ✅ |
| **RF07** | Sistema de menus intuitivo e organizado | ✅ |

---

## 🔧 Requisitos Não Funcionais (RNF)

| RNF | Descrição | Status |
|---|---|---|
| **RNF01** | Arquitetura monolítica sem POO | ✅ |
| **RNF02** | Uso exclusivo de structs, listas e funções | ✅ |
| **RNF03** | Persistência em arquivos .txt locais | ✅ |
| **RNF04** | Interface console colorida e intuitiva | ✅ |
| **RNF05** | Carregamento automático de dados na inicialização | ✅ |
| **RNF06** | Tratamento robusto de erros e validações | ✅ |

---

## 🚀 Funcionalidades Principais

### 📝 1. Gestão de Produtos
- **Cadastro de Jogos**: Nome, gênero, quantidade, preço
- **Cadastro de Periféricos**: Nome, tipo, quantidade, preço
- **Validações**: Campos obrigatórios, valores positivos, duplicatas
- **Feedback Visual**: Confirmações e alertas coloridos

### 🔍 2. Sistema de Consultas
- **Busca Inteligente**: Por nome parcial, gênero ou tipo
- **Resultados Categorizados**: Jogos e periféricos separados
- **Informações Completas**: Exibe todos os detalhes do produto

### 🗑️ 3. Exclusão Controlada
- **Busca Exata**: Por nome completo do produto
- **Confirmação Obrigatória**: Previne exclusões acidentais
- **Feedback Imediato**: Confirmação de operação realizada

### 💰 4. Sistema de Vendas
- **Controle de Estoque**: Verificação automática de disponibilidade
- **Cálculos Automáticos**: Valor unitário e total da venda
- **Registro Completo**: Data, hora, produto, quantidade, valores
- **Atualização Automática**: Estoque atualizado em tempo real

### 📊 5. Relatórios Avançados
- **Histórico Completo**: Todas as vendas com data/hora
- **Totais por Categoria**: Jogos vs Periféricos
- **Faturamento**: Valores totais e por categoria
- **Ordenação**: Vendas mais recentes primeiro

### 📦 6. Controle de Estoque
- **Visualização Completa**: Todos os produtos cadastrados
- **Alertas Visuais**: 
  - ❌ Sem estoque (quantidade = 0)
  - ⚠️ Estoque baixo (quantidade ≤ 5)
  - ✅ Estoque normal (quantidade > 5)
- **Resumos**: Totais por categoria e valor em estoque

---

## 🛠️ Tecnologias Utilizadas

- **Linguagem**: C# (.NET 9.0)
- **Interface**: Console Application
- **Persistência**: System.IO (arquivos .txt)
- **Consultas**: System.Linq
- **Estruturas**: System.Collections.Generic
- **Formatação**: Console colors e caracteres especiais

---

## 📁 Estrutura do Projeto

```
MineUpManager/
├── Program.cs              # Código principal do sistema
├── MineUpManager.csproj    # Configuração do projeto .NET
├── jogos.txt              # Dados dos jogos (gerado automaticamente)
├── perifericos.txt        # Dados dos periféricos (gerado automaticamente)
├── vendas.txt             # Histórico de vendas (gerado automaticamente)
├── bin/                   # Arquivos compilados
└── obj/                   # Arquivos temporários
```

---

## 🔧 Como Executar

### Pré-requisitos
- **.NET SDK 9.0** ou superior
- **Visual Studio Code** (recomendado)
- **C# Extension** para VS Code

### Passos para Execução

1. **Clone o repositório**:
```bash
git clone https://github.com/seu-usuario/mineup-manager.git
cd mineup-manager/MineUpManager
```

2. **Restaurar dependências**:
```bash
dotnet restore
```

3. **Compilar o projeto**:
```bash
dotnet build
```

4. **Executar o sistema**:
```bash
dotnet run
```

### Execução via Visual Studio Code
1. Abra a pasta MineUpManager no VS Code
2. Pressione `F5` para executar com debug
3. Ou use `Ctrl+F5` para executar sem debug

---

## 🎮 Como Usar o Sistema

### Menu Principal
```
╔══════════════════════════════════════════════════════════╗
║                      GAMEUP STORE                       ║
║              Sistema de Gestão de Estoque               ║
║                 Jogos & Periféricos                     ║
╚══════════════════════════════════════════════════════════╝

1  - 📝 Cadastrar Produtos
2  - 💰 Realizar Venda
3  - 📦 Visualizar Estoque
4  - 🔍 Consultar/Excluir Produtos
5  - 📊 Relatório de Vendas
6  - ℹ️  Sobre o Sistema
0  - 🚪 Sair do Sistema
```

### Fluxo de Uso Recomendado

1. **Primeira execução**: Cadastre alguns jogos e periféricos
2. **Verifique o estoque**: Use a opção 3 para visualizar
3. **Realize vendas**: Use a opção 2 para processar vendas
4. **Consulte relatórios**: Use a opção 5 para acompanhar vendas
5. **Gerencie produtos**: Use a opção 4 para consultar/excluir

---

## 💾 Persistência de Dados

### Formato dos Arquivos

#### jogos.txt
```
FIFA 2024|Esporte|15|299.90
The Witcher 3|RPG|8|149.90
Counter-Strike 2|FPS|25|79.90
```

#### perifericos.txt
```
Mouse Gamer RGB|Mouse|30|89.90
Teclado Mecânico|Teclado|12|199.90
Headset 7.1|Headset|18|149.90
```

#### vendas.txt
```
FIFA 2024|2|299.90|2025-09-11 14:30:15
Mouse Gamer RGB|1|89.90|2025-09-11 15:45:22
```

### Características da Persistência
- **Automática**: Dados salvos após cada operação
- **Recuperação**: Carregamento automático na inicialização
- **Formato**: Separador pipe (|) para compatibilidade
- **Encoding**: UTF-8 para suporte a caracteres especiais

---

## 🎨 Interface e Experiência do Usuário

### Recursos Visuais
- **Cores Categorizadas**: 
  - 🟢 Verde: Sucessos e confirmações
  - 🔴 Vermelho: Erros e alertas críticos
  - 🟡 Amarelo: Avisos e informações
  - 🔵 Azul: Cabeçalhos e títulos
  - 🟣 Roxo: Ações especiais
  - ⚪ Branco: Informações normais

- **Símbolos e Emojis**:
  - 🎮 Jogos
  - 🖱️ Periféricos
  - 💰 Vendas
  - 📦 Estoque
  - ✅ Sucesso
  - ❌ Erro
  - ⚠️ Aviso

### Navegação Intuitiva
- **Menus Hierárquicos**: Organização lógica das funcionalidades
- **Confirmações**: Operações críticas sempre confirmadas
- **Feedback Imediato**: Resultados visíveis instantaneamente
- **Navegação Simples**: Retorno fácil aos menus anteriores

---

## 🔍 Validações e Tratamento de Erros

### Validações Implementadas
- **Campos Obrigatórios**: Nenhum campo pode estar vazio
- **Valores Numéricos**: Validação de formato e tipos
- **Valores Positivos**: Quantidades e preços sempre > 0
- **Produtos Duplicados**: Aviso para nomes já existentes
- **Estoque Suficiente**: Verificação antes das vendas

### Tratamento de Erros
```csharp
// Exemplo de tratamento robusto
try
{
    // Operação que pode falhar
    int.Parse(entrada);
}
catch (FormatException)
{
    Console.WriteLine("❌ Erro: Digite apenas números!");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Erro inesperado: {ex.Message}");
}
```

---

## 📊 Exemplos de Uso

### Cadastro de Produto
```
╔═══════════════════════════════════╗
║          CADASTRAR JOGO           ║
╚═══════════════════════════════════╝

Digite o nome do jogo: FIFA 2024
Digite o gênero do jogo: Esporte
Digite a quantidade em estoque: 15
Digite o preço (R$): 299.90

✓ Jogo cadastrado com sucesso!
Detalhes: Nome: FIFA 2024, Gênero: Esporte, Quantidade: 15, Preço: R$ 299,90
```

### Realização de Venda
```
╔═══════════════════════════════════╗
║         REALIZAR VENDA           ║
╚═══════════════════════════════════╝

Digite o nome do produto: FIFA 2024
Digite a quantidade: 2

✓ Venda realizada com sucesso!
Produto: FIFA 2024
Quantidade: 2
Valor unitário: R$ 299,90
Valor total: R$ 599,80
Estoque restante: 13
```

### Relatório de Vendas
```
╔═══════════════════════════════════╗
║       RELATÓRIO DE VENDAS        ║
╚═══════════════════════════════════╝

--- HISTÓRICO DE VENDAS ---
🎮 Produto: FIFA 2024, Quantidade: 2, Preço Unitário: R$ 299,90, Data: 11/09/2025 14:30 | Total: R$ 599,80
🖱️ Produto: Mouse Gamer RGB, Quantidade: 1, Preço Unitário: R$ 89,90, Data: 11/09/2025 15:45 | Total: R$ 89,90

--- RESUMO POR CATEGORIA ---
🎮 Jogos: 1 vendas - Faturamento: R$ 599,80
🖱️ Periféricos: 1 vendas - Faturamento: R$ 89,90

💰 FATURAMENTO TOTAL: R$ 689,70
📊 TOTAL DE VENDAS: 2
```

---

## 🧪 Testes e Qualidade

### Cenários de Teste Validados
- ✅ Cadastro com dados válidos
- ✅ Cadastro com dados inválidos
- ✅ Vendas com estoque suficiente
- ✅ Vendas com estoque insuficiente
- ✅ Consultas com produtos existentes
- ✅ Consultas com produtos inexistentes
- ✅ Exclusões com confirmação
- ✅ Exclusões canceladas
- ✅ Persistência de dados
- ✅ Recuperação de dados
- ✅ Tratamento de arquivos corrompidos

### Qualidade do Código
- **Organização**: Código estruturado em camadas lógicas
- **Comentários**: Documentação adequada das funções
- **Nomenclatura**: Nomes descritivos e padronizados
- **Modularidade**: Funções com responsabilidades específicas
- **Reutilização**: Funções de validação reutilizáveis

---

## 🔮 Melhorias Futuras

### Funcionalidades Planejadas
- 📱 Interface gráfica (WPF/WinForms)
- 🗄️ Migração para banco de dados
- 🔐 Sistema de usuários e permissões
- 📈 Relatórios avançados com gráficos
- 🔄 Sistema de backup automático
- 📋 Importação/exportação de dados
- 🏷️ Sistema de categorias e tags
- 💳 Múltiplas formas de pagamento

### Melhorias Técnicas
- ⚡ Otimização de performance
- 🧪 Testes unitários automatizados
- 📦 Empacotamento em executável único
- 🌐 API REST para integração
- 📱 Aplicativo mobile complementar

---

## 👥 Equipe de Desenvolvimento

- **Desenvolvedores**: Daniel Ângelo de Miranda Ribeiro e Gabriel Henrique Nogueira
- **Metodologia**: Programação em pares
- **Paradigma**: Programação estruturada (sem POO)
- **Arquitetura**: Monolítica por camadas funcionais

---

## 📄 Licença

Este projeto é desenvolvido para fins acadêmicos como parte do currículo de Engenharia de Software. Todos os direitos reservados aos desenvolvedores.

---

## 📞 Suporte

Para dúvidas, sugestões ou relatos de bugs:

- 📁 **Issues**: Abra uma issue neste repositório
- 📚 **Documentação**: Consulte este README.md

---

## 🏆 Reconhecimentos

Agradecimentos especiais:
- Professores do curso de Engenharia de Software (Ronan Loschi)
- Comunidade .NET
- Microsoft pela documentação excepcional
- Colegas de classe pelo feedback e testes

---

*⭐ Se este projeto foi útil para você, considere dar uma estrela no repositório!*

---

**GameUp Store** - *Gerenciando o futuro dos games, um produto por vez.* 🎮
