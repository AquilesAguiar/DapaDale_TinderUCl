using System;

namespace DapaDale_TinderUCl
{
    class Program
    {
        static void Main(string[] args)
        {   
            apiCep cep = new apiCep("29164370");
            cep.retornaLocalidade();
            Console.WriteLine(cep.retornaLocalidade().cep);
        }
    }
}
