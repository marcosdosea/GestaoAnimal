using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class TipoexameService : ITipoexameService
    {
        private readonly GestaoAnimalContext _context;

        public TipoexameService(GestaoAnimalContext context)
        {
            _context = context;
        }

        public void Editar(Tipoexame tipoexame)
        {
            _context.Update(tipoexame);
            _context.SaveChanges();
        }

        public int Inserir(Tipoexame tipoexame)
        {
            _context.Add(tipoexame);
            _context.SaveChanges();
            return tipoexame.IdTipoExame;
        }

        public Tipoexame Obter(int idTipoexame)
        {
            IEnumerable<Tipoexame> tiposExames = GetQuery().Where(tipoExame => tipoExame.IdTipoExame.Equals(idTipoexame));

            return tiposExames.ElementAtOrDefault(0);
        }

        public IEnumerable<TipoexameDTO> ObterPorNomeOrdenadoDescending(string nome)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tipoexame> ObterTodos()
        {
            return GetQuery();
        }

        public IEnumerable<TipoexameDTO> ObterTodosPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public void Remover(int idTipoexame)
        {
            var TipoExame = _context.Tipoexame.Find(idTipoexame);
            _context.Tipoexame.Remove(TipoExame);
            _context.SaveChanges();
        }

        private IQueryable<Tipoexame> GetQuery()
        {
            IQueryable<Tipoexame> tb_tipoexame = _context.Tipoexame;
            var query = from tipoexame in tb_tipoexame
                        select tipoexame;
            return query;
        }

    }
}
