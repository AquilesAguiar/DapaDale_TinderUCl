using System;
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
        // List<interesses> interessesUser = new List<interesses>();

        public Cadastro(string nome,int cel, string cep, string senha, string data_nasc, bool verificado ,string rg = "",string foto = ""){
            Nome = nome;
            Celular = cel;
            apiCep viaCep = new apiCep(cep);
            viaCep.retornaLocalidade();
            Rg = rg;
            Senha = senha;
            DataNasc = data_nasc;
            Foto = foto;
            Verificado = verificado;
        }

        public abstract bool AtualizaPropriedade(int escolha, string valor);

    }
}