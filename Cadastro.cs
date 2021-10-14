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
        public List<string> interessesUser = new List<string>();

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
        public abstract bool AtualizaPropriedade(int escolha, string valor);


    }
}