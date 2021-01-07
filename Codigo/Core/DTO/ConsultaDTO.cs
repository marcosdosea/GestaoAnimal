using System;

namespace Core
{
    public class ConsultaDTO
    {
        public string Descricao { get; set; }
        public TimeSpan Horario { get; set; }
        public DateTime Data { get; set; }
        public double Preco { get; set; }
        public int IdAnimal { get; set; }
        public int IdPessoa { get; set; }
    }
}
