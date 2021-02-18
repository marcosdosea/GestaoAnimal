using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core
{
    public partial class GestaoAnimalContext : DbContext
    {
        public GestaoAnimalContext()
        {
        }

        public GestaoAnimalContext(DbContextOptions<GestaoAnimalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agendamedicamento> Agendamedicamento { get; set; }
        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Aplicamedicamento> Aplicamedicamento { get; set; }
        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<Especieanimal> Especieanimal { get; set; }
        public virtual DbSet<Exame> Exame { get; set; }
        public virtual DbSet<Lote> Lote { get; set; }
        public virtual DbSet<Medicamento> Medicamento { get; set; }
        public virtual DbSet<Organizacao> Organizacao { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Pessoaorganizacao> Pessoaorganizacao { get; set; }
        public virtual DbSet<Tipoexame> Tipoexame { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=gestaoanimal");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agendamedicamento>(entity =>
            {
                entity.HasKey(e => e.IdAgendamento)
                    .HasName("PRIMARY");

                entity.ToTable("agendamedicamento");

                entity.HasIndex(e => e.IdAnimal)
                    .HasName("fk_TB_AGENDA_MEDICAMENTO_TB_ANIMAL1_idx");

                entity.HasIndex(e => e.IdConsulta)
                    .HasName("fk_AgendaMedicamento_Consulta1_idx");

                entity.HasIndex(e => e.IdMedicamento)
                    .HasName("fk_AgendaMedicamento_Medicamento1_idx");

                entity.HasIndex(e => e.IdPessoa)
                    .HasName("fk_TB_AGENDA_MEDICAMENTO_TB_PESSOA1_idx");

                entity.Property(e => e.IdAgendamento).HasColumnName("idAgendamento");

                entity.Property(e => e.Aplicado).HasColumnName("aplicado");

                entity.Property(e => e.DataInicio)
                    .HasColumnName("dataInicio")
                    .HasColumnType("date");

                entity.Property(e => e.DataTermino)
                    .HasColumnName("dataTermino")
                    .HasColumnType("date");

                entity.Property(e => e.Dosagem)
                    .HasColumnName("dosagem")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Frequencia).HasColumnName("frequencia");

                entity.Property(e => e.IdAnimal).HasColumnName("idAnimal");

                entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");

                entity.Property(e => e.IdMedicamento).HasColumnName("idMedicamento");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.Intervalo).HasColumnName("intervalo");

                entity.HasOne(d => d.IdAnimalNavigation)
                    .WithMany(p => p.Agendamedicamento)
                    .HasForeignKey(d => d.IdAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_AGENDA_MEDICAMENTO_TB_ANIMAL1");

                entity.HasOne(d => d.IdConsultaNavigation)
                    .WithMany(p => p.Agendamedicamento)
                    .HasForeignKey(d => d.IdConsulta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AgendaMedicamento_Consulta1");

                entity.HasOne(d => d.IdMedicamentoNavigation)
                    .WithMany(p => p.Agendamedicamento)
                    .HasForeignKey(d => d.IdMedicamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AgendaMedicamento_Medicamento1");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Agendamedicamento)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_AGENDA_MEDICAMENTO_TB_PESSOA1");
            });

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(e => e.IdAnimal)
                    .HasName("PRIMARY");

                entity.ToTable("animal");

                entity.HasIndex(e => e.IdEspecieAnimal)
                    .HasName("fk_Animal_EspecieAnimal1_idx");

                entity.HasIndex(e => e.IdLote)
                    .HasName("fk_Animal_Lote1_idx");

                entity.HasIndex(e => e.IdOrganizacao)
                    .HasName("fk_TB_ANIMAL_TB_ORGANIZACAO1_idx");

                entity.HasIndex(e => e.IdPessoa)
                    .HasName("fk_TB_ANIMAL_TB_PESSOA_idx");

                entity.Property(e => e.IdAnimal).HasColumnName("idAnimal");

                entity.Property(e => e.Castrado).HasColumnName("castrado");

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("dataNascimento")
                    .HasColumnType("date");

                entity.Property(e => e.Falecido).HasColumnName("falecido");

                entity.Property(e => e.Foto)
                    .HasColumnName("foto")
                    .HasColumnType("blob");

                entity.Property(e => e.IdEspecieAnimal).HasColumnName("idEspecieAnimal");

                entity.Property(e => e.IdLote).HasColumnName("idLote");

                entity.Property(e => e.IdOrganizacao).HasColumnName("idOrganizacao");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Peso)
                    .HasColumnName("peso")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.Raca)
                    .HasColumnName("raca")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasColumnName("sexo")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.HasOne(d => d.IdEspecieAnimalNavigation)
                    .WithMany(p => p.Animal)
                    .HasForeignKey(d => d.IdEspecieAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Animal_EspecieAnimal1");

                entity.HasOne(d => d.IdLoteNavigation)
                    .WithMany(p => p.Animal)
                    .HasForeignKey(d => d.IdLote)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Animal_Lote1");

                entity.HasOne(d => d.IdOrganizacaoNavigation)
                    .WithMany(p => p.Animal)
                    .HasForeignKey(d => d.IdOrganizacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_ANIMAL_TB_ORGANIZACAO1");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Animal)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_ANIMAL_TB_PESSOA");
            });

            modelBuilder.Entity<Aplicamedicamento>(entity =>
            {
                entity.HasKey(e => e.IdAplicaMedicamento)
                    .HasName("PRIMARY");

                entity.ToTable("aplicamedicamento");

                entity.HasIndex(e => e.IdAnimal)
                    .HasName("fk_AplicaMedicamento_Animal1_idx");

                entity.HasIndex(e => e.IdMedicamento)
                    .HasName("fk_AplicaMedicamento_Medicamento1_idx");

                entity.HasIndex(e => e.IdPessoa)
                    .HasName("fk_TB_APLICAMEDICAMENTO_TB_PESSOA1_idx");

                entity.Property(e => e.IdAplicaMedicamento).HasColumnName("idAplicaMedicamento");

                entity.Property(e => e.DataAplicacao)
                    .HasColumnName("dataAplicacao")
                    .HasColumnType("date");

                entity.Property(e => e.Dosagem)
                    .IsRequired()
                    .HasColumnName("dosagem")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.IdAnimal).HasColumnName("idAnimal");

                entity.Property(e => e.IdMedicamento).HasColumnName("idMedicamento");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.Observacoes)
                    .HasColumnName("observacoes")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAnimalNavigation)
                    .WithMany(p => p.Aplicamedicamento)
                    .HasForeignKey(d => d.IdAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AplicaMedicamento_Animal1");

                entity.HasOne(d => d.IdMedicamentoNavigation)
                    .WithMany(p => p.Aplicamedicamento)
                    .HasForeignKey(d => d.IdMedicamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AplicaMedicamento_Medicamento1");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Aplicamedicamento)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_APLICAMEDICAMENTO_TB_PESSOA1");
            });

            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PRIMARY");

                entity.ToTable("consulta");

                entity.HasIndex(e => e.IdAnimal)
                    .HasName("fk_TB_CONSULTA_TB_ANIMAL1_idx");

                entity.HasIndex(e => e.IdPessoa)
                    .HasName("fk_Consulta_Pessoa1_idx");

                entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdAnimal).HasColumnName("idAnimal");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.Preco)
                    .HasColumnName("preco")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.IdAnimalNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_CONSULTA_TB_ANIMAL1");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Consulta_Pessoa1");
            });

            modelBuilder.Entity<Especieanimal>(entity =>
            {
                entity.HasKey(e => e.IdEspecieAnimal)
                    .HasName("PRIMARY");

                entity.ToTable("especieanimal");

                entity.HasIndex(e => e.Nome)
                    .HasName("nome_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdEspecieAnimal).HasColumnName("idEspecieAnimal");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Exame>(entity =>
            {
                entity.HasKey(e => e.IdExame)
                    .HasName("PRIMARY");

                entity.ToTable("exame");

                entity.HasIndex(e => e.IdAnimal)
                    .HasName("fk_TB_EXAME_TB_ANIMAL1_idx");

                entity.HasIndex(e => e.IdConsulta)
                    .HasName("fk_TB_EXAME_TB_CONSULTA1_idx");

                entity.HasIndex(e => e.IdTipoExame)
                    .HasName("fk_Exame_TipoExame1_idx");

                entity.Property(e => e.IdExame).HasColumnName("idExame");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdAnimal).HasColumnName("idAnimal");

                entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");

                entity.Property(e => e.IdTipoExame).HasColumnName("idTipoExame");

                entity.Property(e => e.Observacoes)
                    .IsRequired()
                    .HasColumnName("observacoes")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAnimalNavigation)
                    .WithMany(p => p.Exame)
                    .HasForeignKey(d => d.IdAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_EXAME_TB_ANIMAL1");

                entity.HasOne(d => d.IdConsultaNavigation)
                    .WithMany(p => p.Exame)
                    .HasForeignKey(d => d.IdConsulta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_EXAME_TB_CONSULTA1");

                entity.HasOne(d => d.IdTipoExameNavigation)
                    .WithMany(p => p.Exame)
                    .HasForeignKey(d => d.IdTipoExame)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Exame_TipoExame1");
            });

            modelBuilder.Entity<Lote>(entity =>
            {
                entity.HasKey(e => e.IdLote)
                    .HasName("PRIMARY");

                entity.ToTable("lote");

                entity.HasIndex(e => e.Numeracao)
                    .HasName("numeracao_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdLote).HasColumnName("idLote");

                entity.Property(e => e.Numeracao)
                    .IsRequired()
                    .HasColumnName("numeracao")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medicamento>(entity =>
            {
                entity.HasKey(e => e.IdMedicamento)
                    .HasName("PRIMARY");

                entity.ToTable("medicamento");

                entity.HasIndex(e => e.IdEspecieAnimal)
                    .HasName("fk_Medicamento_EspecieAnimal2_idx");

                entity.Property(e => e.IdMedicamento).HasColumnName("idMedicamento");

                entity.Property(e => e.IdEspecieAnimal).HasColumnName("idEspecieAnimal");

                entity.Property(e => e.IsVacina).HasColumnName("isVacina");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEspecieAnimalNavigation)
                    .WithMany(p => p.Medicamento)
                    .HasForeignKey(d => d.IdEspecieAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Medicamento_EspecieAnimal2");
            });

            modelBuilder.Entity<Organizacao>(entity =>
            {
                entity.HasKey(e => e.IdOrganizacao)
                    .HasName("PRIMARY");

                entity.ToTable("organizacao");

                entity.Property(e => e.IdOrganizacao).HasColumnName("idOrganizacao");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("cnpj")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.DataAbertura)
                    .HasColumnName("dataAbertura")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .HasColumnName("endereco")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.IdPessoa)
                    .HasName("PRIMARY");

                entity.ToTable("pessoa");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Cnpj)
                    .HasColumnName("cnpj")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .HasColumnName("cpf")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Crmv)
                    .HasColumnName("crmv")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("dataNascimento")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .HasColumnName("endereco")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasColumnName("senha")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasColumnName("sexo")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.TipoPessoa)
                    .HasColumnName("tipoPessoa")
                    .HasColumnType("enum('A','R','O','V')");
            });

            modelBuilder.Entity<Pessoaorganizacao>(entity =>
            {
                entity.HasKey(e => new { e.IdPessoa, e.IdOrganizacao })
                    .HasName("PRIMARY");

                entity.ToTable("pessoaorganizacao");

                entity.HasIndex(e => e.IdOrganizacao)
                    .HasName("fk_TB_PESSOA_has_TB_ORGANIZACAO_TB_ORGANIZACAO1_idx");

                entity.HasIndex(e => e.IdPessoa)
                    .HasName("fk_TB_PESSOA_has_TB_ORGANIZACAO_TB_PESSOA1_idx");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.IdOrganizacao).HasColumnName("idOrganizacao");

                entity.HasOne(d => d.IdOrganizacaoNavigation)
                    .WithMany(p => p.Pessoaorganizacao)
                    .HasForeignKey(d => d.IdOrganizacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_PESSOA_has_TB_ORGANIZACAO_TB_ORGANIZACAO1");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Pessoaorganizacao)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_PESSOA_has_TB_ORGANIZACAO_TB_PESSOA1");
            });

            modelBuilder.Entity<Tipoexame>(entity =>
            {
                entity.HasKey(e => e.IdTipoExame)
                    .HasName("PRIMARY");

                entity.ToTable("tipoexame");

                entity.Property(e => e.IdTipoExame).HasColumnName("idTipoExame");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
