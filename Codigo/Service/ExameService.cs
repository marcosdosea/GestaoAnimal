using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;

namespace Service
{
    public class ExameService : IExameService
    {
        private readonly GestaoAnimalContext _context;

        public ExameService(GestaoAnimalContext context)
        {
            _context = context;
        }
        public void Editar(Exame exame)
        {
            _context.Update(exame);
            _context.SaveChanges();
        }

        public int Inserir(Exame exame)
        {
            _context.Add(exame);
            _context.SaveChanges();
            return exame.IdExame;
        }

        public Exame Obter(int idExame)
        {
            IEnumerable<Exame> exames = GetQuery()
                .Where(exame => exame.IdExame.Equals(idExame));
            return exames.ElementAtOrDefault(0);
        }

        public IEnumerable<ExameDTO> ObterPorNomeOrdenadoDescending(string nome)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExameDTO> ObterTodos()
        {
            IQueryable<Exame> exames = _context.Exame;
            var query = from exame in exames
                        select new ExameDTO
                        {
                            IdExame = exame.IdExame,
                            Descricao = exame.Descricao,
                            Data = exame.Data,
                            Observacoes = exame.Observacoes,
                            Consulta = exame.IdConsultaNavigation.Descricao,
                            Animal = exame.IdAnimalNavigation.Nome,
                            TipoExame = exame.IdTipoExameNavigation.Tipo
                        };
            return query;
        }

        public IEnumerable<ExameDTO> ObterTodosPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public void Remover(int idExame)
        {
            var _exame = _context.Exame.Find(idExame);
            _context.Exame.Remove(_exame);
            _context.SaveChanges();
        }

        private IQueryable<Exame> GetQuery()
        {
            IQueryable<Exame> tb_exame = _context.Exame;
            var query = from exame in tb_exame
                        select exame;
            return query;
        }
    }
}
