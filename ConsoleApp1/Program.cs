using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_de_Usuarios
{
    internal class Program
    {
        //struct
       
        public struct DadosCadastraisStruct 
        {
            public string Nome;
            public DateTime DataDeNascimento;
            public string NomeDaRua;
            public UInt32 NumeroDaCasa;
        }

        //enum
        public enum Resultado_e
        {
            Sucesso = 0,
            Sair = 1,
            Excecao = 2
        }
        
        //Métodos
        public static void MostraMensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.ReadLine();
            Console.Clear();
        }

        public static Resultado_e PegaString(ref string minhaString, string mensagem)
        {
            Resultado_e retorno;
            Console.WriteLine(mensagem);
            string temp = Console.ReadLine();
            if(temp == "s")
            {
                retorno = Resultado_e.Sair;
            }
            else
            {
                minhaString = temp;
                retorno = Resultado_e.Sucesso;
            }
            Console.Clear();
            return retorno;
        }

        public static Resultado_e PegaData(ref DateTime minhaData, string mensagem)
        {
            Resultado_e retorno;
            do
            {
                try
                {
                    Console.WriteLine(mensagem); //Escreva sua data ou S
                    string temp = Console.ReadLine();
                    if(temp == "s")
                    {
                        Console.WriteLine("Encerrando o programa");
                        retorno = Resultado_e.Sair;
                    }
                    else
                    {
                        minhaData = Convert.ToDateTime(temp); 
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("EXCEÇÃO: " + e.Message);
                    Console.WriteLine("Pressione qualquer tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    retorno = Resultado_e.Excecao;
                }
            } while (retorno == Resultado_e.Excecao);
                Console.Clear();
                return retorno;  
        }

        public static Resultado_e PegaUInt32(ref UInt32 numeroUInt32, string mensagem)
        {
            Resultado_e retorno;
            do
            {
                try
                {
                    Console.WriteLine(mensagem);
                    string temp = Console.ReadLine();
                    if (temp == "s")
                    {
                        Console.WriteLine("Encerrando o programa");
                        retorno = Resultado_e.Sair;
                    }
                    else
                    {
                        numeroUInt32 = Convert.ToUInt32(temp);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("EXCEÇÃO: " + e.Message);
                    Console.WriteLine("Pressione qualquer tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    retorno = Resultado_e.Excecao;
                }
            } while (retorno == Resultado_e.Excecao);
            Console.Clear();
            return retorno;
        }

        public static void CadastraUsuario(ref List<DadosCadastraisStruct> ListaDeUsuarios)
        {
            DadosCadastraisStruct CadastroUsuario;
            CadastroUsuario.Nome = "";
            CadastroUsuario.DataDeNascimento = new DateTime();
            CadastroUsuario.NomeDaRua = "";
            CadastroUsuario.NumeroDaCasa = 0;

            if (PegaString(ref CadastroUsuario.Nome, "Digite o nome completo ou pressione S para sair") != Resultado_e.Sucesso)
                return;
            if (PegaData(ref CadastroUsuario.DataDeNascimento, "Digite a sua data de nascimento no formato DD/MM/AAAA ou pressione S para sair") != Resultado_e.Sucesso)
                return;
            if (PegaString(ref CadastroUsuario.NomeDaRua, "Digite o nome da rua ou pressione S para sair") != Resultado_e.Sucesso)
                return;
            if (PegaUInt32(ref CadastroUsuario.NumeroDaCasa, "Digite o número da casa ou pressione S para sair") != Resultado_e.Sucesso)
                return;
            ListaDeUsuarios.Add(CadastroUsuario); 
        }

        //Main
        static void Main(string[] args)
        {
            List<DadosCadastraisStruct> ListaDeUsuarios = new List<DadosCadastraisStruct>();
            string opcao = "";
            do
            {
                Console.WriteLine("Digite C para cadastrar um novo usuário ou S para encerrar o programa");
                opcao = Console.ReadKey().KeyChar.ToString().ToLower();
                if (opcao == "c")
                {
                    //Cadastrar um novo usuário
                    CadastraUsuario(ref ListaDeUsuarios); 
                }
                else if (opcao == "s")
                {
                    //Encerrar o programa
                    MostraMensagem("Encerrando o programa");
                }
                else
                {
                    //Opção desconhecida
                    MostraMensagem("Opção desconhecida");
                }
            } while (opcao != "s");
            Console.WriteLine("Encerrando o programa");
            Console.ReadKey();
        }
    }
}
