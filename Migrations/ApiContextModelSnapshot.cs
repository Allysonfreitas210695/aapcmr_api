﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_aapcmr.Config;

#nullable disable

namespace api_aapcmr.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("api_aapcmr.Repository.MovimentacaoGasto", b =>
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

                    b.ToTable("MovimentacaoGastos", (string)null);
                });

            modelBuilder.Entity("api_aapcmr.Repository.Paciente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<bool>("CestaBasica")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cidade")
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<string>("Complemento")
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

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

                    b.Property<string>("Logradouro")
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<string>("Naturalidade")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<long>("Numero")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SUSNumero")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("StatusCivil")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("TEXT");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

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

                    b.Property<string>("Diagnostico")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Medico")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<long>("PacienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StatusTratamento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoCirurgia")
                        .HasColumnType("TEXT");

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

            modelBuilder.Entity("api_aapcmr.Repository.Paciente", b =>
                {
                    b.HasOne("api_aapcmr.Repository.Usuario", "Usuario")
                        .WithMany("Pacientes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

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
                    b.Navigation("TratamentoPacientes");
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
