using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IEspecieAnimalService
    {
        IEnumerable<Especieanimal> ObterTodos();
        Especieanimal Obter(int IdEspecieAnimal);
    }
}
