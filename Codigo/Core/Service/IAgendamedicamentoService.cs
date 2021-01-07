using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IAgendamedicamentoService
    {
        void Editar(Agendamedicamento agendamento);
        int Inserir(Agendamedicamento agendamento);
        Agendamedicamento Obter(int idAgendamento);
        IEnumerable<AgendamedicamentoDTO> ObterTodosPorNome(string nome);
        IEnumerable<Agendamedicamento> ObterTodos();
        void Remover(int idAgendamento);
        IEnumerable<Agendamedicamento> ObterPorNomeOrdenadoDescending(string nome);
    }
}
