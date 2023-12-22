﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_aapcmr.Config;

#nullable disable

namespace api_aapcmr.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20231222000031_UpdateTableSituacaoHabitacionalFields")]
    partial class UpdateTableSituacaoHabitacionalFields
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("api_aapcmr.Repository.AcaoApoioSemanal", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("AcoesApoioId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataAtualizacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataInicial")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("AcoesApoioId");

                    b.ToTable("AcaoApoioSemanais", (string)null);
                });

            modelBuilder.Entity("api_aapcmr.Repository.AcoesApoio", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataAtualizacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AcoesApoios", (string)null);
                });

            modelBuilder.Entity("api_aapcmr.Repository.ComposicaoFamiliar", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataAtualizacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("IdadeFamiliar")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomeFamiliar")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<long>("PacienteId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Renda")
                        .HasColumnType("REAL");

                    b.Property<string>("VinculoFamiliar")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("ComposicaoFamilias", (string)null);
                });

            modelBuilder.Entity("api_aapcmr.Repository.Doacao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<string>("Complemento")
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataAtualizacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("DataDoacao")
                        .HasColumnType("datetime");

                    b.Property<string>("Logradouro")
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeDoador")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<long>("Numero")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("StatusDoacao")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoDeEnvioValor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("TEXT");

                    b.Property<float>("ValorDoacao")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Doacoes", (string)null);
                });

            modelBuilder.Entity("api_aapcmr.Repository.Paciente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("Celular")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<bool>("CestaBasica")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataAtualizacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime");

                    b.Property<string>("Naturalidade")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("SUSNumero")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<long?>("SituacaoHabitacionalId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StatusCivil")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("TelefoneFixo")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SituacaoHabitacionalId")
                        .IsUnique();

                    b.HasIndex("UsuarioId");

                    b.ToTable("Pacientes", (string)null);
                });

            modelBuilder.Entity("api_aapcmr.Repository.PerfilUsuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Perfil")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("PerfilUsuarios", (string)null);
                });

            modelBuilder.Entity("api_aapcmr.Repository.SituacaoHabitacional", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Agua")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<string>("Casa")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<string>("Cidade")
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<string>("Complemento")
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataAtualizacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("InstalacaoSanitaria")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Logradouro")
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Luz")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Moradia")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<long>("Numero")
                        .HasColumnType("INTEGER");

                    b.Property<long>("PacienteId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Transporte")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SituacaoHabitacionais", (string)null);
                });

            modelBuilder.Entity("api_aapcmr.Repository.TipoGasto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataAtualizacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TipoGastos", (string)null);
                });

            modelBuilder.Entity("api_aapcmr.Repository.TratamentoPaciente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("AnoDiagnostico")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataAtualizacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DataObservacao")
                        .HasColumnType("datetime");

                    b.Property<string>("Diagnostico")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<bool>("HistoricoFamiliaCancer")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HospitalTratamento")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.Property<string>("Medico")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("Observacao")
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<long>("PacienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StatusTratamento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoCirurgia")
                        .HasColumnType("TEXT");

                    b.Property<bool>("UsoEntorpecente")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("TratamentoPacientes", (string)null);
                });

            modelBuilder.Entity("api_aapcmr.Repository.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataAtualizacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("api_aapcmr.Repository.AcaoApoioSemanal", b =>
                {
                    b.HasOne("api_aapcmr.Repository.AcoesApoio", "AcoesApoio")
                        .WithMany("AcaoApoioSemanais")
                        .HasForeignKey("AcoesApoioId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("AcoesApoio");
                });

            modelBuilder.Entity("api_aapcmr.Repository.ComposicaoFamiliar", b =>
                {
                    b.HasOne("api_aapcmr.Repository.Paciente", "Paciente")
                        .WithMany("ComposicaoFamiliares")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("api_aapcmr.Repository.Paciente", b =>
                {
                    b.HasOne("api_aapcmr.Repository.SituacaoHabitacional", "SituacaoHabitacional")
                        .WithOne("Paciente")
                        .HasForeignKey("api_aapcmr.Repository.Paciente", "SituacaoHabitacionalId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("api_aapcmr.Repository.Usuario", "Usuario")
                        .WithMany("Pacientes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("SituacaoHabitacional");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("api_aapcmr.Repository.PerfilUsuario", b =>
                {
                    b.HasOne("api_aapcmr.Repository.Usuario", "Usuario")
                        .WithOne("PerfilUsuario")
                        .HasForeignKey("api_aapcmr.Repository.PerfilUsuario", "UsuarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("api_aapcmr.Repository.TratamentoPaciente", b =>
                {
                    b.HasOne("api_aapcmr.Repository.Paciente", "Paciente")
                        .WithMany("TratamentoPacientes")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("api_aapcmr.Repository.AcoesApoio", b =>
                {
                    b.Navigation("AcaoApoioSemanais");
                });

            modelBuilder.Entity("api_aapcmr.Repository.Paciente", b =>
                {
                    b.Navigation("ComposicaoFamiliares");

                    b.Navigation("TratamentoPacientes");
                });

            modelBuilder.Entity("api_aapcmr.Repository.SituacaoHabitacional", b =>
                {
                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("api_aapcmr.Repository.Usuario", b =>
                {
                    b.Navigation("Pacientes");

                    b.Navigation("PerfilUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}
