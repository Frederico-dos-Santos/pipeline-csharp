# Clinica Médica

![Capa do Projeto](https://picsum.photos/850/280)

## Sobre o Projeto

Neste projeto prático, nosso objetivo é criar uma API dedicada ao gerenciamento de registros de pacientes para uma clínica médica. Esta iniciativa faz parte do curso de Gerência de Configuração e Evolução de Software. Nosso foco principal está na implementação de práticas como integração contínua, automação de processos e entrega contínua de software, destacando-se especialmente na criação e otimização de uma pipeline de implantação eficiente.

## Índice/Sumário

* [Sobre o Projeto](#sobre-o-projeto)
* [Requisitos Funcionais](#requisitos-funcionais)
* [Arquitetura](#arquitetura)
* [Instruções de Uso](#instruções-de-uso)
* [Tecnologias Usadas](#tecnologias-usadas)
* [Testes](#documentação-de-testes)
* [Contribuição](#contribuição)
* [Autores](#autores)
* [Licença](#licença)

## Introdução

O objetivo deste projeto é criar uma API para o gerenciamento de pacientes, utilizando a stack de tecnologias C#, .NET Core, Entity Framework e outras ferramentas modernas para assegurar uma aplicação robusta e eficiente. Este documento descreve as etapas do desenvolvimento, incluindo a configuração do ambiente, o processo de implantação contínua e os testes realizados para garantir a qualidade do software.

## Requisitos Funcionais 

:white_check_mark: Cadastrar pacientes.  
:white_check_mark: Listar todos os pacientes.  
:white_check_mark: Buscar paciente pelo ID.  
:white_check_mark: Editar um paciente.  
:white_check_mark: Deletar um paciente.  
:white_check_mark: Calcular IMC do paciente.  
:white_check_mark: Classificar IMC do paciente.  

## Arquitetura

A arquitetura do sistema é baseada no padrão **MVC** (Model-View-Controller), proporcionando uma separação clara entre as diferentes camadas da aplicação. Para a manipulação dos dados, foi criado:

- **Controllers**: Implementa os endpoints da API para manipulação de dados.
- **Migrations**: As migrations são utilizadas para versionar o banco de dados e garantir que o esquema do banco esteja sempre sincronizado com a estrutura definida pelas entidades (`Models`). O Entity Framework Core é responsável por gerenciar essas migrations automaticamente durante o desenvolvimento e implantação da aplicação.

## Instruções de Uso

Para utilizar a API, siga os passos abaixo:

### 1. Configurar o Ambiente de Desenvolvimento
	
1. Certifique-se de ter o [.NET Core SDK](https://dotnet.microsoft.com/download) instalado.
2. Clone o repositório do GitHub:
   ```sh
   git clone [https://github.com/Frederico-dos-Santos/pipeline-csharp](https://github.com/Frederico-dos-Santos/pipeline-csharp)
   ```
3. Navegue até o diretório do projeto:
   ```sh
   cd pipeline-csharp/WebPatient
   ```
4. Execute o comando Maven para construir o projeto:
   ```sh
   dotnet build
   ```
5. Execute as migrations para atualizar o banco de dados:
   ```sh
   dotnet ef database update
   ```
6. Inicie a aplicação:
   ```sh
   dotnet run
   ```
  
### 2. Realizar Testes
	
Para executar testes unitários e de integração, utilize o comando abaixo:
   ```sh
   dotnet test
   ```

## Tecnologias Usadas
   As principais tecnologias, frameworks e bibliotecas utilizadas no desenvolvimento da API incluem:
- [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/): Linguagem de programação utilizada no ambiente .NET Core.
- [.NET Core](https://dotnet.microsoft.com/): Plataforma de desenvolvimento para construção de aplicativos em C#.
- [Entity Framework Core](https://docs.microsoft.com/pt-br/ef/core/): ORM (Object-Relational Mapper) para acesso e manipulação de dados no banco de dados.
- [xUnit](https://xunit.net/): Framework de testes para testes unitários em .NET Core.
- [SonarCloud](https://sonarcloud.io/): Plataforma de análise estática de código para detecção de problemas de qualidade.
- [Swagger](https://swagger.io/): Ferramenta para criação da documentação da API, facilitando a visualização e interação com os endpoints.

## Código Fonte
   O código fonte do projeto está disponível no repositório GitHub [Pipeline CSharp](https://github.com/Frederico-dos-Santos/pipeline-csharp). Para clonar, utilize o seguinte comando:
   ```sh
   git clone https://github.com/Frederico-dos-Santos/pipeline-csharp
   ```

# Documentação de Testes

## Testes Unitários
- **Framework:** xUnit.net
- **Objetivo:** Garantir que cada componente individual da aplicação funcione corretamente isoladamente.
- **Tecnologia Utilizada:** Microsoft.AspNetCore.Mvc.Testing para simulação do ambiente de hospedagem da API.

## Testes de Integração
- **Framework:** xUnit.net com WebApplicationFactory<Startup>
- **Objetivo:** Verificar a interação entre diferentes componentes da aplicação.
- **Tecnologia Utilizada:** Microsoft.AspNetCore.Mvc.Testing para simular o ambiente de hospedagem da API.

## Análise de Código com SonarQube
- **Objetivo:** Identificar e corrigir potenciais problemas de qualidade de código.
- **Ferramenta Utilizada:** SonarQube para análise estática de código.

## Smoke Tests
- **Objetivo:** Verificar se as funcionalidades principais da aplicação estão operacionais.
- **Implementação:** Utilização de testes rápidos para validar operações básicas da aplicação.
- **Tecnologia Utilizada:** xUnit.net com WebApplicationFactory<Startup> para criar clientes HTTP simulados.

## Testes de Aceitação
- **Objetivo:** Validar se a aplicação atende aos requisitos funcionais e não funcionais especificados pelo usuário final.
- **Implementação:** Utilização de xUnit.net com WebApplicationFactory<Startup> para realizar requisições HTTP simuladas aos endpoints da API.

# Análise de Código com SonarCloud

## Integração na Pipeline
Utilizamos o SonarCloud como parte integrante da nossa pipeline de integração contínua para realizar análises estáticas do código-fonte. O SonarCloud nos ajuda a identificar e corrigir problemas de qualidade de código, como bugs, vulnerabilidades, códigos duplicados, entre outros. Isso contribui significativamente para melhorar a segurança, confiabilidade e manutenibilidade do nosso software.

## Contribuição
Leia o arquivo [CONTRIBUTING.md](CONTRIBUTING.md) para saber detalhes sobre o nosso código de conduta e o processo de envio de solicitações `pull` (*Pull Request*) para nós.

## Autores
- [Frederico dos Santos](https://github.com/Frederico-dos-Santos/pipeline-csharp)

## Licença
Este projeto está licenciado sob a Licença MIT,  consulte o arquivo [LICENSE.md](LICENSE.md) para mais detalhes.
