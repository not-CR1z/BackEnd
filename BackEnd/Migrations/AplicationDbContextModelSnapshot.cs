﻿// <auto-generated />
using System;
using BackEnd.Persistence.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace BackEnd.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    partial class AplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackEnd.Domain.Models.Cuestionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Activo")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.ToTable("Cuestionario");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.Pregunta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CuestionarioId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CuestionarioId");

                    b.ToTable("Pregunta");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.Respuesta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("EsCorrecta")
                        .HasColumnType("NUMBER(1)");

                    b.Property<int>("PreguntaId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("PreguntaId");

                    b.ToTable("Respuesta");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.Pregunta", b =>
                {
                    b.HasOne("BackEnd.Domain.Models.Cuestionario", null)
                        .WithMany("listPreguntas")
                        .HasForeignKey("CuestionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEnd.Domain.Models.Respuesta", b =>
                {
                    b.HasOne("BackEnd.Domain.Models.Pregunta", null)
                        .WithMany("listRespuestas")
                        .HasForeignKey("PreguntaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEnd.Domain.Models.Cuestionario", b =>
                {
                    b.Navigation("listPreguntas");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.Pregunta", b =>
                {
                    b.Navigation("listRespuestas");
                });
#pragma warning restore 612, 618
        }
    }
}
