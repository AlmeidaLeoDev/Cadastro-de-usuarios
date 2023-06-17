using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Cadastro_de_Usuarios
{
    internal class Program
    {
        static string delimitadorInicio;
        static string delimitadorFim;
        static string tagNome;
        static string tagDataDeNascimento;
        static string tagNomeDaRua;
        static string tagNumeroDaCasa;

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
            if (temp == "s")
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
                    if (temp == "s")
                    {
                        Console.WriteLine("Encerrando o programa");
                        retorno = Resultado_e.Sair;
                    }
                    else
                    {
                        minhaData = Convert.ToDateTime(temp);
                        retorno = Resultado_e.Sucesso;
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
                        retorno = Resultado_e.Sucesso;
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

        public static Resultado_e CadastraUsuario(ref List<DadosCadastraisStruct> ListaDeUsuarios)
        {
            DadosCadastraisStruct CadastroUsuario;
            CadastroUsuario.Nome = "";
            CadastroUsuario.DataDeNascimento = new DateTime();
            CadastroUsuario.NomeDaRua = "";
            CadastroUsuario.NumeroDaCasa = 0;

            if (PegaString(ref CadastroUsuario.Nome, "Digite o nome completo ou pressione S para sair") == Resultado_e.Sair)
                return Resultado_e.Sair;
            if (PegaData(ref CadastroUsuario.DataDeNascimento, "Digite a sua data de nascimento no formato DD/MM/AAAA ou pressione S para sair") == Resultado_e.Sair)
                return Resultado_e.Sair;
            if (PegaString(ref CadastroUsuario.NomeDaRua, "Digite o nome da rua ou pressione S para sair") == Resultado_e.Sair)
                return Resultado_e.Sair;
            if (PegaUInt32(ref CadastroUsuario.NumeroDaCasa, "Digite o número da casa ou pressione S para sair") == Resultado_e.Sair)
                return Resultado_e.Sair;
            ListaDeUsuarios.Add(CadastroUsuario);
            return Resultado_e.Sucesso;
        }

        public static void GravaDados(string caminho, List<DadosCadastraisStruct> ListaDeUsuarios)
        {
            try
            {
                string conteudoArquivo = "";
                foreach(DadosCadastraisStruct cadastro in ListaDeUsuarios)
                {
                    conteudoArquivo += delimitadorInicio + "\r\n";
                    conteudoArquivo += tagNome + cadastro.Nome + "\r\n";
                    conteudoArquivo += tagDataDeNascimento + cadastro.DataDeNascimento.ToString("dd/mm/aaaa") + "\r\n";
                    conteudoArquivo += tagNomeDaRua + cadastro.NomeDaRua + "\r\n";
                    conteudoArquivo += tagNumeroDaCasa + cadastro.NumeroDaCasa + "\r\n";
                    conteudoArquivo += delimitadorFim + "\r\n";
                }
                File.WriteAllText(caminho, conteudoArquivo);
            }
            catch(Exception e)
            {
                Console.WriteLine("EXCEÇÃO: " + e.Message);
            }
        }

        public static void CarregaDados(string caminho, ref List<DadosCadastraisStruct> ListaDeUsuarios)
        {
            try
            {
                if(File.Exists(caminho))
                {
                    string [] conteudoArquivo = File.ReadAllLines(caminho);
                    DadosCadastraisStruct dadosCadastrais;
                    dadosCadastrais.Nome = "";
                    dadosCadastrais.DataDeNascimento = new DateTime();
                    dadosCadastrais.NomeDaRua = "";
                    dadosCadastrais.NumeroDaCasa = 0;

                    foreach (string linha in conteudoArquivo)
                    {
                        if (linha.Contains(delimitadorInicio))
                            continue;
                        if (linha.Contains(delimitadorFim))
                            ListaDeUsuarios.Add(dadosCadastrais);
                        if (linha.Contains(tagNome))
                            dadosCadastrais.Nome = linha.Replace(tagNome, "");
                        if (linha.Contains(tagDataDeNascimento))
                            dadosCadastrais.DataDeNascimento = Convert.ToDateTime(linha.Replace(tagDataDeNascimento, ""));
                        if (linha.Contains(tagNomeDaRua))
                            dadosCadastrais.NomeDaRua = linha.Replace(tagNomeDaRua, "");
                        if (linha.Contains(tagNumeroDaCasa))
                            Convert.ToUInt32(linha.Replace(tagNumeroDaCasa, ""));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("EXCEÇÃO: " + e.Message);
            }
        }

        //Main
        static void Main(string[] args)
        {
            List<DadosCadastraisStruct> ListaDeUsuarios = new List<DadosCadastraisStruct>();
            string opcao = "";
            string caminhoArquivo = @"baseDeDados.txt";

            CarregaDados(caminhoArquivo, ref ListaDeUsuarios);

            delimitadorInicio = "##### INÍCIO #####";
            delimitadorFim = "##### FIM #####";
            tagNome = "NOME: ";
            tagDataDeNascimento = "DATA_DE_NASCIMENTO: ";
            tagNomeDaRua = "NOME_DA_RUA: ";
            tagNumeroDaCasa = "NÚMERO_DA_CASA: ";

            do
            {
                Console.WriteLine("Digite C para cadastrar um novo usuário ou S para encerrar o programa");
                opcao = Console.ReadKey(true).KeyChar.ToString().ToLower();
                if (opcao == "c")
                {
                    //Cadastrar um novo usuário
                    if (CadastraUsuario(ref ListaDeUsuarios) == Resultado_e.Sucesso)
                        GravaDados(caminhoArquivo, ListaDeUsuarios);
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
