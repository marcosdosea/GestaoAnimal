using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Veterinario
    {
        public Veterinario()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdVeterinario { get; set; }
        public string Crmv { get; set; }
        public string Cnpj { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
