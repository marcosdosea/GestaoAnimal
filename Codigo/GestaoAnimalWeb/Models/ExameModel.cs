using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class ExameModel
    {
        public int IdExame { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public string Observacoes { get; set; }
        public int IdConsulta { get; set; }
        public int IdAnimal { get; set; }
        public int IdTipoExame { get; set; }
    }
}