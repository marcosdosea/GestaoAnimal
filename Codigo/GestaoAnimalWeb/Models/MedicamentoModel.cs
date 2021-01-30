using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class MedicamentoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMedicamento { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public byte? IsVacina { get; set; }

        public virtual ICollection<Agendamedicamento> Agendamedicamento { get; set; }
        public virtual ICollection<Aplicamedicamento> Aplicamedicamento { get; set; }
    }
}
