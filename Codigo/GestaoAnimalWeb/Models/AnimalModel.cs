using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Core;

namespace GestaoAnimalWeb.Models
{
    public class AnimalModel
    {
        public int IdAnimal { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome não pode estar vazio.")]
        public string Nome { get; set; }
        [Display(Name = "Raça")]
        [Required(ErrorMessage = "Raça não pode estar vazia.")]
        public string Raca { get; set; }
        [Display(Name = "Data de Aplicação")]
        [DataType(DataType.DateTime, ErrorMessage = "Data válida requerida.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataNascimento { get; set; }
        public string Sexo { get; set; }
        public float? Peso { get; set; }
        public byte[] Foto { get; set; }
        public string Status { get; set; }

         [Range(0, 1, 
        ErrorMessage = "O Valor para este campo deve ser 1 para animal castrado e 0 para NÃO castrado")]
        public byte? Castrado { get; set; }

        [Range(0, 1,
        ErrorMessage = "O Valor para este campo deve ser 1 para animal falecido e 0 para NÃO falecido")]
        public byte? Falecido { get; set; }
        [Display(Name = "Dono")]
        [Required(ErrorMessage = "Dono não pode estar vazio.")]
        public int IdPessoa { get; set; }
        [Display(Name = "Organização")]
        [Required(ErrorMessage = "Organização não pode estar vazia.")]
        public int IdOrganizacao { get; set; }

        public int IdEspecieAnimal { get; set; }
        public int IdLote { get; set; }

        public virtual Especieanimal IdEspecieAnimalNavigation { get; set; }
        public virtual Lote IdLoteNavigation { get; set; }
        public virtual Organizacao IdOrganizacaoNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual ICollection<Agendamedicamento> Agendamedicamento { get; set; }
        public virtual ICollection<Aplicamedicamento> Aplicamedicamento { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
        public virtual ICollection<Exame> Exame { get; set; }
    }
}
