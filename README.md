# Cadastro-de-usuarios
### Cadastro de usuários no Console usando struct, List, Enum e Métodos

1. O código começa com a definição do namespace "Cadastro_de_Usuarios".

2. A classe principal é definida como "Program" e marcada como interna (internal).

3. É definida uma estrutura chamada "DadosCadastraisStruct" que armazena os dados de um usuário, como nome, data de nascimento, nome da rua e número da casa.

4. É definido um enum chamado "Resultado_e" que representa os resultados possíveis das operações do programa, como sucesso, sair ou exceção.

5. São declarados vários métodos no código, que são utilizados para interagir com o usuário e obter os dados do cadastro. Esses métodos incluem "MostraMensagem", 
"PegaString", "PegaData" e "PegaUInt32".

6. O método Main é o ponto de entrada do programa. Ele começa criando uma lista chamada "ListaDeUsuarios" para armazenar os dados dos usuários cadastrados.

7. Em um loop do-while, o programa exibe uma mensagem solicitando ao usuário que digite "C" para cadastrar um novo usuário ou "S" para sair.

8. Se o usuário digitar "C", o método "CadastraUsuario" é chamado. Esse método interage com o usuário para coletar os dados do novo usuário e os adiciona à lista 
"ListaDeUsuarios".

9. Se o usuário digitar "S", o programa exibe uma mensagem de encerramento e sai do loop.

10. Se o usuário digitar qualquer outra coisa, o programa exibe uma mensagem informando que a opção é desconhecida.

11. O loop continua até que o usuário digite "S" para sair, encerrando o programa.

Em resumo, o programa permite que o usuário cadastre novos usuários fornecendo informações como nome, data de nascimento, nome da rua e número da casa. Os dados 
são armazenados em uma lista e o programa continua solicitando novos cadastros até que o usuário escolha sair.
