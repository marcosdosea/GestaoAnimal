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
        IEnumerable<MedicamentoDTO> ObterTodos();
        IEnumerable<Medicamento> ObterPorEspecie(int idEspecieAnimal);
        void Remover(int idMedicamento);
        IEnumerable<MedicamentoDTO> ObterPorNomeOrdenadoDescending(string nome);
    }
}
