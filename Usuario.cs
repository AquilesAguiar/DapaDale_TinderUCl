using System;
using System.Runtime.Serialization;
namespace DapaDale_TinderUCl
{
    [Serializable]
    public class Usuario:Cadastro, IVerificado
    {   
        public Usuario(string Nome,string Rg,string Celular, string Cep, string Senha, string DataNasc,string Foto, bool Verificado):base(  Nome, Rg, Celular,  Cep,  Senha,  DataNasc, Foto,  Verificado){}

        public bool isVerificado(){
            if(Rg != "" && Foto != ""){
                Verificado = true; 
                return Verificado;
            }
            return Verificado;
        }

        public bool VerificaData(){
            DateTime data = Convert.ToDateTime(DataNasc);
            DateTime dataAtual = DateTime.Today;

            TimeSpan Intervalo = dataAtual - data;
                    
            TimeSpan Valor = Intervalo/365;

            string valorString = Valor.ToString();

            string[] listValor = valorString.Split('.');
            // Console.WriteLine(listValor[0]);

            if (int.Parse(listValor[0]) > 18){
                return true;
            }

            return false;

        }

        public override bool AtualizaPropriedade(int escolha, string valor){
            switch (escolha)
            {   
                // Nome
                case 1:
                    Nome = valor;
                    return true;
                // Celular
                case 2:
                    Celular = valor;
                    return true;
                // Cep
                case 3:
                    Cep = valor;
                    return true;
                // DataNasc
                case 4:
                    DataNasc = valor;
                    return true;
                // Rg
                case 5:
                    Rg = valor;
                    return true;    
                //Foto    
                case 6:
                    Foto = valor;
                    return true;
                default:
                    return false;
            }
        }
    }
}