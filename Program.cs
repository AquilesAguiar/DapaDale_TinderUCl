using System;
using System.IO;

namespace DapaDale_TinderUCl
{
    class Program
    {
        static void Main(string[] args)
        {   
            
            while (true){
                Console.Write("Digite 1 para Cadastrar-se e 2 para Logar! >> ");
                int sentinela = int.Parse(Console.ReadLine());

                switch(sentinela){

                    case 1:
                        //Cadastrar-se
                        Console.Write("Nome >> ");
                        string nome = Console.ReadLine();

                        Console.Write("Data de Nascimento >> ");
                        string dataNas = Console.ReadLine();

                        Console.Write("Celular >> ");
                        int cel = int.Parse(Console.ReadLine());

                        Console.Write("Cep >> ");
                        string cep = Console.ReadLine();

                        Console.Write("Senha >> ");
                        string senha = Console.ReadLine();

                        Console.Write("Rg >> ");
                        string rg = Console.ReadLine();

                        Console.Write("Link da Foto >> ");
                        string foto = Console.ReadLine();
                        
                        
                        Usuario user = new Usuario(nome,cel,cep,senha,dataNas,false,rg,foto);
                        user.isVerificado();
                        if (user.VerificaData()){
                            //Escreve no TXT
                            try
                            {
                                StreamWriter sw = File.AppendText("C:\\Users\\bielp\\Documents\\GitHub\\DapaDale_TinderUCl\\database\\Usuarios.csv");
                                
                                sw.WriteLine(user.Nome + "," + user.Celular + "," + user.Endereco.cep + "," + user.Endereco.logradouro + "," + user.Endereco.bairro + "," + user.Endereco.localidade + "," + user.Endereco.uf + "," + user.Senha + "," + user.DataNasc + "," + user.Rg + "," + user.Foto + "," + user.Verificado);
                                sw.Close();
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine("Exceção: " + e.Message);
                            }
                            finally
                            {
                                Console.WriteLine("Usuario Criado!!");
                            }
                            break;
                        }
                        Console.WriteLine("Usuario menor de 18 anos !!");
                        break;

                    case 2:
                        //Logar
                        Console.Write("Usuario >> ");
                        string usu = Console.ReadLine();

                        Console.Write("Senha >> ");
                        string password = Console.ReadLine();

                        if(controleMenus.Logar(usu,password)){
                            Console.WriteLine("Entrou!");
                        }
                        break;
                    case 3:
                        //Sair
                        Console.WriteLine("Saindo....");
                        Environment.Exit(0);
                        break;
                }

            }
            
        }
    }
}
