using System;
using System.Collections.Generic;
using System.Linq;

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
                    Console.ReadKey();
                    Console.Clear();
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
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
            }
        }

        public static Dictionary<Tuple<string,string>, Tuple<int,int>> recomendacao(string Usu, string Senha,List<Usuario> Usuarios){
            string rua = "",bairro = "",estado = "";
            string[] interesses = new string[4];
            Dictionary<Tuple<string,string>, Tuple<int,int>> recomendacoesUsers = new Dictionary<Tuple<string,string>, Tuple<int,int>>();
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
                if (user2.Nome != Usu || user2.Senha != Senha)
                {   
                    if(user2.Endereco.logradouro == rua){
                        cont++;
                    }
                    if(user2.Endereco.bairro == bairro){
                        cont++;
                    }
                    if(user2.Endereco.uf == estado){
                        cont++;
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        if(user2.interessesUser.Contains(interesses[i])){
                            cont2++;
                        };
                    }
                    recomendacoesUsers.Add(new Tuple<string, string>(user2.Nome,user2.Senha), new Tuple<int, int>(cont,cont2));
                }
            }
            return recomendacoesUsers;
        }

        public static Dictionary<Tuple<string,string>, double> calcRecomendacao(string Usu, string Senha,List<Usuario> Usuarios){
            Dictionary<Tuple<string,string>,Tuple<int,int>> recomendacoes = recomendacao(Usu,Senha,Usuarios); 
            Dictionary<Tuple<string,string>, double> distanciaCalc = new Dictionary<Tuple<string,string>, double>();
            
            foreach( KeyValuePair<Tuple<string,string>, Tuple<int,int>> kvp in recomendacoes )
            {

                int x1, x2, y1, y2;
                x1 = 3;
                x2 = kvp.Value.Item1;
                y1 = 4;
                y2 = kvp.Value.Item2;
                
                var distance = Math.Sqrt((Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)));
                distanciaCalc.Add(new Tuple<string, string>(kvp.Key.Item1,kvp.Key.Item2),Math.Round(distance,2));
            }
            var sortedDict = from entry in distanciaCalc orderby entry.Value ascending select entry;
            
            distanciaCalc.Clear();

            foreach( KeyValuePair<Tuple<string,string>, double> kvp in sortedDict )
            {   
                distanciaCalc.Add(new Tuple<string,string>(kvp.Key.Item1,kvp.Key.Item2), kvp.Value);
            }
            return distanciaCalc;
        }
        public static void darLikes(string Usu, string Senha,List<Usuario> Usuarios){
            Dictionary<Tuple<string,string>, double> recomendacoes = calcRecomendacao(Usu,Senha,Usuarios);
            foreach( KeyValuePair<Tuple<string,string>, double> kvp in recomendacoes){
//                 if (user.Nome != Usu && user.Senha != Senha){

//                     Console.WriteLine(@$"___________________________________________________________________________________________________________________________________________
//                             Foto:{user.Foto}
//                             Nome:{user.Nome}
//                             Descriçao:{user.Descricao}
//                             Data de Nascimento:{user.DataNasc}
//                             Rua:{user.Endereco.logradouro}
//                             Bairro:{user.Endereco.bairro}
//                             Estado:{user.Endereco.uf}
// ___________________________________________________________________________________________________________________________________________
//                                     Interessses
//                             1 - {user.interessesUser[0]}
//                             2 - {user.interessesUser[1]}
//                             3 - {user.interessesUser[2]}
//                             4 - {user.interessesUser[3]}
// ___________________________________________________________________________________________________________________________________________");
//                     Console.WriteLine("\n\n");

//                     Console.WriteLine("Dislike(Pressione A) || Like(Pressione D)");
//                     ConsoleKeyInfo situacao = Console.ReadKey();
//                     if(situacao.KeyChar == 'd'){
//                         Console.WriteLine("Gostou!");
//                     }else if( situacao.KeyChar == 'a'){
//                         Console.WriteLine("Não Gostou!");
//                     }
//                 }
            }
        }
        
        
    }
}