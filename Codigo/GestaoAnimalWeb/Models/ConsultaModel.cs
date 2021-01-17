using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;

namespace GestaoAnimalWeb.Models
{
    public class ConsultaModel
    {
        public int IdConsulta { get; set; }
        public string Descricao { get; set; }
        public TimeSpan Horario { get; set; }
        public DateTime Data { get; set; }
        public double Preco { get; set; }
        public int IdAnimal { get; set; }
        public int IdPessoa { get; set; }

        public virtual Animal IdAnimalNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual ICollection<Agendamedicamento> Agendamedicamento { get; set; }
        public virtual ICollection<Exame> Exame { get; set; }
    }
}
