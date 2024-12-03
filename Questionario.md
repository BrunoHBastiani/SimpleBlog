### Explique o conceito de herança múltipla e como C# aborda esse cenário.

Herança múltipla refere-se à capacidade de uma classe herdar propriedades e comportamentos de mais de uma classe. No entanto, em C#, não é possível herdar de múltiplas classes diretamente.
Apesar da limitação, o C# oferece alternativas eficientes para alcançar resultados semelhantes:

1. **Uso de Interfaces**  
   Uma classe pode implementar múltiplas interfaces, permitindo que adote contratos e comportamentos definidos por várias fontes diferentes. Interfaces funcionam como "esqueletos" que as classes podem preencher, sendo uma maneira limpa de organizar o código.

2. **Combinação de Classe e Interfaces**  
   Uma classe pode herdar de uma única classe base e, simultaneamente, implementar várias interfaces. Isso permite que a classe combine a funcionalidade herdada com a flexibilidade de diferentes contratos, semelhante ao conceito de herdar múltiplas classes abstratas.

### Explique o polimorfismo em C# e forneça um exemplo prático de como ele pode ser implementado.

O polimorfismo permite que objetos de diferentes classes implementem o mesmo método de formas distintas, tornando o código mais flexível e reutilizável.

Exemplo:

```csharp
using System;

class Animal {
    public virtual void FazerSom() {
        Console.WriteLine("Som de animal");
    }
}

class Cachorro : Animal {
    public override void FazerSom() {
        Console.WriteLine("Au Au");
    }
}

class Program {
    static void Main() {
        Animal animal = new Cachorro();
        animal.FazerSom(); // Output: Au Au
    }
}
```

### Benefícios das Alternativas
Essas abordagens evitam problemas comuns associados à herança múltipla, como o **Diamond Problem**, enquanto ainda permitem flexibilidade e reutilização de código de maneira eficiente e organizada.


### Descreva o princípio da Responsabilidade Única (SRP) e como ele se aplica em um contexto de desenvolvimento C#.

O Princípio da Responsabilidade Única (SRP) afirma que um módulo ou classe deve ter apenas um motivo para ser alterado, ou seja, ele deve ser responsável por uma única tarefa ou preocupação específica dentro do sistema.

Por exemplo:

Uma classe relacionada a Clientes deve lidar apenas com características e ações específicas de clientes, como cadastro, atualização e consulta de informações.
O envio de e-mails, por outro lado, deve ser responsabilidade de uma classe separada, como um EmailService, que lida exclusivamente com operações de envio.
Ao aplicar o SRP no desenvolvimento em C#, garantimos que as classes são coesas, fáceis de entender, testar e manter. Além disso, mudanças em um aspecto do sistema afetam apenas as partes relacionadas, reduzindo o impacto no restante do código.

### Como o princípio da inversão de dependência (DIP) pode ser aplicado em um projeto C# e como isso beneficia a manutenção do código?

O Princípio da Inversão de Dependência (DIP) estabelece que módulos de alto nível não devem depender diretamente de implementações concretas, mas sim de abstrações, como interfaces ou classes abstratas. Em C#, esse princípio é aplicado criando essas abstrações para definir os contratos que descrevem os comportamentos esperados. As implementações concretas ficam responsáveis por atender a esses contratos, enquanto os módulos de alto nível interagem apenas com as abstrações.

A inversão ocorre porque os detalhes passam a depender das abstrações, e não o contrário. Para conectar essas partes no código, utilizamos a Injeção de Dependência (DI), um padrão que permite fornecer as implementações corretas às abstrações esperadas. Isso torna o código mais flexível e fácil de manter, já que mudanças ou substituições em implementações concretas não afetam os módulos de alto nível. Além disso, melhora significativamente a testabilidade do sistema, já que é possível usar mocks para simular as abstrações nas implementações dos testes.

### Como o Entity Framework gerencia o mapeamento de objetos para o banco de dados e vice-versa?

O Entity Framework (EF) permite que você trabalhe com classes C# como representações das tabelas do banco de dados, convertendo as alterações nessas classes em comandos SQL por meio de migrations criadas com o comando dotnet ef migrations add NomeDaMigration).

Esses comandos SQL podem ser executados para aplicar as alterações no banco de dados utilizando o comando dotnet ef database update.

Cada vez que uma alteração é feita nas classes, uma nova migration pode ser gerada, criando um versionamento do banco de dados. Isso também possibilita reverter a alterações anteriores, caso necessário, utilizando o comando dotnet ef database update NomeExatoDaMigrationDesejada.

### Como otimizar consultas no Entity Framework para garantir um desempenho eficiente em grandes conjuntos de dados?

Para otimizar consultas no Entity Framework, é importante seguir essas práticas:

* *Selecionar só os campos necessários no SELECT:* Evitar trazer mais dados do que o necessário.
* *Adicionar índices no banco:* Melhorar a performance das consultas, especialmente nas colunas usadas em filtros e ordenações.
* *Usar consultas assíncronas:* Evita travar a aplicação enquanto o banco responde.
* *Analisar a consulta gerada:* Usar o ToQueryString associado a ferramentas como o EXPLAIN (ou equivalente) para ver onde está o gargalo.
* *Usar Include só quando realmente precisar:* Para evitar sobrecarregar a consulta ou fazer múltiplas chamadas ao banco.
* *Usar AsNoTracking para leitura:* Quando não for alterar os dados, desativar o rastreamento economiza memória e processamento.
* *Paginar ou dividir em blocos:* Processar os dados em partes menores em vez de trazer tudo de uma vez.
* *Criar consultas manuais com ExecuteSqlRaw:* Para personalizar ao máximo quando necessário.

### Explique o papel dos WebSockets em uma aplicação C# e como eles se comparam às solicitações HTTP tradicionais.

Os WebSockets são usados para criar uma comunicação em tempo real, contínua e bidirecional entre cliente e servidor. Diferente do HTTP tradicional, que segue o modelo de requisição/resposta, os WebSockets permitem que tanto o cliente quanto o servidor enviem mensagens a qualquer momento, sem precisar abrir uma nova conexão para cada troca de dados.

Em uma aplicação C#, os WebSockets são usados para cenários onde a troca de informações em tempo real é essencial. Alguns exemplos:

* *Chats:* O servidor pode enviar mensagens para os usuários assim que elas chegam.
* *Notificações push:* Atualizações em tempo real, como alertas ou informações dinâmicas.
* *Dashboards ao vivo:* Atualizar gráficos ou dados continuamente sem recarregar a página.
* *Jogos online:* Sincronizar estados de jogo entre os jogadores e o servidor.

O WebSocket mantém uma conexão aberta e persistente. Isso reduz a latência e economiza recursos de rede, porque não há necessidade de abrir e fechar conexões a todo momento.

### Quais são as principais considerações de segurança ao implementar uma comunicação baseada em WebSockets em uma aplicação C#?

Dentre as principais considerações de segurança ao implementar uma comunicação baseada em WebSockets, temos:

* *Usar WSS:* Sempre utilize WebSocket Secure (WSS) para garantir criptografia dos dados.
* *Autenticação e Autorização:* Valide usuários antes de aceitar conexões WebSocket e verifique permissões.
* *Verificar o cabeçalho Origin:* Proteja contra ataques de Cross-Site WebSocket Hijacking.
* *Timeout e Limitação de Dados:* Defina tempo limite para conexões e limite o tamanho das mensagens.
* *Validar e Sanitizar Dados:* Sempre valide e sanitize os dados recebidos para evitar injeções e outros possíveis ataques.
* *Monitoramento:* Registre e monitore as conexões para detectar comportamentos suspeitos.
* *Proteger contra DDoS:* Use rate limiting e limite o número de conexões simultâneas.

### Descreva a diferença entre arquitetura monolítica e arquitetura de microsserviços. Qual seria sua escolha ao projetar uma aplicação C# e Como você escolheria entre a arquitetura de microsserviços e a arquitetura monolítica ao projetar uma aplicação C# que precisa ser altamente escalável?

A **arquitetura monolítica** centraliza toda a infraestrutura e código em uma única solução, onde todos os componentes do sistema estão interligados e dependem uns dos outros.
Já a **arquitetura de microsserviços** envolve a divisão do sistema em serviços independentes, que podem ser desenvolvidos, implantados e escalados separadamente. Esses microsserviços se comunicam entre si por meio de APIs, gRPC ou mensageria, e geralmente são organizados com base no conceito de *bounded context*.

### Escolha para Projetar uma Aplicação em C#

A escolha entre uma arquitetura monolítica e uma arquitetura de microsserviços depende muito do cenário específico. 
Se o sistema tiver regras de negócio complexas e extensas, e o tamanho da aplicação for grande, a arquitetura de microsserviços pode ser mais vantajosa devido a algumas características:

- **Tecnologias diversificadas:** Cada microsserviço pode ser desenvolvido utilizando a tecnologia mais adequada ao seu contexto, permitindo flexibilidade.
- **Eficiência na organização das equipes:** Equipes podem ser alocadas de maneira mais eficiente, cada uma cuidando de um conjunto de microsserviços com responsabilidades bem definidas.
- **Escalabilidade do trabalho:** O desenvolvimento de microsserviços menores permite que os times se concentrem em códigos mais objetivos, facilitando a manutenção e evolução do sistema.

No entanto, para sistemas menores ou quando a complexidade não justifica, a **arquitetura monolítica** pode ser uma escolha melhor devido a alguns fatores:

- **Curva de aprendizado reduzida:** A arquitetura monolítica é amplamente utilizada e mais fácil de aprender, enquanto microsserviços exigem familiaridade com uma gama maior de ferramentas, técnicas e conceitos.
- **Menos sobrecarga operacional:** Em um sistema monolítico, a gestão e a implantação são mais simples, pois todo o código está em um único projeto.

Em resumo, escolher entre essas duas arquiteturas depende do tamanho, complexidade e necessidades do sistema, com os microsserviços sendo ideais para sistemas grandes e complexos, e a arquitetura monolítica sendo mais adequada para sistemas menores e mais simples.
