using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Animal
    {
        public Animal()
        {
            Agendamedicamento = new HashSet<Agendamedicamento>();
            Aplicamedicamento = new HashSet<Aplicamedicamento>();
            Consulta = new HashSet<Consulta>();
            Exame = new HashSet<Exame>();
        }

        public int IdAnimal { get; set; }
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

        public virtual Organizacao IdOrganizacaoNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual ICollection<Agendamedicamento> Agendamedicamento { get; set; }
        public virtual ICollection<Aplicamedicamento> Aplicamedicamento { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
        public virtual ICollection<Exame> Exame { get; set; }
    }
}
