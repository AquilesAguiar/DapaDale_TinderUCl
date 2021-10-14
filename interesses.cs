using System;
using System.IO;
using System.Collections.Generic;
namespace DapaDale_TinderUCl
{   
    [Serializable]
    public class interesses
    {
        List<String> interessesUser = new List<String>();

        public static List<String> controleInteresse(){
            int cont = 0;
            Console.Clear();
            Console.WriteLine("Escolha 4 interesses");
            verInteresses();
            while (cont < 4)
            {
                Console.Write("Insira o código do interesse >> ");
                int index = int.Parse(Console.ReadLine());
                addInteresses(index);
                cont++;
            }
            return this.interessesUser;
        }
        public static void verInteresses(){
            String line;
             try
            {
                StreamReader sr = new StreamReader("database\\interesses.csv");
                line = sr.ReadLine();
                while (line != null)
                {   
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            finally
            {
                Console.WriteLine("");
            }
        }
        public static void addInteresses(int index){
            String line;
            string[] dadosIntereses;
            
            try
            {
                StreamReader sr = new StreamReader("database\\interesses.csv");
                line = sr.ReadLine();
                while (line != null)
                {   
                    dadosIntereses = line.Split(',');
                    if (int.Parse(dadosIntereses[0]) == index)
                    {   
                        bool containsItem = false;
                        foreach (String interesse in this.interessesUser)
                        {
                            if (interesse == dadosIntereses[1]){
                                containsItem = true;
                            }
                        }
                        

                        if(containsItem){
                            break;
                        }
                        else{
                            Console.WriteLine("Interesse Adicionado");
                            this.interessesUser.Add(dadosIntereses[1]);
                            
                            break;
                        }
                    }
                    
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Interesses adicionados");
            }
        }

    }
}