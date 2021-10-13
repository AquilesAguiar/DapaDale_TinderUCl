namespace DapaDale_TinderUCl
{
    public class Usuario:Cadastro, IVerificado
    {
        public Usuario(string nome,string rg = "" ,int cel, int cep, int senha, Date data_nasc, string foto = ""):base(nome, rg, cel, cep, senha, data_nasc, foto){}

        public bool Verificado{get;set;};
        public bool isVerificado(){
            if(Rg != "" && Foto != ""){
                Verificado = true; 
                return Verificado;
            }
            Verificado = false; 
            return Verificado;
        }

        public bool VerificaData(){
            
        }


    }
}