using System;
using AniversarioDominio;

namespace AT_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        static void MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Gerenciador de Aniversários");
            Console.WriteLine("Selecione uma das opções abaixo: ");
            Console.WriteLine("1 - Pesquisar Pessoas");
            Console.WriteLine("2 - Adicionar novas pessoas");
            Console.WriteLine("3 - Edirtar pessoas");
            Console.WriteLine("4 - Deletar novas pessoas");
            Console.WriteLine("5 - Sair");
            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    ConsultarPessoa();
                    break;
                case 2:
                    SalvarPessoa();
                    break;
                case 3:
                    EditarPessoa();
                    break;
                case 4:
                    DeletarPessoa();
                    break;
                default:
                    Console.WriteLine("Tchau!!");
                    break;
            }
        }

        static void SalvarPessoa()
        {
            Console.Clear();
            Console.WriteLine("Gerenciador de Aniversários");
            Console.WriteLine("Digite o nome da pessoa que deseja adicionar: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o sobrenome da pessoa que deseja adicionar: ");
            string sobrenome = Console.ReadLine();
            Console.WriteLine("Digite a data de aniversário no formato dd/MM/yyyy: ");
            DateTime dataDeAniversario = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Os dados estão corretos?");
            Console.WriteLine($"Nome: {nome} {sobrenome} ");
            Console.WriteLine($"Data de aniversário: { dataDeAniversario:dd/MM/yyyy}");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não");
            int resposta = int.Parse(Console.ReadLine());
            Pessoa pessoa = new Pessoa(nome, sobrenome, dataDeAniversario);
            if (resposta == 1)
            {
               RepositorioPessoa.SalvarPessoa(pessoa);
            }
            MenuPrincipal();
        }

        static void ConsultarPessoa()
        {
            Console.Clear();
            RepositorioPessoa.ConsultarPessoa();
            Console.WriteLine();
            Console.WriteLine("Aperte qualquer tecla para continuar.");
            Console.ReadKey();
            MenuPrincipal();
        }

        static void EditarPessoa()
        {
            Console.WriteLine("Editei.");
            Console.ReadKey();
            MenuPrincipal();
        }

        static void DeletarPessoa()
        {
            Console.WriteLine("Digite o nome da pessoa que você deseja deletar: ");
            string nome = Console.ReadLine();
            RepositorioPessoa.DeletarPessoa(nome);
            Console.ReadKey();
            MenuPrincipal();
        }
    }
}
