using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class ExameDTO
    {
        public int IdExame { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public string Observacoes { get; set; }
        public string Consulta { get; set; }
        public string Animal { get; set; }
        public string TipoExame { get; set; }
    }
}
