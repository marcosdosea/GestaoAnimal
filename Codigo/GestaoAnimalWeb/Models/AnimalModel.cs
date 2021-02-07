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
        public string Nome { get; set; }
        [Display(Name = "Espécie")]
        [Required(ErrorMessage = "Selecione uma espécie para o animal.")]
        public int IdEspecieAnimal { get; set; }
        public string Raca { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.DateTime, ErrorMessage = "Data válida requerida.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "Sexo não pode estar vazio.")]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "Peso não pode estar vazio.")]
        public float? Peso { get; set; }
        public byte[] Foto { get; set; }
        public string Status { get; set; }
        [Range(0, 1,
        ErrorMessage = "Este campo só aceita valor 1 para Castrado e 0  para NÃO Castrado")]
        public byte? Castrado { get; set; }
        [Range(0, 1,
        ErrorMessage = "Este campo só aceita valor 1 para Castrado e 0  para NÃO Castrado")]
        public byte? Falecido { get; set; }
        [Display(Name = "Dono")]
        [Required(ErrorMessage = "Selecione um dono para o animal.")]
        public int IdPessoa { get; set; }
        [Display(Name = "Organização")]
        [Required(ErrorMessage = "Selecione uma organização para o animal.")]
        public int IdOrganizacao { get; set; }
      
       
    }
}
