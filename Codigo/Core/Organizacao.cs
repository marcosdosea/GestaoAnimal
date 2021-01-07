using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Organizacao
    {
        public Organizacao()
        {
            Animal = new HashSet<Animal>();
            Pessoaorganizacao = new HashSet<Pessoaorganizacao>();
        }

        public int IdOrganizacao { get; set; }
        public string Cnpj { get; set; }
        public DateTime? DataAbertura { get; set; }
        public byte? Ativo { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Animal> Animal { get; set; }
        public virtual ICollection<Pessoaorganizacao> Pessoaorganizacao { get; set; }
    }
}
