using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AniversarioDominio
{
    public class RepositorioPessoa : IRepositorioPessoa
    {
        static readonly string path = @"C:\users\user\desktop\Pessoas.txt";

        public List<Pessoa> ConsultarPessoa()
        {
            if (!File.Exists(path))
            {
                FileStream arquivo = File.Create(path);
                arquivo.Close();
            }

            string resultado = File.ReadAllText(path);

            string[] pessoas = resultado.Split(";");

            List<Pessoa> pessoasList = new List<Pessoa>();
            for (int i = 0; i < pessoas.Length - 1; i++)
            {
                string[] dados = pessoas[i].Split(",");

                var nome = dados[0];
                var sobrenome = dados[1];
                var dataDeAniversario = Convert.ToDateTime(dados[2]);

                var pessoa = new Pessoa
                {
                    Nome = nome,
                    Sobrenome = sobrenome,
                    DataDeAniversario = Convert.ToDateTime(dataDeAniversario)
                };

                pessoasList.Add(pessoa);
            }
            return pessoasList;
        }

        public void SalvarPessoa(Pessoa pessoa)
        {
            string format = $"{pessoa.Nome},{pessoa.Sobrenome},{pessoa.DataDeAniversario};";
            File.AppendAllText(path, format);
        }

        public void DeletarPessoa(string nome)
        {
            List<Pessoa> pessoa = ConsultarPessoa().FindAll(x => x.Nome.Trim() == nome);
            List<Pessoa> pessoasLista = ConsultarPessoa();

            int id = 0;
            Console.WriteLine("Selecione uma das pessoas abaixo: ");
            foreach (var p in pessoa)
            {
                Console.WriteLine($" {id} - {p.Nome} {p.Sobrenome} {p.DataDeAniversario}");
                id++;
            }
            int opcaoNome = int.Parse(Console.ReadLine());

            Pessoa pessoaPraSerRemovida = pessoa.ElementAt(opcaoNome);
            pessoasLista.RemoveAll(x => x.Nome == pessoaPraSerRemovida.Nome);

            File.Delete(path);
            FileStream arquivo = File.Create(path);
            arquivo.Close();

            foreach (var p in pessoasLista)
            {
                string format = $"{p.Nome},{p.Sobrenome},{p.DataDeAniversario};";
                File.AppendAllText(path, format);
            }
        }

        public void EditarPessoa(string nome)
        {
            List<Pessoa> pessoa = ConsultarPessoa().FindAll(x => x.Nome.Trim() == nome);
            List<Pessoa> pessoasLista = ConsultarPessoa();

            int id = 0;
            Console.WriteLine("Selecione uma das pessoas abaixo: ");
            foreach (var p in pessoa)
            {
                Console.WriteLine($" {id} - {p.Nome} {p.Sobrenome} {p.DataDeAniversario}");
                id++;
            }
            int opcaoNome = int.Parse(Console.ReadLine());
        }
    }
}
