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

        public void Editar(Aplicamedicamento aplicaMedicamento)
        {
            _context.Update(aplicaMedicamento);
            _context.SaveChanges();
        }

        public int Inserir(Aplicamedicamento aplicamedicamento)
        {
            _context.Add(aplicamedicamento);
            _context.SaveChanges();
            return aplicamedicamento.IdAplicaMedicamento;
        }

        public Aplicamedicamento Obter(int idAplicacao)
        {
            IEnumerable<Aplicamedicamento> aplicamedicamentos = GetQuery()
                .Where(aplicamedicamento => aplicamedicamento.IdAplicaMedicamento.Equals(idAplicacao));
            return aplicamedicamentos.ElementAtOrDefault(0);
        }

        public IEnumerable<AplicamedicamentoDTO> ObterPorNomeOrdenadoDescending(string nome)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AplicamedicamentoDTO> ObterTodos()
        {
            IQueryable<Aplicamedicamento> aplicamedicamentos = _context.Aplicamedicamento;
            var query = from aplicamedicamento in aplicamedicamentos
                        select new AplicamedicamentoDTO
                        {
                            IdAplicaMedicamento = aplicamedicamento.IdAplicaMedicamento,
                            Dosagem = aplicamedicamento.Dosagem,
                            DataAplicacao = aplicamedicamento.DataAplicacao,
                            NomeAnimal = aplicamedicamento.IdAnimalNavigation.Nome,
                            NomeMedicamento = aplicamedicamento.IdMedicamentoNavigation.Nome,
                            NomePessoa = aplicamedicamento.IdPessoaNavigation.Nome
                        };
            return query;
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

        private IQueryable<Aplicamedicamento> GetQuery()
        {
            IQueryable<Aplicamedicamento> tb_aplicamedicamento = _context.Aplicamedicamento;
            var query = from aplicamedicamento in tb_aplicamedicamento
                        select aplicamedicamento;
            return query;
        }
    }
}
