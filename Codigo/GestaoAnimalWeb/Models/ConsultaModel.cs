using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Core;

namespace GestaoAnimalWeb.Models
{
    public class ConsultaModel
    {
        public int IdConsulta { get; set; }

        [Display(Name = "Descrição da consulta")]
        [Required(ErrorMessage = "Descrição não pode estar vazia!")]
        public string Descricao { get; set; }
        [Display(Name = "Horário da Consulta")]
        public TimeSpan Horario { get; set; }

        [Display(Name = "Data da Consulta")]
        [DataType(DataType.DateTime, ErrorMessage = "Data válida requerida.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Range(0, 1000,
        ErrorMessage = "O Valor de uma consulta varia de $0 (grátis) até $1000")]
        public double Preco { get; set; }
        [Display(Name = "Animal")]
        [Required(ErrorMessage = "Animal não pode estar vazio.")]
        public int IdAnimal { get; set; }
        [Display(Name = "Dono")]
        [Required(ErrorMessage = "Dono não pode estar vazio.")]
        public int IdPessoa { get; set; }

        public virtual Animal IdAnimalNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual ICollection<Agendamedicamento> Agendamedicamento { get; set; }
        public virtual ICollection<Exame> Exame { get; set; }
    }
}
