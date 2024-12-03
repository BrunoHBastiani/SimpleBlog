# Guia de Execução do Projeto SimpleBlog

### Requisitos para Executar no Windows

- [Visual Studio - Download](https://visualstudio.microsoft.com/pt-br/downloads/)
- [Git para Windows - Download](https://git-scm.com/download/win)

### Como Executar o Projeto

1. Escolha um diretório de sua preferência e clone o repositório:
   ```
   git clone https://github.com/BrunoHBastiani/SimpleBlog.git
   ```
2. Abra a solução no Visual Studio.
3. Execute o projeto normalmente.

### Decisões de Implementação

- **Banco de Dados In-Memory**: Utilizado para simplificar a execução do projeto e acelerar o desenvolvimento.
- **SignalR**: Escolhido para implementar WebSockets devido à sua eficiência e ampla adoção no mercado.

### Descrição do Sistema

O projeto consiste em:

1. **API de Usuários**:
   - Permite criar contas e realizar autenticação.

2. **API de Postagens do Blog**:
   - Usuários logados podem criar, editar ou excluir postagens.
   - Usuários não autenticados podem apenas visualizar postagens.

3. **Notificações em Tempo Real**:
   - Ao criar uma nova postagem, todos os clientes conectados ao WebSocket recebem uma notificação.

### Pontos de Melhoria

Com mais tempo, algumas melhorias poderiam ser implementadas:

1. **Banco de Dados Dockerizado**:
   - Substituir o banco In-Memory por um SGBD containerizado, facilitando a análise dos dados.

2. **Centralização de Exceções**:
   - Criar um projeto específico para exceções personalizadas e mensagens de erro, permitindo localização em múltiplos idiomas e eliminação de duplicidade de mensagens.

3. **Assertion Concerns**:
   - Centralizar validações simples e repetitivas em um único local para maior organização.

4. **Domínios Ricos**:
   - Separar melhor as responsabilidades entre a camada de domínio (regras de negócio) e a camada de aplicação (regras específicas do sistema).
