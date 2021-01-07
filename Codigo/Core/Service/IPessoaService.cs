using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IPessoaService
    {
        void Editar(Pessoa pessoa);
        int Inserir(Pessoa pessoa);
        Pessoa Obter(int idPessoa);
        IEnumerable<PessoaDTO> ObterTodosPorNome(string nome);
        IEnumerable<Pessoa> ObterTodos();
        void Remover(int idPessoa);
        IEnumerable<PessoaDTO> ObterPorNomeOrdenadoDescending(string nome);
    }
}
