using System;
using System.Collections.Generic;
using System.Text;

namespace AniversarioDominio
{
    public interface IRepositorioPessoa
    {
        List<Pessoa> ConsultarPessoa();
        void SalvarPessoa(Pessoa pessoa);
        void DeletarPessoa(string nome);
        void EditarPessoa(string nome);
    }
}
