using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Pessoaorganizacao
    {
        public int IdPessoa { get; set; }
        public int IdOrganizacao { get; set; }

        public virtual Organizacao IdOrganizacaoNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
