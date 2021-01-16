using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class MedicamentoModel
    {
        public int IdMedicamento { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public byte? IsVacina { get; set; }

        public virtual ICollection<Agendamedicamento> Agendamedicamento { get; set; }
        public virtual ICollection<AplicaMedicamento> Aplicamedicamento { get; set; }
    }
}
