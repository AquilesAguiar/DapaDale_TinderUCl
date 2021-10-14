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
                                Descriçao:{user.Descricao}
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

        public static void recomendacao(string Usu, string Senha,List<Usuario> Usuarios){
            string rua,bairro,estado;
            string[] interesses = new string[4];
            foreach (Usuario user in Usuarios)
            {
                if (user.Nome == Usu && user.Senha == Senha)
                { 
                    rua = user.Endereco.logradouro;
                    bairro = user.Endereco.bairro;
                    estado = user.Endereco.uf;

                    interesses[0] = user.interessesUser[0] ;
                    interesses[1] = user.interessesUser[1] ;
                    interesses[2] = user.interessesUser[2] ;
                    interesses[3] = user.interessesUser[3] ;
                }   
            }
                
            foreach (Usuario user in Usuarios)
            {
                int cont = 0;   
                if (user.Nome != Usu && user.Senha != Senha)
                {
                    if(user.Endereco.logradouro == rua){
                        cont++;
                    }
                    if(user.Endereco.bairro == bairro){
                        cont++;
                    }
                    if(user.Endereco.uf == estado){
                        cont++;
                    }

                    if(interesses[0] == user.interessesUser[0]){
                        cont++;
                    }
                    if(interesses[1] == user.interessesUser[1]){
                        cont++;
                    }
                    
                    if(interesses[2] == user.interessesUser[2]){
                        cont++;
                    }
                    
                    if(interesses[3] == user.interessesUser[3]){
                        cont++;
                    }

                }
            }
        }
        public static void darLikes(string Usu, string Senha,List<Usuario> Usuarios){
            while(true){
                double x1, x2, y1, y2;
                x1 = 12d;
                x2 = 13d;
                y1 = 11d;
                y2 = 10d;
                var distance = Math.Sqrt((Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)));
                Console.WriteLine(distance);
            }
        }
        
        
    }
}