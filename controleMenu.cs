using System;
using System.IO;
using System.Collections.Generic;

namespace DapaDale_TinderUCl
{   
    [Serializable]
    public class controleMenus
    {
        public static void bemVindo(){
            Console.WriteLine(@"___________________________________________________________________________________________________________________________________________

                                            Tinder UCL <3
___________________________________________________________________________________________________________________________________________

                     1 - Cadastrar novo usuario
                     2 - Logar com usuario  
                     3 - Sair  
            ");
        }
    
        public static void comandos(string Usu, string Senha,List<Usuario> Usuarios){
            while(true){
                Console.WriteLine(@"___________________________________________________________________________________________________________________________________________
                                1 - Dar likes
                                2 - Ver perfil
                                3 - Ver Interesses
                                4 - Sair
___________________________________________________________________________________________________________________________________________
        
        ");



                string sentinela = Console.ReadLine();

                switch(sentinela){
                    case "1":
                        darLikes(Usu,Senha,Usuarios);
                        break;
                    case "2":
                        verPerfil(Usu,Senha,Usuarios);
                        break;
                    case "3":
                        verInteresses(Usu,Senha,Usuarios);
                        break;
                    case "4":
                        //Sair 
                        Console.WriteLine("Saindo....");
                        Console.ReadKey();
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    
                    default:
                        //Comando Inválido
                        Console.WriteLine("Comando Inválido");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }

        public static void verPerfil(string Usu, string Senha,List<Usuario> Usuarios){
           
            foreach (Usuario user in Usuarios){
                if (user.Nome == Usu && user.Senha == Senha)
                {   
                    Console.WriteLine(@$"___________________________________________________________________________________________________________________________________________
                                Foto:{user.Foto}
                                Nome:{user.Nome}
                                Data de Nascimento:{user.DataNasc}
                                Rua:{user.Endereco.logradouro}
                                Bairro:{user.Endereco.bairro}
                                Estado:{user.Endereco.uf}
___________________________________________________________________________________________________________________________________________");
                    break;
                }
            }
        }

        public static void verInteresses(string Usu, string Senha,List<Usuario> Usuarios){
           
            foreach (Usuario user in Usuarios){
                if (user.Nome == Usu && user.Senha == Senha)
                {   
                    Console.WriteLine(@$"___________________________________________________________________________________________________________________________________________
                                1 - {user.interessesUser[0]}
                                2 - {user.interessesUser[1]}
                                3 - {user.interessesUser[2]}
                                4 - {user.interessesUser[3]}
___________________________________________________________________________________________________________________________________________");
                    break;
                }
            }
        }

        public static void darLikes(string Usu, string Senha,List<Usuario> Usuarios){
            while(true){
                break;
            }
        }
        
        
    }
}