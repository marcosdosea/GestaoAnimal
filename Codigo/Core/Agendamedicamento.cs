using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Agendamedicamento
    {
        public int IdAgendamento { get; set; }
        public int? Frequencia { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }
        public int? Intervalo { get; set; }
        public int IdPessoa { get; set; }
        public int IdAnimal { get; set; }
        public int IdMedicamento { get; set; }
        public int IdConsulta { get; set; }
        public string Dosagem { get; set; }
        public byte? Aplicado { get; set; }

        public virtual Animal IdAnimalNavigation { get; set; }
        public virtual Consulta IdConsultaNavigation { get; set; }
        public virtual Medicamento IdMedicamentoNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
