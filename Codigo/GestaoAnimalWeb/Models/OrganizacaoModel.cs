using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAnimalWeb.Models
{
    public class OrganizacaoModel
    {
        [HiddenInput]
        public int IdOrganizacao { get; set; }

        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "CNPJ não pode estar vazio")]
        public string Cnpj { get; set; }

        [Display(Name = "Data de Aberura")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataAbertura { get; set; }
        public byte? Ativo { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome da organização não pode estar vazio")]
        public string Nome { get; set; }
        public string Telefone { get; set; }
        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "Endereço não pode estar vazio")]
        public string Endereco { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "E-mail não pode estar vazio")]
        public string Email { get; set; }
    }
}
