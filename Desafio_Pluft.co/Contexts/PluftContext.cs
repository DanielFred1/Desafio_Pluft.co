using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Desafio_Pluft.co.Domains
{
    public partial class PluftContext : DbContext
    {
        public PluftContext()
        {
        }

        public PluftContext(DbContextOptions<PluftContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agendamentos> Agendamentos { get; set; }
        public virtual DbSet<AreasAtividade> AreasAtividade { get; set; }
        public virtual DbSet<Capacidades> Capacidades { get; set; }
        public virtual DbSet<Instituicoes> Instituicoes { get; set; }
        public virtual DbSet<Logradouros> Logradouros { get; set; }
        public virtual DbSet<Lojistas> Lojistas { get; set; }
        public virtual DbSet<Servicos> Servicos { get; set; }
        public virtual DbSet<StatusAgendamento> StatusAgendamento { get; set; }
        public virtual DbSet<TipoUsuarios> TipoUsuarios { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Valores> Valores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS01; Initial Catalog =DESAFIO_PLUFT ; Integrated Security =True");
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS; Initial Catalog =DESAFIO_PLUFT ; User =sa ; Pwd =132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agendamentos>(entity =>
            {
                entity.ToTable("AGENDAMENTOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataAgendamento)
                    .HasColumnName("DATA_AGENDAMENTO")
                    .HasColumnType("date");

                entity.Property(e => e.HoraAgendamento).HasColumnName("HORA_AGENDAMENTO");

                entity.Property(e => e.IdInsituicao).HasColumnName("ID_INSITUICAO");

                entity.Property(e => e.IdServico).HasColumnName("ID_SERVICO");

                entity.Property(e => e.IdStatus).HasColumnName("ID_STATUS");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.HasOne(d => d.IdInsituicaoNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdInsituicao)
                    .HasConstraintName("FK__AGENDAMEN__ID_IN__6EF57B66");

                entity.HasOne(d => d.IdServicoNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdServico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AGENDAMEN__ID_SE__6FE99F9F");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AGENDAMEN__ID_ST__70DDC3D8");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__AGENDAMEN__ID_US__6E01572D");
            });

            modelBuilder.Entity<AreasAtividade>(entity =>
            {
                entity.ToTable("AREAS_ATIVIDADE");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__AREAS_AT__E2AB1FF4BF49685E")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Capacidades>(entity =>
            {
                entity.ToTable("CAPACIDADES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("DESCRICAO")
                    .HasColumnType("text");

                entity.Property(e => e.Quantidade)
                    .HasColumnName("QUANTIDADE")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Instituicoes>(entity =>
            {
                entity.ToTable("INSTITUICOES");

                entity.HasIndex(e => e.Cnpj)
                    .HasName("UQ__INSTITUI__AA57D6B44DCDB89C")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("CNPJ")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.IdAreasAtividade).HasColumnName("ID_AREAS_ATIVIDADE");

                entity.Property(e => e.IdLogradouro).HasColumnName("ID_LOGRADOURO");

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasColumnName("NOME_FANTASIA")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasColumnName("RAZAO_SOCIAL")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnName("TELEFONE")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAreasAtividadeNavigation)
                    .WithMany(p => p.Instituicoes)
                    .HasForeignKey(d => d.IdAreasAtividade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INSTITUIC__ID_AR__59063A47");

                entity.HasOne(d => d.IdLogradouroNavigation)
                    .WithMany(p => p.Instituicoes)
                    .HasForeignKey(d => d.IdLogradouro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INSTITUIC__ID_LO__59FA5E80");
            });

            modelBuilder.Entity<Logradouros>(entity =>
            {
                entity.ToTable("LOGRADOUROS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("BAIRRO")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("CEP")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("ESTADO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Municipio)
                    .IsRequired()
                    .HasColumnName("MUNICIPIO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasColumnName("RUA")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lojistas>(entity =>
            {
                entity.ToTable("LOJISTAS");

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__LOJISTAS__C1F897314A5BE74C")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__LOJISTAS__161CF7248D9DC1BC")
                    .IsUnique();

                entity.HasIndex(e => e.Rg)
                    .HasName("UQ__LOJISTAS__321537C8987A2637")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdInstituicao).HasColumnName("ID_INSTITUICAO");

                entity.Property(e => e.IdLogradouro).HasColumnName("ID_LOGRADOURO");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TIPO_USUARIO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasColumnName("RG")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnName("TELEFONE")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdInstituicaoNavigation)
                    .WithMany(p => p.Lojistas)
                    .HasForeignKey(d => d.IdInstituicao)
                    .HasConstraintName("FK__LOJISTAS__ID_INS__6A30C649");

                entity.HasOne(d => d.IdLogradouroNavigation)
                    .WithMany(p => p.Lojistas)
                    .HasForeignKey(d => d.IdLogradouro)
                    .HasConstraintName("FK__LOJISTAS__ID_LOG__6B24EA82");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Lojistas)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__LOJISTAS__ID_TIP__693CA210");
            });

            modelBuilder.Entity<Servicos>(entity =>
            {
                entity.ToTable("SERVICOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("DESCRICAO")
                    .HasColumnType("text");

                entity.Property(e => e.IdCapacidades).HasColumnName("ID_CAPACIDADES");

                entity.Property(e => e.IdValores).HasColumnName("ID_VALORES");

                entity.Property(e => e.NomeServico)
                    .IsRequired()
                    .HasColumnName("NOME_SERVICO")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCapacidadesNavigation)
                    .WithMany(p => p.Servicos)
                    .HasForeignKey(d => d.IdCapacidades)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SERVICOS__ID_CAP__5535A963");

                entity.HasOne(d => d.IdValoresNavigation)
                    .WithMany(p => p.Servicos)
                    .HasForeignKey(d => d.IdValores)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SERVICOS__ID_VAL__5441852A");
            });

            modelBuilder.Entity<StatusAgendamento>(entity =>
            {
                entity.ToTable("STATUS_AGENDAMENTO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuarios>(entity =>
            {
                entity.ToTable("TIPO_USUARIOS");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__TIPO_USU__E2AB1FF41024D266")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__USUARIOS__C1F89731315A67A3")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USUARIOS__161CF724040014ED")
                    .IsUnique();

                entity.HasIndex(e => e.Rg)
                    .HasName("UQ__USUARIOS__321537C8262B7DD2")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdLogradouro).HasColumnName("ID_LOGRADOURO");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TIPO_USUARIO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasColumnName("RG")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnName("TELEFONE")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdLogradouroNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdLogradouro)
                    .HasConstraintName("FK__USUARIOS__ID_LOG__6383C8BA");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__USUARIOS__ID_TIP__628FA481");
            });

            modelBuilder.Entity<Valores>(entity =>
            {
                entity.ToTable("VALORES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Valor)
                    .HasColumnName("VALOR")
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });
        }
    }
}
