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

        public static Dictionary<string, Tuple<int,int>> recomendacao(string Usu, string Senha,List<Usuario> Usuarios){
            string rua = "",bairro = "",estado = "";
            string[] interesses = new string[4];
            Dictionary<string, Tuple<int,int>> recomendacoesUsers = new Dictionary<string, Tuple<int,int>>();
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
                    break;
                }   
            }
                
            foreach (Usuario user2 in Usuarios)
            {
                int cont = 0;   
                int cont2 = 0;
                if (user2.Nome != Usu && user2.Senha != Senha)
                {   
                    Console.WriteLine(user2.Nome);
                    if(user2.Endereco.logradouro == rua){
                        cont++;
                    }
                    if(user2.Endereco.bairro == bairro){
                        cont++;
                    }
                    if(user2.Endereco.uf == estado){
                        cont++;
                    }

                    if(interesses[0] == user2.interessesUser[0]){
                        cont2++;
                    }
                    if(interesses[1] == user2.interessesUser[1]){
                        cont2++;
                    }
                    
                    if(interesses[2] == user2.interessesUser[2]){
                        cont2++;
                    }
                    
                    if(interesses[3] == user2.interessesUser[3]){
                        cont2++;
                    }

                    recomendacoesUsers.Add(user2.Nome + user2.Senha, new Tuple<int, int>(cont,cont2));
                }
            }
            return recomendacoesUsers;
        }
        public static void darLikes(string Usu, string Senha,List<Usuario> Usuarios){
            Dictionary<string, Tuple<int,int>> recomendacoes = recomendacao(Usu,Senha,Usuarios); 
            foreach( KeyValuePair<string, Tuple<int,int>> kvp in recomendacoes )
            {
                Console.WriteLine("Key = {0}, Value = {1}",kvp.Key, kvp.Value);
            }
            // while(true){
            //     Dictionary<string, Tuple<int,int>> recomendacoes = recomendacao(Usu,Senha,Usuarios); 
            //     foreach( KeyValuePair<string, Tuple<int,int>> kvp in recomendacoes )
            //     {
            //         Console.WriteLine("Key = {0}, Value = {1}",kvp.Key, kvp.Value);
            //     }
                // double x1, x2, y1, y2;
                // x1 = 12d;
                // x2 = 13d;
                // y1 = 11d;
                // y2 = 10d;
                // var distance = Math.Sqrt((Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)));
                // Console.WriteLine(distance);
//                 foreach(Usuario user in Usuarios){
//                     if (user.Nome != Usu && user.Senha != Senha){

//                         Console.WriteLine(@$"___________________________________________________________________________________________________________________________________________
//                                 Foto:{user.Foto}
//                                 Nome:{user.Nome}
//                                 Descriçao:{user.Descricao}
//                                 Data de Nascimento:{user.DataNasc}
//                                 Rua:{user.Endereco.logradouro}
//                                 Bairro:{user.Endereco.bairro}
//                                 Estado:{user.Endereco.uf}
// ___________________________________________________________________________________________________________________________________________");
//                         Console.WriteLine("\n\n");

//                         Console.WriteLine("Like(Seta para direita) e Dislike(Seta para esquerda)");
//                         if()
//                     }
//                 }
                    
        

            // }
        }
        
        
    }
}