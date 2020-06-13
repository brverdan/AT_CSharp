using System;

namespace AniversarioDominio
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataDeAniversario { get; set; }

        public Pessoa()
        {
        }

        public Pessoa(string nome, string sobrenome, DateTime dataDeAniversario)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            DataDeAniversario = dataDeAniversario;
        }

        public override string ToString()
        {
            return Id 
                + "- Nome: "
                + Nome
                + " "
                + Sobrenome
                + " | Data de Aniversário: "
                + DataDeAniversario.ToString("dd/MM/yyyy")
                + ";\n";
        }

        public string DiferencaAniversario()
        {
            DateTime dataDeHoje = DateTime.Today;
            DateTime proximaData = new DateTime(dataDeHoje.Year, DataDeAniversario.Month, DataDeAniversario.Day);

            if (proximaData < dataDeHoje)
            {
                proximaData = proximaData.AddYears(1);
            }

            int diferencaDeDias = (proximaData - dataDeHoje).Days;

            return "Quantidade de dias para o próximo aniversário: " + diferencaDeDias;
        }

    }
}
