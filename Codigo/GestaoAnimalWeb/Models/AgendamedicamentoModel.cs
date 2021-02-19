using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Models
{
    public class AgendamedicamentoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAgendamento { get; set; }

        [Display(Name = "Frequência")]
        [Required(ErrorMessage = "Frequência não pode estar vazia.")]
        public int? Frequencia { get; set; }

        [Display(Name = "Data de Início")]
        [DataType(DataType.DateTime, ErrorMessage = "Data válida requerida.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? DataInicio { get; set; }

        [Display(Name = "Data de Término")]
        [DataType(DataType.DateTime, ErrorMessage = "Data válida requerida.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? DataTermino { get; set; }

        [Required(ErrorMessage = "Intervalo não pode estar vazio.")]
        public int? Intervalo { get; set; }
        [Display(Name = "Pessoa")]
        [Required(ErrorMessage = "Selecione uma pessoa para agendar o medicamento.")]
        public int IdPessoa { get; set; }

        [Display(Name = "Animal")]
        [Required(ErrorMessage = "Selecione um animal para agendar o medicamento.")]
        public int IdAnimal { get; set; }

        [Display(Name = "Medicamento")]
        [Required(ErrorMessage = "Selecione o medicamento a ser agendado.")]
        public int IdMedicamento { get; set; }

        [Display(Name = "Consulta")]
        [Required(ErrorMessage = "Selecione a consulta a que esse agendamento pertence.")]
        public int IdConsulta { get; set; }

        [Required(ErrorMessage = "Dosagem não pode estar vazia.")]
        public string Dosagem { get; set; }

        public virtual Animal IdAnimalNavigation { get; set; }
        public virtual Consulta IdConsultaNavigation { get; set; }
        public virtual Medicamento IdMedicamentoNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
