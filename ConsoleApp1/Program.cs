﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_de_Usuarios
{
    internal class Program
    {
        struct DadosCadastrais_Struct
        {
            public string Nome;
            public string NomeDaRua;
            public UInt32 NumeroDaCasa;
            public string NumeroDoDocumento;
        }
        static void Main(string[] args)
        {
            //A lista vai armazenar os dados de todos os usuários que serão cadastrados no programa
            List<DadosCadastrais_Struct> ListaDeCadastros = new List<DadosCadastrais_Struct>();
            string opcao;
            do
            {
                Console.WriteLine("Digite C para cadastrar um novo usuário ou S para sair");
                opcao = Console.ReadKey(true).KeyChar.ToString().ToLower();
                if(opcao == "c")
                {
                    //Cadastrar um novo usuário
                    DadosCadastrais_Struct dadosCadastrais;
                    Console.WriteLine("Digite o nome completo: ");
                    dadosCadastrais.Nome = Console.ReadLine();
                    Console.WriteLine("Digite o nome da rua: ");
                    dadosCadastrais.NomeDaRua = Console.ReadLine();
                    Console.WriteLine("Digite o número da casa: ");
                    dadosCadastrais.NumeroDaCasa = Convert.ToUInt32(Console.ReadLine());
                    Console.WriteLine("Digite o número do documento: ");
                    dadosCadastrais.NumeroDoDocumento = Console.ReadLine();
                    //Tudo que foi digitado anteriormente vai ser salvo na nossa List
                    ListaDeCadastros.Add(dadosCadastrais);
                    Console.Clear();
                }
                else if(opcao == "s")
                {
                    //Encerrar a aplicação
                    Console.WriteLine("Encerrando a aplicação");
                }
                else
                {
                    //Opção desconhecida
                    Console.WriteLine("Opção não desconhecida");
                }
            } while (opcao != "s") ;

            Console.WriteLine("Pressione qualquer tecla para sair");
            Console.ReadKey();
        }
    }
}
