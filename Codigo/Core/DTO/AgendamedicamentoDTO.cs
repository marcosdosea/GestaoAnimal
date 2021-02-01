using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class AgendamedicamentoDTO
    {
        public int? Frequencia { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }
        public int? Intervalo { get; set; }
        public string Dosagem { get; set; }
    }
}
