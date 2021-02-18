using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class AplicaMedicamentoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAplicaMedicamento { get; set; }

        [Required(ErrorMessage="Dosagem não pode estar vazia.")]
        public string Dosagem { get; set; }

        [Display(Name = "Data de Aplicação")]
        [DataType(DataType.DateTime, ErrorMessage = "Data válida requerida.")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime DataAplicacao { get; set; }

        [Display(Name = "Dono")]
        [Required(ErrorMessage = "´Você precisa selecionar um dono.")]
        public int IdPessoa { get; set; }

        [Display(Name = "Animal")]
        [Required(ErrorMessage = "Selecione um animal para aplicar o medicamento.")]
        public int IdAnimal { get; set; }

        [Display(Name = "Medicamento")]
        [Required(ErrorMessage = "Selecione o medicamento a ser aplicado.")]
        public int IdMedicamento { get; set; }

        [Display(Name = "Observações")]
        [StringLength(500)]
        public string Observacoes { get; set; }
    }
}
