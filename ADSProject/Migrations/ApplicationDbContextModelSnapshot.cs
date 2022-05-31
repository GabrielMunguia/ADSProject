﻿// <auto-generated />
using ADSProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ADSProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ADSProject.Models.AsignacionGrupoViewModel", b =>
                {
                    b.Property<int>("idAsigacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idEstudiante")
                        .HasColumnType("int");

                    b.Property<int>("idGrupo")
                        .HasColumnType("int");

                    b.HasKey("idAsigacion");

                    b.HasIndex("idEstudiante");

                    b.HasIndex("idGrupo");

                    b.ToTable("AsignacionGrupos");
                });

            modelBuilder.Entity("ADSProject.Models.CarreraViewModel", b =>
                {
                    b.Property<int>("idCarrera")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodigoCarrera")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NombreCarrera")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.HasKey("idCarrera");

                    b.ToTable("Carreras");
                });

            modelBuilder.Entity("ADSProject.Models.EstudianteViewModel", b =>
                {
                    b.Property<int>("idEstudiante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apellidosEstudiante")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("codigoEstudiante")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("correoEstudiante")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<int>("idCarrera")
                        .HasColumnType("int");

                    b.Property<string>("nombresEstudiante")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idEstudiante");

                    b.HasIndex("idCarrera");

                    b.ToTable("Estudiantes");
                });

            modelBuilder.Entity("ADSProject.Models.GrupoViewModel", b =>
                {
                    b.Property<int>("idGrupo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("anio")
                        .HasColumnType("int");

                    b.Property<string>("ciclo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<int>("idCarrera")
                        .HasColumnType("int");

                    b.Property<int>("idMateria")
                        .HasColumnType("int");

                    b.Property<int>("idProfesor")
                        .HasColumnType("int");

                    b.HasKey("idGrupo");

                    b.HasIndex("idCarrera");

                    b.HasIndex("idMateria");

                    b.HasIndex("idProfesor");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("ADSProject.Models.MateriaViewModel", b =>
                {
                    b.Property<int>("idMateria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<int>("idCarrera")
                        .HasColumnType("int");

                    b.Property<string>("nombreMateria")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idMateria");

                    b.HasIndex("idCarrera");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("ADSProject.Models.ProfesorViewModel", b =>
                {
                    b.Property<int>("idProfesor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apellidoProfesor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("correoEstudiante")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("nombreProfesor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idProfesor");

                    b.ToTable("Profesores");
                });

            modelBuilder.Entity("ADSProject.Models.AsignacionGrupoViewModel", b =>
                {
                    b.HasOne("ADSProject.Models.EstudianteViewModel", "Estudiantes")
                        .WithMany("AsignacionGrupos")
                        .HasForeignKey("idEstudiante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ADSProject.Models.GrupoViewModel", "Grupos")
                        .WithMany("AsignacionGrupos")
                        .HasForeignKey("idGrupo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estudiantes");

                    b.Navigation("Grupos");
                });

            modelBuilder.Entity("ADSProject.Models.EstudianteViewModel", b =>
                {
                    b.HasOne("ADSProject.Models.CarreraViewModel", "Carreras")
                        .WithMany()
                        .HasForeignKey("idCarrera")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carreras");
                });

            modelBuilder.Entity("ADSProject.Models.GrupoViewModel", b =>
                {
                    b.HasOne("ADSProject.Models.CarreraViewModel", "Carreras")
                        .WithMany()
                        .HasForeignKey("idCarrera")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ADSProject.Models.MateriaViewModel", "Materias")
                        .WithMany()
                        .HasForeignKey("idMateria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ADSProject.Models.ProfesorViewModel", "Profesores")
                        .WithMany()
                        .HasForeignKey("idProfesor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carreras");

                    b.Navigation("Materias");

                    b.Navigation("Profesores");
                });

            modelBuilder.Entity("ADSProject.Models.MateriaViewModel", b =>
                {
                    b.HasOne("ADSProject.Models.CarreraViewModel", "Carreras")
                        .WithMany()
                        .HasForeignKey("idCarrera")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carreras");
                });

            modelBuilder.Entity("ADSProject.Models.EstudianteViewModel", b =>
                {
                    b.Navigation("AsignacionGrupos");
                });

            modelBuilder.Entity("ADSProject.Models.GrupoViewModel", b =>
                {
                    b.Navigation("AsignacionGrupos");
                });
#pragma warning restore 612, 618
        }
    }
}
