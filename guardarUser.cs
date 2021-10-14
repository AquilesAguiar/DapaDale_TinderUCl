using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
namespace DapaDale_TinderUCl
{
    public static class guardarUser
    {   

        public static void serializar(Usuario user){
            int cont = 0;
            string[] arquivos = Directory.GetFiles("database\\users");
            foreach (string arq in arquivos)
            {
                cont++;
            }
            FileStream fs = new FileStream($"database\\users\\users{cont}.Data", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, user);
            fs.Close();
        }
        public static void deserializar(){
            string[] arquivos = Directory.GetFiles($"database\\users");
            List<Usuario> Usuarios = new List<Usuario>();
            foreach (string arq in arquivos)
            {
                FileStream fs2 = new FileStream($"database\\users\\{arq}", FileMode.Open);
                BinaryFormatter bf2 = new BinaryFormatter();
                Usuario dados;
                dados = (Usuario)bf2.Deserialize(fs2);
                Usuarios.Add(dados);
                fs2.Close();
            }
            return Usuarios;
        }
    }
}