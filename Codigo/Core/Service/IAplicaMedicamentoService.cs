using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IAplicaMedicamentoService
    {
        void Editar(Aplicamedicamento aplicaMedicamento);
        int Inserir(Aplicamedicamento aplicaMedicamento);
        Aplicamedicamento Obter(int idAplicacao);
        IEnumerable<AplicamedicamentoDTO> ObterTodosPorNome(string nome);
        IEnumerable<AplicamedicamentoDTO> ObterTodos();
        void Remover(int idAplicacao);
        IEnumerable<AplicamedicamentoDTO> ObterPorNomeOrdenadoDescending(string nome);
    }
}
