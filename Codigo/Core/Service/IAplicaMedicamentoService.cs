using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IAplicaMedicamentoService
    {
        void Editar(AplicaMedicamento aplicaMedicamento);
        int Inserir(AplicaMedicamento aplicaMedicamento);
        AplicaMedicamento Obter(int idAplicacao);
        IEnumerable<AplicamedicamentoDTO> ObterTodosPorNome(string nome);
        IEnumerable<AplicaMedicamento> ObterTodos();
        void Remover(int idAplicacao);
        IEnumerable<AplicamedicamentoDTO> ObterPorNomeOrdenadoDescending(string nome);
    }
}
