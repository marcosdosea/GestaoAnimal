using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class AplicamedicamentoDTO
    {
        public int IdAplicaMedicamento { get; set; }
        public string Dosagem { get; set; }
        public DateTime DataAplicacao { get; set; }
        public TimeSpan Horario { get; set; }
        public string NomePessoa { get; set; }
        public string NomeAnimal { get; set; }
        public string NomeMedicamento { get; set; }
    }
}
