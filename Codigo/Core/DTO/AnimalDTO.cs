using System;

namespace Core
{
    public class AnimalDTO
    {
       
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Sexo { get; set; }
        public float? Peso { get; set; }
        public byte[] Foto { get; set; }
        public string Status { get; set; }
        public byte? Castrado { get; set; }
        public byte? Falecido { get; set; }
        public int IdPessoa { get; set; }
        public int IdOrganizacao { get; set; }

    }
}
