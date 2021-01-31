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
        [Required(ErrorMessage="O nome do medicamento é obrigatório.")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Display(Name = "Espécie")]
        [Required(ErrorMessage="Selecione uma espécie.")]
        public int IdEspecieAnimal { get; set; }
        public byte? IsVacina { get; set; }
    }
}
