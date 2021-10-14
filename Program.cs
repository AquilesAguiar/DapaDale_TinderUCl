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

                        Console.Write("Data de Nascimento >> ");
                        string dataNas = Console.ReadLine();

                        Console.Write("Celular >> ");
                        string cel = Console.ReadLine();

                        Console.Write("Cep >> ");
                        string cep = Console.ReadLine();

                        Console.Write("Senha >> ");
                        string senha = Console.ReadLine();

                        Console.Write("Rg >> ");
                        string rg = Console.ReadLine();

                        Console.Write("Link da Foto >> ");
                        string foto = Console.ReadLine();
                        
                        Usuario user = new Usuario(nome, rg, cel,  cep,  senha,  dataNas, foto, false);


                        user.isVerificado();
                        if (user.VerificaData()){
                            //Escreve no TXT
                            try
                            {
                                controleUsers.serializar(user);
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine("Exceção: " + e.Message);
                            }
                            finally
                            {
                                Console.WriteLine("Usuario Criado!!");
                            }
                            break;
                        }
                        Console.WriteLine("Usuario menor de 18 anos !!");
                        break;

                    case "2":
                        //Logar
                        Console.Write("Usuario >> ");
                        string usu = Console.ReadLine();

                        Console.Write("Senha >> ");
                        string password = Console.ReadLine();
                        List<Usuario> usuariosBanco = controleUsers.deserializar();
                        if(controleUsers.Logar(usu,password,usuariosBanco)){
                            Console.WriteLine("Entrou!");
                        }
                        break;
                    case "3":
                        //Sair
                        Console.WriteLine("Saindo....");
                        Environment.Exit(0);
                        break;
                    
                    default:
                        break;
                }

            }
            
        }
    }
}
