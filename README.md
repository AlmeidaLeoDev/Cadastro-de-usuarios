# Cadastro-de-usuarios

### Cadastro de Usuários
Este é um programa de cadastro de usuários que permite adicionar informações pessoais, como nome, data de nascimento, rua e número da casa. Os dados cadastrados são armazenados em um arquivo de texto.

### Funcionalidades
O programa oferece as seguintes funcionalidades:

Cadastro de novo usuário: Permite inserir os dados pessoais de um novo usuário, como nome, data de nascimento, rua e número da casa.
Gravação de dados: Salva os dados cadastrados em um arquivo de texto.
Carregamento de dados: Carrega os dados cadastrados previamente a partir de um arquivo de texto.
Encerramento do programa: Permite sair do programa.
Uso do programa
Ao executar o programa, você será apresentado a um menu com as seguintes opções:

Digite "C" para cadastrar um novo usuário.
Digite "S" para encerrar o programa.
Caso escolha a opção de cadastrar um novo usuário, você será solicitado a inserir as informações pessoais do usuário, como nome, data de nascimento, rua e número da casa. Os dados serão validados e adicionados à lista de usuários cadastrados. Em seguida, os dados serão gravados em um arquivo de texto.

### Arquivo de Dados
O programa utiliza um arquivo de texto chamado "baseDeDados.txt" para armazenar os dados cadastrados. Cada usuário é delimitado por marcadores de início e fim, e cada campo do usuário possui uma tag correspondente.

### Observações
O programa trata exceções que possam ocorrer durante o cadastro, gravação e leitura de dados, exibindo as mensagens de erro correspondentes.
O programa utiliza as classes e métodos da biblioteca System.IO para manipulação de arquivos.
O programa utiliza estruturas (struct) para representar os dados cadastrais de cada usuário.
O programa utiliza uma enumeração (enum) para definir os resultados possíveis ao interagir com o programa.
O programa utiliza métodos auxiliares para simplificar a interação com o usuário e tratar a entrada de dados.
O programa utiliza a classe List<T> para armazenar os usuários cadastrados.

