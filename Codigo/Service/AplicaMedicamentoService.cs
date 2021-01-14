using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace Service
{
    public class AplicaMedicamentoService : IAplicaMedicamentoService
    {
        private readonly GestaoAnimalContext _context;

        public AplicaMedicamentoService(GestaoAnimalContext context)
        {
            _context = context;
        }

        public void Editar(AplicaMedicamento aplicaMedicamento)
        {
            _context.Update(aplicaMedicamento);
            _context.SaveChanges();
        }

        public int Inserir(AplicaMedicamento aplicamedicamento)
        {
            _context.Add(aplicamedicamento);
            _context.SaveChanges();
            return aplicamedicamento.IdAplicaMedicamento;
        }

        public AplicaMedicamento Obter(int idAplicacao)
        {
            IEnumerable<AplicaMedicamento> aplicamedicamentos = GetQuery()
                .Where(aplicamedicamento => aplicamedicamento.IdAplicaMedicamento.Equals(idAplicacao));
            return aplicamedicamentos.ElementAtOrDefault(0);
        }

        public IEnumerable<AplicamedicamentoDTO> ObterPorNomeOrdenadoDescending(string nome)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AplicaMedicamento> ObterTodos()
        {
            return GetQuery();
        }

        public IEnumerable<AplicamedicamentoDTO> ObterTodosPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public void Remover(int idAplicacao)
        {
            var _aplicaMedicamento = _context.Aplicamedicamento.Find(idAplicacao);
            _context.Aplicamedicamento.Remove(_aplicaMedicamento);
            _context.SaveChanges();
        }

        private IQueryable<AplicaMedicamento> GetQuery()
        {
            IQueryable<AplicaMedicamento> tb_aplicamedicamento = _context.Aplicamedicamento;
            var query = from aplicamedicamento in tb_aplicamedicamento
                        select aplicamedicamento;
            return query;
        }
    }
}
