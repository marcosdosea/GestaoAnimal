using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class PessoaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPessoa { get; set; }

        [Display(Name = "Nome")]
        [Required (ErrorMessage = "Nome não pode estar vazio")]
        public string Nome { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Nome não pode estar vazio")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Nome não pode estar vazio")]
        public string Senha { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "CPF não pode estar vazio")]
        public string Cpf { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataNascimento { get; set; }

        [Display (Name ="Sexo")]
        [Required (ErrorMessage = "Sexo não pode estar vazio")]
        public string Sexo { get; set; }
        public byte? Ativo { get; set; }
        public string TipoPessoa { get; set; }
        public string Cnpj { get; set; }
        public string Crmv { get; set; }
    }
}
