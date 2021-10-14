using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
namespace DapaDale_TinderUCl
{
    public static class controleUsers
    {   

        public static void serializar(Usuario user){
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(user, options);
            StreamWriter x = File.AppendText("database\\users.txt");
            x.WriteLine(jsonString);
            x.WriteLine(';');
            x.Close();
        }
        public static List<Usuario> deserializar(){
            List<Usuario> Usuarios = new List<Usuario>();
            string jsonString = "";
            int cont=0;
            StreamReader R = File.OpenText("database\\users.txt");
             
            while (R.EndOfStream != true)                            
            {
                string linha = R.ReadLine(); 
                if (linha != ";"){
                    jsonString+=linha;
                }
                else
                {   
                    Usuario users = JsonSerializer.Deserialize<Usuario>(jsonString);
                    Usuarios.Add(users);
                    jsonString = "";
                }
                cont++;
            }
            R.Close();

            
            return Usuarios;
        }


        public static bool Logar(string Usu, string Senha,List<Usuario> Usuarios){
            try
            {
                foreach (Usuario user in Usuarios){
                    if (user.Nome == Usu && user.Senha == Senha)
                    {   
                        return true;
                    }
                }
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