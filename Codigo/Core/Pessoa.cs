using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Agendamedicamento = new HashSet<Agendamedicamento>();
            Animal = new HashSet<Animal>();
            Aplicamedicamento = new HashSet<AplicaMedicamento>();
            Consulta = new HashSet<Consulta>();
            Pessoaorganizacao = new HashSet<Pessoaorganizacao>();
        }

        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Sexo { get; set; }
        public byte? Ativo { get; set; }
        public string TipoPessoa { get; set; }
        public string Cnpj { get; set; }
        public string Crmv { get; set; }

        public virtual ICollection<Agendamedicamento> Agendamedicamento { get; set; }
        public virtual ICollection<Animal> Animal { get; set; }
        public virtual ICollection<AplicaMedicamento> Aplicamedicamento { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
        public virtual ICollection<Pessoaorganizacao> Pessoaorganizacao { get; set; }
    }
}
