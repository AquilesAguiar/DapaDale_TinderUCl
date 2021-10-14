using System;
using System.IO;

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

        

        string msgComandos = @"___________________________________________________________________________________________________________________________________________
                                1 - Dar likes
                                2 - Ver Matchs
                                3 - Ver perfil
                                4 - Ver Interesses
___________________________________________________________________________________________________________________________________________
        
        ";      
        public static void comandos(){
            while(true){
                            
            }
        }
        
        
    }
}