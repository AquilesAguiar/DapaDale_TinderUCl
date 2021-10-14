using System;
using System.IO;
using System.Collections.Generic;


namespace DapaDale_TinderUCl
{   
    [Serializable]
    public abstract class Cadastro{
        public string Nome{get;protected set;}
        public string Celular{get;protected set;}
        public string Cep{get;protected set;}
        public string Senha{get; protected set;}
        public string DataNasc{get;protected set;}
        public bool Verificado{get;protected set;}
        public string Rg{get; protected set;}
        public string Foto{get; protected set;}
        public ResponseViaCep Endereco;
        List<interesses> interessesUser = new List<interesses>();

        public Cadastro(string nome,string rg,string cel, string cep, string senha, string data_nasc,string foto, bool verificado){
            Nome = nome;
            Celular = cel;
            Cep = cep;
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
                StreamReader sr = new StreamReader("database\\interesses.csv");
                line = sr.ReadLine();
                while (line != null)
                {   
                    dadosIntereses = line.Split(',');
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
                Console.WriteLine("Erro: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Interesses adicionados");
            }
        }

        public abstract bool AtualizaPropriedade(int escolha, string valor);


    }
}