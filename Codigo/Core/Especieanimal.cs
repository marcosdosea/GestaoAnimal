using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Especieanimal
    {
        public Especieanimal()
        {
            Animal = new HashSet<Animal>();
            Medicamento = new HashSet<Medicamento>();
        }

        public int IdEspecieAnimal { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Animal> Animal { get; set; }
        public virtual ICollection<Medicamento> Medicamento { get; set; }
    }
}
