using AniversarioDominio;
using System;
using System.Globalization;

namespace AT_CSharp
{
    class Program
    {
        private static void Main(string[] args)
        {
            MenuPrincipal();
        }

        private static void MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Gerenciador de Aniversários");
            Console.WriteLine("Selecione uma das opções abaixo: ");
            Console.WriteLine("1 - Pesquisar Pessoas");
            Console.WriteLine("2 - Adicionar novas pessoas");
            Console.WriteLine("3 - Editar pessoas");
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

        private static void ConsultarPessoa()
        {
            Console.Clear();
            if (repositorio.ConsultarPessoa().Count == 0)
            {
                Console.WriteLine("Nenhuma funcionário cadastrado.");
            }
            foreach (var pessoa in repositorio.ConsultarPessoa())
            {
                Console.WriteLine(pessoa.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("Aperte qualquer tecla para continuar.");
            Console.ReadKey();
            MenuPrincipal();
        }

        private static void SalvarPessoa()
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
                repositorio.SalvarPessoa(pessoa);
            }
            MenuPrincipal();
        }

        private static void EditarPessoa()
        {
            Console.WriteLine("Digite o nome da pessoa que você deseja editar: ");
            string nome = Console.ReadLine();
            repositorio.EditarPessoa(nome);
            Console.WriteLine("Pessoa editada com sucesso!");
            Console.ReadKey();
            MenuPrincipal();
        }

        private static void DeletarPessoa()
        {
            Console.WriteLine("Digite o nome da pessoa que você deseja deletar: ");
            string nome = Console.ReadLine();
            repositorio.DeletarPessoa(nome);
            Console.WriteLine("Pessoa deletada com sucesso!");
            Console.ReadKey();
            MenuPrincipal();
        }

        private static IRepositorioPessoa repositorio = new RepositorioPessoa();
    }
}
