﻿using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Medicamento
    {
        public Medicamento()
        {
            Agendamedicamento = new HashSet<Agendamedicamento>();
            Aplicamedicamento = new HashSet<AplicaMedicamento>();
        }

        public int IdMedicamento { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public byte? IsVacina { get; set; }

        public virtual ICollection<Agendamedicamento> Agendamedicamento { get; set; }
        public virtual ICollection<AplicaMedicamento> Aplicamedicamento { get; set; }
    }
}
