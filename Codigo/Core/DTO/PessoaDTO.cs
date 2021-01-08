using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class PessoaDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Cnpj { get; set; }
        public string Crmv { get; set; }

    }
}
