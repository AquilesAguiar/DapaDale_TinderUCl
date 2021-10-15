using System;
using System.IO;
using System.Collections.Generic;


namespace DapaDale_TinderUCl
{   
    [Serializable]
    public abstract class Cadastro{
        public string Nome{get;protected set;}
        public string Descricao{get;protected set;}
        public string Celular{get;protected set;}
        public string Cep{get;protected set;}
        public string Senha{get; protected set;}
        public string DataNasc{get;protected set;}
        public bool Verificado{get;protected set;}
        public string Rg{get; protected set;}
        public string Foto{get; protected set;}
        public ResponseViaCep Endereco;
        public List<string> interessesUser {get; protected set;}

        public Cadastro(string nome,string descricao,string rg,string cel, string cep, string senha, string data_nasc,string foto, bool verificado,List<string> listaInteresses){
            Nome = nome;
            Celular = cel;
            Descricao = descricao;
            Cep = cep;
            apiCep viaCep = new apiCep(cep);
            Endereco = viaCep.retornaLocalidade();
            Rg = rg;
            Senha = senha;
            DataNasc = data_nasc;
            Foto = foto;
            Verificado = verificado;
            interessesUser = listaInteresses;
        }

        public static List<string> escolherInteresses(List<string> listaInteresses){
            String line;
            string[] controle;
            // Printando os interesses
            try
            {
                StreamReader sr = new StreamReader("database\\interesses.csv");
                Console.WriteLine("Escolha quatro interesses:");
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
            // Salvando os interesses
            int cont = 0;
            while(cont<4){
                Console.WriteLine("\n");
                Console.WriteLine("Insira o código do interesse: ");
                string valor = Console.ReadLine();
                try
                {   
                    StreamReader sr2 = new StreamReader("database\\interesses.csv");
                    line = sr2.ReadLine();
                    while (line != null)
                    {   
                        controle = line.Split(",");
                        if(controle[0] == valor){
                            if(!listaInteresses.Contains(controle[1])){
                                Console.WriteLine("Interesse adicionado");
                                listaInteresses = addInteresses(controle[1],listaInteresses);
                                cont++;
                            }
                            else{
                                Console.WriteLine("Interesse já esta adicionado tente denovo");
                            }
                        }
                        line = sr2.ReadLine();
                    }
                    sr2.Close();
                }
                catch(Exception e)
                {
                    Console.WriteLine("Erro: " + e.Message);
                }
                
            }
            return listaInteresses; 
        }
        public static List<string> addInteresses(string valor,List<string> listaInteresses){
            listaInteresses.Add(valor);
            return listaInteresses;
        }
        public abstract bool AtualizaPropriedade(int escolha, string valor);


    }
}