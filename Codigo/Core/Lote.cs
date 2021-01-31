using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Lote
    {
        public Lote()
        {
            Animal = new HashSet<Animal>();
        }

        public int IdLote { get; set; }
        public string Numeracao { get; set; }

        public virtual ICollection<Animal> Animal { get; set; }
    }
}
