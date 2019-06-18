﻿// <auto-generated />
using System;
using DAL.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    [DbContext(typeof(CloudContexto))]
    [Migration("20190618002417_InitalMigration")]
    partial class InitalMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Entidades.Ambiente", b =>
                {
                    b.Property<int>("Id_Ambiente")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data_Cadastro_Ambiente");

                    b.Property<string>("Nome_Ambiente")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("Qtda_Dispositivo_Ambiente");

                    b.Property<int?>("UsuarioId_Usuario");

                    b.HasKey("Id_Ambiente");

                    b.HasIndex("UsuarioId_Usuario");

                    b.ToTable("Ambientes");
                });

            modelBuilder.Entity("DAL.Entidades.Dispositivo", b =>
                {
                    b.Property<int>("Id_Dispositivo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AmbienteId_Ambiente");

                    b.Property<DateTime>("Data_Cadastro_Dispositivo");

                    b.Property<string>("Nome_Dispositivo")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<bool>("Status_Dispositivo");

                    b.HasKey("Id_Dispositivo");

                    b.HasIndex("AmbienteId_Ambiente");

                    b.ToTable("Dispositivos");
                });

            modelBuilder.Entity("DAL.Entidades.Plano", b =>
                {
                    b.Property<int>("Id_Plano")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data_Cadastro_Plano");

                    b.Property<string>("Nome_Plano")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("Qtde_Max_Dispositivos_Plano");

                    b.Property<decimal>("Valor_Plano");

                    b.HasKey("Id_Plano");

                    b.ToTable("Planos");
                });

            modelBuilder.Entity("DAL.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id_Usuario")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CEP_Usuario");

                    b.Property<string>("CPF_Usuario");

                    b.Property<string>("Cartao_Usuario");

                    b.Property<DateTime>("Data_Cadastro_Usuario");

                    b.Property<string>("Nome_Usuario")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int?>("Plano_UsuarioId_Plano");

                    b.HasKey("Id_Usuario");

                    b.HasIndex("Plano_UsuarioId_Plano");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("DAL.Entidades.Ambiente", b =>
                {
                    b.HasOne("DAL.Entidades.Usuario", "Usuario")
                        .WithMany("Ambientes_Usuario")
                        .HasForeignKey("UsuarioId_Usuario");
                });

            modelBuilder.Entity("DAL.Entidades.Dispositivo", b =>
                {
                    b.HasOne("DAL.Entidades.Ambiente", "Ambiente")
                        .WithMany("Dispositivos_Ambiente")
                        .HasForeignKey("AmbienteId_Ambiente");
                });

            modelBuilder.Entity("DAL.Entidades.Usuario", b =>
                {
                    b.HasOne("DAL.Entidades.Plano", "Plano_Usuario")
                        .WithMany("UsuariosNoPlano")
                        .HasForeignKey("Plano_UsuarioId_Plano");
                });
#pragma warning restore 612, 618
        }
    }
}
