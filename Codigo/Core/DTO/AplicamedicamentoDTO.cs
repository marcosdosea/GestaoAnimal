using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class AplicamedicamentoDTO
    {
        public string Dosagem { get; set; }
        public DateTime DataAplicacao { get; set; }
        public TimeSpan Horario { get; set; }
        public int IdPessoa { get; set; }
        public int IdAnimal { get; set; }
        public int IdMedicamento { get; set; }
        public string Observacoes { get; set; }
    }
}
