using System;
using System.IO;
using System.Collections.Generic;

namespace DapaDale_TinderUCl
{
    class Program
    {
        static void Main(string[] args)
        {   
            
            while (true){
                
                controleMenus.bemVindo();
                string sentinela = Console.ReadLine();

                switch(sentinela){

                    case "1":
                        //Cadastrar-se
                        Console.Write("Nome >> ");
                        string nome = Console.ReadLine();

                        while(nome == ""){
                            Console.WriteLine("O campo nome deve ser preenchido.");
                            Console.Write("Nome >> ");
                            nome = Console.ReadLine();
                        }

                        Console.Write("Descrição >> ");
                        string descricao = Console.ReadLine();

                        Console.Write("Data de Nascimento >> ");
                        string dataNas = Console.ReadLine();

                        while(dataNas == ""){
                            Console.WriteLine("O campo Data de Nascimento deve ser preenchido.");
                            Console.Write("Data de Nascimento >> ");
                            dataNas = Console.ReadLine();
                        }

                        Console.Write("Celular >> ");
                        string cel = Console.ReadLine();

                        Console.Write("Cep >> ");
                        string cep = Console.ReadLine();

                        while(cep == ""){
                            Console.WriteLine("O campo Cep deve ser preenchido.");
                            Console.Write("Cep >> ");
                            cep = Console.ReadLine();
                        }

                        Console.Write("Senha >> ");
                        string senha = Console.ReadLine();

                        while(senha == ""){
                            Console.WriteLine("O campo Senha deve ser preenchido.");
                            Console.Write("Senha >> ");
                            senha = Console.ReadLine();
                        }

                        Console.Write("Rg >> ");
                        string rg = Console.ReadLine();

                        Console.Write("Link da Foto >> ");
                        string foto = Console.ReadLine();
                        
                        Console.WriteLine("\n\n");
                        List<string> listaInteresses = new List<string>();

                        Usuario user = new Usuario(nome, descricao, rg, cel,  cep,  senha,  dataNas, foto, false,Cadastro.escolherInteresses(listaInteresses));
                        
                        // Verifica usuario
                        user.isVerificado();

                        if (user.VerificaData()){
                            //Serializa a classe
                            try
                            {   
                                controleUsers.serializar(user);
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine("Exceção: " + e.Message);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            finally
                            {
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine("Usuario Criado!!");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Usuario menor de 18 anos !!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "2":
                        //Logar
                        Console.Clear();
                        Console.Write("Usuario >> ");
                        string usu = Console.ReadLine();

                        Console.Write("Senha >> ");
                        string password = Console.ReadLine();
                        List<Usuario> usuariosBanco = controleUsers.deserializar();
                        if(controleUsers.Logar(usu,password,usuariosBanco)){
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Entrou!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();
                            Console.Clear();
                            controleMenus.comandos(usu,password,usuariosBanco);
                        }
                        break;
                    case "3":
                        //Sair
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Saindo....");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey();
                        Console.Clear();
                        Environment.Exit(0);
                        
                        break;

                    
                    default:
                        //Comando Inválido 
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Comando Inválido");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }

            }
            
        }
    }
}
