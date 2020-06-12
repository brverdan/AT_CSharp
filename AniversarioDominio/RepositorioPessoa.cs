using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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

                var id = dados[0];
                var nome = dados[1];
                var sobrenome = dados[2];
                var dataDeAniversario = Convert.ToDateTime(dados[3]);

                var pessoa = new Pessoa
                {
                    Id = Convert.ToInt32(id),
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
            if (ConsultarPessoa().Count == 0)
            {
                pessoa.Id = 1;
            }
            else
            {
                pessoa.Id = ConsultarPessoa().Last().Id + 1;
            }
            string format = $"{pessoa.Id},{pessoa.Nome},{pessoa.Sobrenome},{pessoa.DataDeAniversario};";
            File.AppendAllText(path, format);
        }

        public void DeletarPessoa(string nome)
        {
            List<Pessoa> pessoa = ConsultarPessoa().FindAll(x => x.Nome.Trim() == nome);
            List<Pessoa> pessoasLista = ConsultarPessoa();

            Console.WriteLine("Selecione uma das pessoas abaixo: ");
            foreach (var p in pessoa)
            {
                Console.WriteLine($" {p.Id} - {p.Nome} {p.Sobrenome} {p.DataDeAniversario}");
            }
            int opcaoId = int.Parse(Console.ReadLine());

            Pessoa pessoaRemovida = pessoasLista.Find(x => x.Id == opcaoId);
            pessoasLista.Remove(pessoaRemovida);

            RecriarArquivo(pessoasLista);
        }

        public void EditarPessoa(string nome)
        {
            List<Pessoa> pessoa = ConsultarPessoa().FindAll(x => x.Nome.ToLower().Trim().Contains(nome) ||
            x.Sobrenome.ToLower().Trim().Contains(nome));
            List<Pessoa> pessoasLista = ConsultarPessoa();

            Console.WriteLine("Selecione uma das pessoas abaixo: ");
            foreach (var p in pessoa)
            {
                Console.WriteLine($" {p.Id} - {p.Nome} {p.Sobrenome} {p.DataDeAniversario}");
            }
            int opcaoNome = int.Parse(Console.ReadLine());

            Pessoa pessoaEditada = pessoasLista.Find(x => x.Id == opcaoNome);
            Console.WriteLine("Digite o novo nome: ");
            pessoaEditada.Nome = Console.ReadLine();
            Console.WriteLine("Digite o novo sobrenome: ");
            pessoaEditada.Sobrenome = Console.ReadLine();
            Console.WriteLine("Digite a nova data de aniversário (dd/mm/yyyy): ");
            pessoaEditada.DataDeAniversario = DateTime.Parse(Console.ReadLine());
            pessoasLista.RemoveAll(x => x.Id == pessoaEditada.Id);
            pessoasLista.Add(pessoaEditada);

            RecriarArquivo(pessoasLista);
        }

        private void RecriarArquivo(List<Pessoa> pessoas)
        {
            File.Delete(path);
            FileStream arquivo = File.Create(path);
            arquivo.Close();

            foreach (var p in pessoas)
            {
                string format = $"{p.Id},{p.Nome},{p.Sobrenome},{p.DataDeAniversario};";
                File.AppendAllText(path, format);
            }
        }
    }
}
