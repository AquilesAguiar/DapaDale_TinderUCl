using System;
using System.IO;
using System.Net;
using System.Text.Json;

namespace DapaDale_TinderUCl
{   
    [Serializable]
    public class apiCep
    {   
        string Cep;
        public apiCep(string cep){
            Cep = cep;
        }

        public ResponseViaCep retornaLocalidade(){
            
            // Joga pra string novamente
            // var json2 = JsonConvert.SerializeObject(viacep, Formatting.Indented, settings);
            try
            {    
                var cliente = new WebClient();
                var text = cliente.DownloadString("https://viacep.com.br/ws/"+Cep+"/json/");
                ResponseViaCep viacep = JsonSerializer.Deserialize<ResponseViaCep>(text);

                return viacep;
            }
            catch (System.Exception)
            {
                throw;
            }     
        }
    }
        
}