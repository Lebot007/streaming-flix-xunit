# 🎬 StreamingFlix — Testes Unitários Parametrizados com xUnit

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)
![xUnit](https://img.shields.io/badge/xUnit-2.9.3-009E73)
![C#](https://img.shields.io/badge/C%23-12-239120?logo=csharp&logoColor=white)
![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)

> Projeto acadêmico da disciplina **Garantia da Qualidade de Software** (Gestão e Qualidade de Software) — Professor **Daniel Henrique Matos de Paiva**.
>
> Repositório: [github.com/Lebot007/streaming-flix-xunit](https://github.com/Lebot007/streaming-flix-xunit)

---

## 👥 Equipe

| Nome Completo | RA |
|---------------|:--:|
| Rafael Luiz Ferreira de Souza | 32511503 |
| João Vitor Alves Rodrigues | 32513480 |
| Pietro Cardoso de Oliveira | 32515280 |

---

## 📋 Visão Geral

O **StreamingFlix** é uma aplicação de console em **C# / .NET 10** que simula as regras de negócio de um serviço de streaming. O objetivo central do projeto é demonstrar boas práticas de **Garantia da Qualidade de Software (QA)**, aplicando **Testes Unitários Parametrizados** com o framework **xUnit** (`[Theory]` + `[InlineData]`) sobre o serviço `PlanoStreamingService`.

A classe `PlanoStreamingService` implementa três regras de negócio:

| # | Método | Regra de Negócio |
|---|--------|------------------|
| 1 | `ObterClassificacaoPorQualidade(int telasSimultaneas)` | Classifica o plano: **1 tela → "BÁSICO"**, **2 telas → "PADRÃO"**, **4 ou mais telas → "PREMIUM"** |
| 2 | `CalcularMensalidadeComDesconto(int valorBase, int mesesContratados)` | Aplica desconto por fidelidade: **6 a 11 meses → 10%**, **12 meses ou mais → 20%**, **menos de 6 meses → sem desconto** |
| 3 | `PodeAcessarConteudoAdulto(int idade, bool controleParentalAtivo)` | Retorna `true` **apenas** se `idade >= 18` **E** `controleParentalAtivo == false` |

### 🗂️ Estrutura da Solução

```
streaming-flix-xunit/
├── StreamingFlix.slnx                      # Arquivo de solução (novo formato XML do .NET)
├── StreamingFlix.App/                      # Projeto de aplicação (regras de negócio)
│   ├── StreamingFlix.App.csproj
│   ├── PlanoStreamingService.cs            # Serviço com as 3 regras de negócio
│   └── Program.cs                          # Demonstração de uso no console
├── StreamingFlix.Tests/                    # Projeto de testes unitários (xUnit)
│   ├── StreamingFlix.Tests.csproj
│   └── PlanoStreamingServiceTests.cs       # Suíte parametrizada [Theory]/[InlineData]
├── .gitignore                              # Padrão oficial para projetos .NET
├── LICENSE                                 # Licença MIT
└── README.md                               # Esta documentação
```

---

## 🔧 Como Fizemos

O projeto foi desenvolvido em equipe, com o trabalho dividido em três frentes complementares, conforme os papéis definidos na lista de exercícios. Cada frente foi responsável por uma camada do projeto — **código**, **qualidade** e **versionamento/documentação** — e o resultado foi integrado em um único repositório Git.

### Etapa 1 — Estrutura da Solução e Regras de Negócio (Dev 1: Backend / Core)

A solução foi criada do zero utilizando o **.NET CLI**, com um projeto de console para a aplicação e um projeto xUnit para os testes:

```bash
dotnet new sln -n StreamingFlix
dotnet new console -n StreamingFlix.App -f net10.0
dotnet new xunit -n StreamingFlix.Tests -f net10.0
dotnet sln add StreamingFlix.App/StreamingFlix.App.csproj
dotnet sln add StreamingFlix.Tests/StreamingFlix.Tests.csproj
dotnet add StreamingFlix.Tests/StreamingFlix.Tests.csproj reference StreamingFlix.App/StreamingFlix.App.csproj
```

Em seguida, foi implementada a classe `PlanoStreamingService.cs` com os três métodos de regra de negócio (`ObterClassificacaoPorQualidade`, `CalcularMensalidadeComDesconto` e `PodeAcessarConteudoAdulto`), documentados com comentários XML (`/// <summary>`), e o `Program.cs` com uma demonstração de uso de cada regra no console.

### Etapa 2 — Testes Unitários Parametrizados (Dev 2: QA / Testes)

No projeto `StreamingFlix.Tests`, foi construída a classe `PlanoStreamingServiceTests.cs` utilizando os atributos **`[Theory]`** e **`[InlineData]`** do xUnit, criando **3 teorias com 9 cenários de teste** no total — uma teoria para cada regra de negócio, cobrindo todas as faixas de decisão (classificações de plano, faixas de desconto e combinações de idade × controle parental).

A validação foi feita executando `dotnet test` no terminal, garantindo que **100% dos cenários passem com sucesso** antes do commit.

### Etapa 3 — Versionamento e Documentação (Dev 3: DevOps)

- Criação do **repositório público** [`streaming-flix-xunit`](https://github.com/Lebot007/streaming-flix-xunit) no GitHub;
- Adição do arquivo **`.gitignore`** com o padrão oficial para projetos .NET (ignora `bin/`, `obj/`, `.vs/`, resultados de teste e arquivos de cobertura);
- Configuração da **Licença MIT** no arquivo `LICENSE`;
- Escrita desta documentação (`README.md`), com instruções de instalação, execução e testes.

### Fluxo de Trabalho

1. Cada desenvolvedor implementou sua parte localmente e validou com `dotnet build` / `dotnet test`;
2. O código foi versionado com **Git** e integrado na branch `main` do GitHub por meio de commits incrementais, cada um descrevendo a etapa entregue;
3. A documentação foi revisada para refletir fielmente a estrutura final da solução.

---

## 🛠️ Requisitos Técnicos

| Requisito | Versão mínima | Observações |
|-----------|---------------|-------------|
| [.NET SDK](https://dotnet.microsoft.com/download) | **10.0** | Os projetos têm `TargetFramework` **net10.0** |
| [Git](https://git-scm.com/downloads) | 2.x | Para clonar o repositório |
| xUnit | 2.9.3 | Restaurado automaticamente via NuGet |
| Microsoft.NET.Test.Sdk | 17.14.1 | Restaurado automaticamente via NuGet |
| xunit.runner.visualstudio | 3.1.4 | Permite executar os testes no Visual Studio |
| coverlet.collector | 6.0.4 | Coleta de cobertura de código |

> 💡 Nenhuma instalação manual de pacotes é necessária: o `dotnet restore` baixa todas as dependências NuGet automaticamente.

Verifique se o SDK está instalado:

```bash
dotnet --version
```

---

## 🚀 Como Clonar e Executar a Aplicação

### 1. Clone o repositório

```bash
git clone https://github.com/Lebot007/streaming-flix-xunit.git
```

### 2. Acesse a pasta do projeto

```bash
cd streaming-flix-xunit
```

### 3. Restaure as dependências e compile a solução

```bash
dotnet restore
dotnet build
```

### 4. Execute a aplicação

```bash
dotnet run --project StreamingFlix.App
```

Saída esperada no console:

```
Plano com 1 tela:  BÁSICO
Plano com 2 telas: PADRÃO
Plano com 4 telas: PREMIUM
Mensalidade base 50, contrato de 1 mês:  50 (sem desconto)
Mensalidade base 50, contrato de 6 meses: 45 (10% de desconto)
Mensalidade base 50, contrato de 12 meses: 40 (20% de desconto)
Acesso adulto (20 anos, controle parental desativado): True
Acesso adulto (20 anos, controle parental ativado):    False
Acesso adulto (16 anos, controle parental desativado): False
```

---

## ✅ Como Executar os Testes Unitários

Os testes ficam no projeto `StreamingFlix.Tests` e são executados via **CLI** com o comando `dotnet test`.

### Executar todos os testes da solução

A partir da raiz do repositório:

```bash
dotnet test
```

Saída esperada (9 cenários parametrizados):

```
Determining projects to restore...
All projects are up-to-date for restore.
  StreamingFlix.App succeeded
  StreamingFlix.Tests succeeded

Test run for /.../StreamingFlix.Tests/bin/Debug/net10.0/StreamingFlix.Tests.dll (.NETCoreApp,Version=v10.0)
Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed: 0, Passed: 9, Skipped: 0, Total: 9, Duration: < 1 s - StreamingFlix.Tests.dll (net10.0)
```

### Comandos úteis

```bash
# Executar com detalhes de cada teste
dotnet test --verbosity normal

# Executar apenas um teste específico (por nome)
dotnet test --filter "FullyQualifiedName~ObterClassificacaoPorQualidade"

# Gerar relatório de cobertura de código (coverlet já está configurado no projeto)
dotnet test --collect:"XPlat Code Coverage" --results-directory ./TestResults
```

---

## 🧪 Cobertura dos Testes Parametrizados

A suíte `PlanoStreamingServiceTests.cs` utiliza os atributos **`[Theory]`** e **`[InlineData]`** do xUnit. Diferente de `[Fact]` (que executa um único cenário fixo), `[Theory]` permite que **um mesmo método de teste seja executado várias vezes com conjuntos de dados distintos** fornecidos por `[InlineData]` — reduzindo duplicação de código e ampliando a cobertura das regras de negócio.

### Teste 1 — Classificação de Planos (`ObterClassificacaoPorQualidade`)

| Entrada (`telasSimultaneas`) | Saída esperada | Cenário |
|:---:|:---:|---|
| `1` | `"BÁSICO"` | Plano básico — 1 tela simultânea |
| `2` | `"PADRÃO"` | Plano padrão — 2 telas simultâneas |
| `4` | `"PREMIUM"` | Plano premium — 4 ou mais telas |

```csharp
[Theory]
[InlineData(1, "BÁSICO")]
[InlineData(2, "PADRÃO")]
[InlineData(4, "PREMIUM")]
public void ObterClassificacaoPorQualidade_DeveRetornarClassificacaoCorreta(int telasSimultaneas, string classificacaoEsperada)
{
    // Arrange
    var service = new PlanoStreamingService();

    // Act
    var resultado = service.ObterClassificacaoPorQualidade(telasSimultaneas);

    // Assert
    Assert.Equal(classificacaoEsperada, resultado);
}
```

### Teste 2 — Cálculo de Desconto por Fidelidade (`CalcularMensalidadeComDesconto`)

| `valorBase` | `mesesContratados` | Resultado esperado | Cenário |
|:---:|:---:|:---:|---|
| `50` | `1` | `50` | Sem desconto (contrato < 6 meses) |
| `50` | `6` | `45` | 10% de desconto (6 a 11 meses) |
| `50` | `12` | `40` | 20% de desconto (12 meses ou mais) |

### Teste 3 — Validação de Acesso a Conteúdo Adulto (`PodeAcessarConteudoAdulto`)

| `idade` | `controleParentalAtivo` | Resultado esperado | Cenário |
|:---:|:---:|:---:|---|
| `20` | `false` | `true` | Maior de idade, sem restrição |
| `20` | `true` | `false` | Maior de idade, com restrição (controle parental) |
| `16` | `false` | `false` | Menor de idade |

### Resumo da cobertura

- **3 métodos** de regras de negócio cobertos por **3 `[Theory]`**;
- **9 cenários** (`[InlineData]`) executados automaticamente a cada `dotnet test`;
- Cada regra possui pelo menos um caso por faixa de decisão (sem desconto / 10% / 20%; básico / padrão / premium; liberado / bloqueado por idade / bloqueado por controle parental), garantindo a validação dos **caminhos lógicos** de cada método.

---

## 📜 Licença

Este projeto está licenciado sob a [MIT License](LICENSE).
