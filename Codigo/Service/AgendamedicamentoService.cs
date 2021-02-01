using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace Service
{
    public class AgendamedicamentoService : IAgendamedicamentoService
    {
        private readonly GestaoAnimalContext _context;

        public AgendamedicamentoService(GestaoAnimalContext context)
        {
            _context = context;
        }

        public void Editar(Agendamedicamento agendamento)
        {
            _context.Update(agendamento);
            _context.SaveChanges();
        }

        public int Inserir(Agendamedicamento agendamento)
        {
            _context.Add(agendamento);
            _context.SaveChanges();
            return agendamento.IdAgendamento;
        }

        public Agendamedicamento Obter(int idAgendamento)
        {
            IEnumerable<Agendamedicamento> agendamentos = GetQuery()
                .Where(agendamento => agendamento.IdAgendamento.Equals(idAgendamento));
            return agendamentos.ElementAtOrDefault(0);
        }

        public IEnumerable<Agendamedicamento> ObterPorNomeOrdenadoDescending(string nome)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AgendamedicamentoDTO> ObterTodos()
        {
            IQueryable<Agendamedicamento> agendamedicamentos = _context.Agendamedicamento;
            var query = from agendamedicamento in agendamedicamentos
                        select new AgendamedicamentoDTO
                        {
                            IdAgendamento = agendamedicamento.IdAgendamento,
                            Frequencia = agendamedicamento.Frequencia,
                            DataInicio = agendamedicamento.DataInicio,
                            DataTermino = agendamedicamento.DataTermino,
                            Intervalo = agendamedicamento.Intervalo,
                            Dosagem = agendamedicamento.Dosagem,
                            NomePessoa = agendamedicamento.IdPessoaNavigation.Nome,
                            NomeAnimal = agendamedicamento.IdAnimalNavigation.Nome,
                            NomeMedicamento = agendamedicamento.IdMedicamentoNavigation.Nome
                        };
            return query;
        }

        public IEnumerable<AgendamedicamentoDTO> ObterTodosPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public void Remover(int idAgendamento)
        {
            var _agendamento = _context.Agendamedicamento.Find(idAgendamento);
            _context.Agendamedicamento.Remove(_agendamento);
            _context.SaveChanges();
        }

        private IQueryable<Agendamedicamento> GetQuery()
        {
            IQueryable<Agendamedicamento> tb_agendamedicamento = _context.Agendamedicamento;
            var query = from agendamedicamento in tb_agendamedicamento
                        select agendamedicamento;
            return query;
        }
    }
}
