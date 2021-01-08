using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IOrganizacaoService
    {
        void Editar(Organizacao organizacao);
        int Inserir(Organizacao organizacao);
        Organizacao Obter(int idOrganizacao);
        IEnumerable<OrganizacaoDTO> ObterTodosPorNome(string nome);
        IEnumerable<Organizacao> ObterTodos();
        void Remover(int idOrganizacao);
        IEnumerable<OrganizacaoDTO> ObterPorNomeOrdenadoDescending(string nome);
    }
}
