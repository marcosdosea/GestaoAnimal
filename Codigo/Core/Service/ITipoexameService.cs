using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface ITipoexameService
    {
        void Editar(Tipoexame tipoexame);
        int Inserir(Tipoexame tipoexame);
        Tipoexame Obter(int idTipoexame);
        IEnumerable<TipoexameDTO> ObterTodosPorNome(string nome);
        IEnumerable<Tipoexame> ObterTodos();
        void Remover(int idTipoexame);
        IEnumerable<TipoexameDTO> ObterPorNomeOrdenadoDescending(string nome);
    }
}
