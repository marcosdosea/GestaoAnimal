using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class MedicamentoDTO
    {
        public string Nome { get; set; }
        public string Especie { get; set; }
        public byte? IsVacina { get; set; }
    }
}
