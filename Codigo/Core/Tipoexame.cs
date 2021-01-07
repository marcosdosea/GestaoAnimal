using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Tipoexame
    {
        public Tipoexame()
        {
            Exame = new HashSet<Exame>();
        }

        public int IdTipoExame { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Exame> Exame { get; set; }
    }
}
