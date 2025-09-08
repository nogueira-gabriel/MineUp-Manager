# MineUp Manager

💾 **MineUp Manager** é um sistema em C# para gerenciar estoque e vendas de uma loja fictícia de jogos.  
O projeto é **monolítico**, desenvolvido via console, sem uso de POO, utilizando apenas **structs, listas e funções**, com persistência em **arquivos locais**.

---

## 🎯 Objetivo
Desenvolver um sistema para gerenciar o estoque e as vendas de uma loja fictícia chamada **MineUp Manager Store**, especializada em jogos.  
O sistema deve permitir cadastro de produtos, vendas, exclusões, consultas e geração de relatórios.

---

## 📋 Requisitos Funcionais (RF)

- **RF01:** Cadastro de Produto 1 (mín. 3 atributos).  
- **RF02:** Cadastro de Produto 2 (mín. 3 atributos).  
- **RF03:** Consulta de produtos por nome e exibição de quantidade em estoque.  
- **RF04:** Exclusão de produtos após confirmação do usuário.  
- **RF05:** Realização de vendas, atualizando estoque e registrando a venda.  
- **RF06:** Relatórios de vendas (total por categoria e total geral).  
- **RF07:** Salvar dados em arquivos após cada operação.

---

## ⚙️ Requisitos Não Funcionais (RNF)

- **RNF01:** Implementação em **C#** usando apenas structs, listas e funções.  
- **RNF02:** Arquitetura **monolítica** com separação lógica por camadas.  
- **RNF03:** Persistência em arquivos locais (sem banco de dados).  
- **RNF04:** Execução via **console**, com menus interativos e uso de cores.  
- **RNF05:** Recuperação automática dos dados salvos ao iniciar.  
- **RNF06:** Tratamento de entradas inválidas e mensagens amigáveis.

---

## 🏗️ Arquitetura em Camadas

### 1. Camada de Dados (Modelos e Estruturas)
- **Structs:**  
  - `jogo`: nome, gênero, quantidade, preço  
  - `acessório`: nome, tipo, quantidade, preço  
  - `venda`: produto, quantidade, preço unitário  

- Cada `struct` deve conter um `ToString()` para exibir os dados no console.

### 2. Camada de Persistência (Arquivos)
Funções responsáveis por salvar e carregar os dados:  
- Gravar listas de produtos e vendas em arquivos `.txt` ou `.csv`  
- Ler arquivos ao iniciar o sistema  
- Atualizar arquivos após cada operação  

### 3. Camada de Lógica de Negócio
- Cadastro, consulta, exclusão, venda, cálculo de totais  
- Verificação e atualização de estoque  
- Geração de relatórios  

### 4. Camada de Interface (Console)
Menus interativos:  
- `1` → Cadastrar Produto  
- `2` → Realizar Venda  
- `99` → Imprimir Estoque  
- `00` → Consultar ou Excluir Produto  
- `1000` → Imprimir Relatório de Vendas  
- `0000` → Sair  

---

## ✅ Critérios de Avaliação

- Organização por camadas funcionais  
- Uso correto de structs e listas  
- Persistência em arquivos  
- Interface amigável no console  
- Tratamento de erros e validações  
- Clareza e formatação de relatórios  
- Atendimento aos requisitos funcionais e não funcionais  
- Versionamento com Git/GitHub  
- Apresentação do sistema ao professor  

---

## 📅 Datas de Apresentação
- 18/09  
- 25/09  

---

## 👨‍💻 Observações
- Não utilizar POO (classes, herança ou encapsulamento).  
- Implementação **exclusivamente** com structs, listas e funções.  
- Persistência somente em arquivos locais.  


OBS: Criar uma função para tratar as funcções, se queremos salvar ou carregar os jogos + perifericos 