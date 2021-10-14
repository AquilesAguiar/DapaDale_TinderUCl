using System;
using System.IO;
using System.Net;
using Newtonsoft.Json; 
using Newtonsoft.Json.Serialization;

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
            var cliente = new WebClient();
            var text = cliente.DownloadString("https://viacep.com.br/ws/"+Cep+"/json/");

            var settings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            };
            ResponseViaCep viacep = JsonConvert.DeserializeObject<ResponseViaCep>(text);

            return viacep;
        }
    }
        
}