using System;
using System.IO;
namespace DapaDale_TinderUCl
{
    public class interesses
    {
        public int Id{ get;protected set;}
        public string Nome {get;protected set;}

        public interesses(int id,string nome){
            Nome = nome;
            Id = id;
        }
    }
}