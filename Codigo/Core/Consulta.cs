using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Consulta
    {
        public Consulta()
        {
            Agendamedicamento = new HashSet<Agendamedicamento>();
            Exame = new HashSet<Exame>();
        }

        public int IdConsulta { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal Preco { get; set; }
        public int IdAnimal { get; set; }
        public int IdPessoa { get; set; }

        public virtual Animal IdAnimalNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual ICollection<Agendamedicamento> Agendamedicamento { get; set; }
        public virtual ICollection<Exame> Exame { get; set; }
    }
}
