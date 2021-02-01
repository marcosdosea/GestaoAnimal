using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class AgendamedicamentoDTO
    {
        public int IdAgendamento { get; set; }
        public int? Frequencia { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }
        public int? Intervalo { get; set; }
        public string Dosagem { get; set; }
        public string NomePessoa { get; set; }
        public string NomeAnimal { get; set; }
        public string NomeMedicamento { get; set; }
        public string NomeConsulta { get; set; }
    }
}
