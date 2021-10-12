using System;
using System.Collections.Generic;

namespace DapaDale_TinderUCl
{
    public abstract class Cadastro{
        public string Nome{get;protected set;}
        public string Rg{get;protected set;}
        public int Celular{get;protected set;}
        public int Cep{get;protected set;}
        private int Senha{get;set;}
        public Date DataNasc{get;protected set;}
        public string Foto{get;protected set;}
        //public bool Verificado{get;protected set;}
        List<interesses> interessesUser = new List<interesses>();

        public Cadastro(string nome,string rg = "",int cel, int cep, int senha, Date data_nasc, string foto = ""){
            Nome = nome;
            Celular = cel;
            apiCep viaCep = new apiCep();
            cep.retornaLocalidade();
            Senha = senha;
            DataNasc = data_nasc;
            Foto = foto;
        }

    }
}