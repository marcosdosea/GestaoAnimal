using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;

namespace Service
{
    public class MedicamentoService : IMedicamentoService
    {
        private readonly GestaoAnimalContext _context;

        public MedicamentoService(GestaoAnimalContext context)
        {
            _context = context;
        }

        void IMedicamentoService.Editar(Medicamento medicamento)
        {
            _context.Update(medicamento);
            _context.SaveChanges();
        }

        int IMedicamentoService.Inserir(Medicamento medicamento)
        {
            _context.Add(medicamento);
            _context.SaveChanges();
            return medicamento.IdMedicamento;
        }

        Medicamento IMedicamentoService.Obter(int idMedicamento)
        {
            IEnumerable<Medicamento> medicamentos = GetQuery()
                .Where(medicamento => medicamento.IdMedicamento.Equals(idMedicamento));
            return medicamentos.ElementAtOrDefault(0);
        }

        IEnumerable<MedicamentoDTO> IMedicamentoService.ObterPorNomeOrdenadoDescending(string nome)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Medicamento> IMedicamentoService.ObterTodos()
        {
            return GetQuery();
        }

        IEnumerable<MedicamentoDTO> IMedicamentoService.ObterTodosPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        void IMedicamentoService.Remover(int idMedicamento)
        {
            var _medicamento = _context.Medicamento.Find(idMedicamento);
            _context.Medicamento.Remove(_medicamento);
            _context.SaveChanges();
        }

        private IQueryable<Medicamento> GetQuery()
        {
            IQueryable<Medicamento> tb_medicamento = _context.Medicamento;
            var query = from medicamento in tb_medicamento
                        select medicamento;
            return query;
        }
    }
}
