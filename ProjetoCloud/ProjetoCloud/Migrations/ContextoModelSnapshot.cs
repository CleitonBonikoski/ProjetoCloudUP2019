﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoCloud.Models;

namespace ProjetoCloud.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjetoCloud.Models.Ambiente", b =>
                {
                    b.Property<int>("Id_Ambiente")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data_Cadastro_Ambiente");

                    b.Property<string>("Nome_Ambiente");

                    b.Property<int>("Qtda_Dispositivo_Ambiente");

                    b.Property<int?>("UsuarioId_Usuario");

                    b.HasKey("Id_Ambiente");

                    b.HasIndex("UsuarioId_Usuario");

                    b.ToTable("Ambiente");
                });

            modelBuilder.Entity("ProjetoCloud.Models.Dispositivo", b =>
                {
                    b.Property<int>("Id_Dispositivo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AmbienteId_Ambiente");

                    b.Property<DateTime>("Data_Cadastro_Dispositivo");

                    b.Property<string>("Nome_Dispositivo");

                    b.Property<bool>("Status_Dispositivo");

                    b.HasKey("Id_Dispositivo");

                    b.HasIndex("AmbienteId_Ambiente");

                    b.ToTable("Dispositivo");
                });

            modelBuilder.Entity("ProjetoCloud.Models.Plano", b =>
                {
                    b.Property<int>("Id_Plano")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data_Cadastro_Plano");

                    b.Property<string>("Nome_Plano");

                    b.Property<int>("Qtde_Max_Dispositivos_Plano");

                    b.Property<decimal>("Valor_Plano");

                    b.HasKey("Id_Plano");

                    b.ToTable("Plano");
                });

            modelBuilder.Entity("ProjetoCloud.Models.Usuario", b =>
                {
                    b.Property<int>("Id_Usuario")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Adm_Usuario");

                    b.Property<int>("CEP_Usuario");

                    b.Property<string>("CPF_Usuario");

                    b.Property<string>("Cartao_Usuario");

                    b.Property<DateTime>("Data_Cadastro_Usuario");

                    b.Property<string>("Email_Usuario");

                    b.Property<string>("Nome_Usuario");

                    b.Property<int?>("Plano_UsuarioId_Plano");

                    b.Property<string>("Senha_Usuario");

                    b.HasKey("Id_Usuario");

                    b.HasIndex("Plano_UsuarioId_Plano");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ProjetoCloud.Models.Ambiente", b =>
                {
                    b.HasOne("ProjetoCloud.Models.Usuario")
                        .WithMany("Ambientes_Usuario")
                        .HasForeignKey("UsuarioId_Usuario");
                });

            modelBuilder.Entity("ProjetoCloud.Models.Dispositivo", b =>
                {
                    b.HasOne("ProjetoCloud.Models.Ambiente")
                        .WithMany("Dispositivos_Ambiente")
                        .HasForeignKey("AmbienteId_Ambiente");
                });

            modelBuilder.Entity("ProjetoCloud.Models.Usuario", b =>
                {
                    b.HasOne("ProjetoCloud.Models.Plano", "Plano_Usuario")
                        .WithMany()
                        .HasForeignKey("Plano_UsuarioId_Plano");
                });
#pragma warning restore 612, 618
        }
    }
}
