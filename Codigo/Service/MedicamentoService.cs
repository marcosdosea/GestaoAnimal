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

        public void Editar(Medicamento medicamento)
        {
            _context.Update(medicamento);
            _context.SaveChanges();
        }

        public int Inserir(Medicamento medicamento)
        {
            _context.Add(medicamento);
            _context.SaveChanges();
            return medicamento.IdMedicamento;
        }

        public Medicamento Obter(int idMedicamento)
        {
            IEnumerable<Medicamento> medicamentos = GetQuery()
                .Where(medicamento => medicamento.IdMedicamento.Equals(idMedicamento));
            return medicamentos.ElementAtOrDefault(0);
        }

        public IEnumerable<MedicamentoDTO> ObterPorNomeOrdenadoDescending(string nome)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MedicamentoDTO> ObterTodos()
        {
            IQueryable<Medicamento> medicamentos = _context.Medicamento;
            var query = from medicamento in medicamentos
                        select new MedicamentoDTO
                        {
                            IdMedicamento = medicamento.IdMedicamento,
                            Nome = medicamento.Nome,
                            IsVacina = medicamento.IsVacina,
                            IdEspecieAnimal =medicamento.IdEspecieAnimal,
                            NomeEspecie = medicamento.IdEspecieAnimalNavigation.Nome
                        };
            return query;
        }

        public IEnumerable<MedicamentoDTO> ObterTodosPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public void Remover(int idMedicamento)
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
