using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class AplicaMedicamentoModel
    {
        public int IdAplicaMedicamento { get; set; }
        public string Dosagem { get; set; }
        public DateTime DataAplicacao { get; set; }
        public TimeSpan Horario { get; set; }
        public int IdPessoa { get; set; }
        public int IdAnimal { get; set; }
        public int IdMedicamento { get; set; }
        public string Observacoes { get; set; }
        public virtual Animal IdAnimalNavigation { get; set; }
        public virtual Medicamento IdMedicamentoNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
