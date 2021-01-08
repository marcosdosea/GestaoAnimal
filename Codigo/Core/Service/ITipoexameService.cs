using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface ITipoexameService
    {
        void Editar(Tipoexame pessoa);
        int Inserir(Tipoexame pessoa);
        Tipoexame Obter(int idTipoexame);
        IEnumerable<TipoexameDTO> ObterTodosPorNome(string nome);
        IEnumerable<Tipoexame> ObterTodos();
        void Remover(int idTipoexame);
        IEnumerable<TipoexameDTO> ObterPorNomeOrdenadoDescending(string nome);
    }
}
