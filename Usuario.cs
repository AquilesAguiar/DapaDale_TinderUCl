namespace DapaDale_TinderUCl
{
    public class Usuario:Cadastro, IVerificado
    {
        public Usuario(string nome,int cel, string cep, string senha, string data_nasc, bool verificado = false, string rg = "",string foto = "" ):base(nome, cel, cep, senha, data_nasc, verificado, rg, foto){}

        public bool isVerificado(){
            if(Rg != "" && Foto != ""){
                Verificado = true; 
                return Verificado;
            }
            return Verificado;
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
                    Celular = int.Parse(valor);
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