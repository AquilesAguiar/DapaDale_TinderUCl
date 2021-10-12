using System;
using System.IO;
using System.Collections.Generic;


namespace DapaDale_TinderUCl
{
    public abstract class Cadastro{
        public string Nome{get;protected set;}
        public string Rg{get;protected set;}
        public int Celular{get;protected set;}
        public string Cep{get;protected set;}
        private string Senha{get;set;}
        public string DataNasc{get;protected set;}
        public string Foto{get;protected set;}
        public bool Verificado{get;protected set;}
        public ResponseViaCep Endereco;
        List<interesses> interessesUser = new List<interesses>();

        public Cadastro(string nome,int cel, string cep, string senha, string data_nasc, bool verificado ,string rg ,string foto){
            Nome = nome;
            Celular = cel;
            apiCep viaCep = new apiCep(cep);
            Endereco = viaCep.retornaLocalidade();
            Rg = rg;
            Senha = senha;
            DataNasc = data_nasc;
            Foto = foto;
            Verificado = verificado;
        }

        public void addInteresses(int index){
            String line;
            string[] dadosIntereses;
            try
            {
                StreamReader sr = new StreamReader("database\\interesses.txt");
                line = sr.ReadLine();
                while (line != null)
                {   
                    dadosIntereses = line.Split('-');
                    if (int.Parse(dadosIntereses[0]) == index)
                    {   
                        interessesUser.Add(new interesses(int.Parse(dadosIntereses[0]),dadosIntereses[1]));
                        break;
                    }
                    
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        public abstract bool AtualizaPropriedade(int escolha, string valor);


    }
}