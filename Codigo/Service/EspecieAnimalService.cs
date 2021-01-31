using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class EspecieAnimalService : IEspecieAnimalService
    {
        private readonly GestaoAnimalContext _context;

        public EspecieAnimalService(GestaoAnimalContext context)
        {
            _context = context;
        }
        public IEnumerable<Especieanimal> ObterTodos()
        {
            return GetQuery();
        }

        public Especieanimal Obter(int IdEspecieAnimal)
        {
            IEnumerable<Especieanimal> especies = GetQuery()
                .Where(especie => especie.IdEspecieAnimal.Equals(IdEspecieAnimal));
            return especies.ElementAtOrDefault(0);
        }

        private IQueryable<Especieanimal> GetQuery()
        {
            IQueryable<Especieanimal> EspeciesAnimais = _context.Especieanimal;
            var query = from especieAnimal in EspeciesAnimais
                        select especieAnimal;
            return query;
        }
    }
}
