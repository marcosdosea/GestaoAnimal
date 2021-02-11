using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;

namespace Service
{
    public class ConsultaService:IConsultaService
    {
        private readonly GestaoAnimalContext _context;
        public ConsultaService(GestaoAnimalContext context)
        {
            _context = context;
        }
        public int Inserir(Consulta consulta)
        {
            _context.Add(consulta);
            _context.SaveChanges();
            return consulta.IdAnimal;
        }
        public void Editar(Consulta consulta)
        {
            _context.Update(consulta);
            _context.SaveChanges();
        }
        public void Remover(int IdConsulta)
        {
            var _consulta = _context.Consulta.Find(IdConsulta);
            _context.Consulta.Remove(_consulta);
            _context.SaveChanges();
        }
        private IQueryable<Consulta> GetQuery()
        {
            IQueryable<Consulta> Consulta = _context.Consulta;
            var query = from consulta in Consulta
                        select consulta;
            return query;
        }
        public Consulta Obter(int idConsulta)
        {
            IEnumerable<Consulta> consultas = GetQuery().Where(consultaModel => consultaModel.IdConsulta.Equals(idConsulta));

            return consultas.ElementAtOrDefault(0);
        }
        public IEnumerable<ConsultaDTO> ObterPorDescricao(string nome)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<ConsultaDTO> ObterTodasConsultas()
        {
            IQueryable<Consulta> consultas = _context.Consulta;
            var query = from consulta in consultas
                        select new ConsultaDTO
                        {
                            IdConsulta = consulta.IdConsulta,
                            Descricao = consulta.Descricao,
                            Horario = consulta.Horario,
                            Data = consulta.Data,
                            Preco = consulta.Preco,
                            IdAnimal = consulta.IdAnimalNavigation.IdAnimal,
                            IdPessoa = consulta.IdPessoaNavigation.IdPessoa,
                            Animal = consulta.IdAnimalNavigation.Nome,
                            Pessoa = consulta.IdPessoaNavigation.Nome
                        };
            return query;
        }
       public IEnumerable<Consulta> ObterTodos()
        {
            return GetQuery();
        }
        






    }
}
