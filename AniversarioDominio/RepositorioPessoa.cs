using System.Collections.Generic;
using System.IO;

namespace AniversarioDominio
{
    public class RepositorioPessoa
    {
        static readonly string path = @"C:\users\user\desktop\Pessoas.txt";

       // static List<Pessoa> listaPessoas = new List<Pessoa>();
        public static void ConsultarPessoa()
        {
            if (!File.Exists(path))
            {
                FileStream arquivo = File.Create(path);
                arquivo.Close();
            }
            string[] pessoas = File.ReadAllLines(path);
            if (pessoas.Length == 0)
            {
                System.Console.WriteLine("Nenhuma funcionário cadastrado.");
            }
            else
            {
                foreach (string p in pessoas)
                {
                    System.Console.WriteLine(p);
                }
            }
        }

        public static void SalvarPessoa(Pessoa pessoa)
        {
            File.AppendAllText(path, pessoa.ToString());
           // listaPessoas.Add(pessoa);
        }

        public static void DeletarPessoa(string nome)
        {
            
        }
    }
}
