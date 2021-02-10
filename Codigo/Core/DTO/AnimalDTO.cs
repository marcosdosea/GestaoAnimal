using System;

namespace Core
{
    public class AnimalDTO
    {
        public string Nome { get; set; }
        public int IdAnimal { get; set; }
        public string Raca { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Sexo { get; set; }
        public decimal? Peso { get; set; }
        public byte[] Foto { get; set; }
        public string Status { get; set; }
        public byte? Castrado { get; set; }
        public byte? Falecido { get; set; }
        public string NomePessoa { get; set; }
        public string NomeOrganizacao { get; set; }
        public string EspecieAnimal { get; set; }
        //public int IdLote { get; set; }
    }
}
