using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class MedicamentoDTO
    {
        public int IdMedicamento { get; set; }
        public string Nome { get; set; }
        public int IdEspecieAnimal { get; set; }
        public byte? IsVacina { get; set; }
        public string NomeEspecie { get; set; }
    }
}
