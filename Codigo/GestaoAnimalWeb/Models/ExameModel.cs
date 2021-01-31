using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class ExameModel
    {
        [Display(Name = "Código")]
        public int IdExame { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Informe a Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Data de Realização")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [Required(ErrorMessage = "Informe a Data de Realização")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime Data { get; set; }

        [Display(Name = "Observações")]
        [Required(ErrorMessage = "Informe as Observações")]
        public string Observacoes { get; set; }

        [Display(Name = "Consulta")]
        [Required(ErrorMessage = "Informe a Consulta")]
        public int IdConsulta { get; set; }

        [Display(Name = "Animal")]
        [Required(ErrorMessage = "Informe o Animal")]
        public int IdAnimal { get; set; }

        [Display(Name = "Tipo do Exame")]
        [Required(ErrorMessage = "Informe o tipo do Exame")]
        public int IdTipoExame { get; set; }
    }
}