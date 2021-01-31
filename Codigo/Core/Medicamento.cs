using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Medicamento
    {
        public Medicamento()
        {
            Agendamedicamento = new HashSet<Agendamedicamento>();
            Aplicamedicamento = new HashSet<Aplicamedicamento>();
        }

        public int IdMedicamento { get; set; }
        public string Nome { get; set; }
        public byte IsVacina { get; set; }
        public int IdEspecieAnimal { get; set; }

        public virtual Especieanimal IdEspecieAnimalNavigation { get; set; }
        public virtual ICollection<Agendamedicamento> Agendamedicamento { get; set; }
        public virtual ICollection<Aplicamedicamento> Aplicamedicamento { get; set; }
    }
}
