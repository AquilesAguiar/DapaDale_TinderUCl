using System;
using System.IO;

namespace DapaDale_TinderUCl
{
    public class controleMenus
    {
        public static string bemVindo(){
            return @"___________________________________________________________
                                                Tinder UCL <3
                     ___________________________________________________________


            ";
        }

        public static bool Logar(string Usu, string Senha){
            String line;
            string[] dados;
            try
            {
                StreamReader sr = new StreamReader("database\\Usuarios.csv");
                line = sr.ReadLine();
                while (line != null)
                {   
                    dados = line.Split(',');
                    if (dados[0] == Usu && dados[7] == Senha)
                    {   
                        return true;
                    }
                    
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.WriteLine("Não Logou");
                return false;
            }
            catch(Exception)
            {
                Console.WriteLine("Não Logado");
                return false;
            }
            
        }
    }
}