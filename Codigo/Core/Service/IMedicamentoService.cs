using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IMedicamentoService
    {
        void Editar(Medicamento medicamento);
        int Inserir(Medicamento medicamento);
        Medicamento Obter(int idMedicamento);
        IEnumerable<MedicamentoDTO> ObterTodosPorNome(string nome);
        IEnumerable<Medicamento> ObterTodos();
        void Remover(int idMedicamento);
        IEnumerable<MedicamentoDTO> ObterPorNomeOrdenadoDescending(string nome);
    }
}
