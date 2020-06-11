using System;
using System.Collections.Generic;
using System.Text;

namespace AniversarioDominio
{
    public class Pessoa
    {
        //public int Id { get; set; }
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
            return /*Id*/
                "Nome: " 
                + Nome  
                + " "  
                + Sobrenome 
                + " | Data de Aniversário: " 
                + DataDeAniversario.ToString("dd/MM/yyyy") 
                + ";\n";
        }
    }
}
