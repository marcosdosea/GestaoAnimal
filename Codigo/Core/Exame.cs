using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Exame
    {
        public int IdExame { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public string Observacoes { get; set; }
        public int IdConsulta { get; set; }
        public int IdAnimal { get; set; }
        public int IdTipoExame { get; set; }

        public virtual Animal IdAnimalNavigation { get; set; }
        public virtual Consulta IdConsultaNavigation { get; set; }
        public virtual Tipoexame IdTipoExameNavigation { get; set; }
    }
}
