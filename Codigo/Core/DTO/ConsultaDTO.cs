using System;

namespace Core
{
    public class ConsultaDTO
    {
        public int IdConsulta { get; set; }//OBSERVAÇÃO
        public string Descricao { get; set; }
        public TimeSpan Horario { get; set; }
        public DateTime Data { get; set; }
        public double Preco { get; set; }
        public int IdAnimal { get; set; }
        public int IdPessoa { get; set; }
        public string Animal { get; set; }
        public string Pessoa { get; set; }
    }
}
