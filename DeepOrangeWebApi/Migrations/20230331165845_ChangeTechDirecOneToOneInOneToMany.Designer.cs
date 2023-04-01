﻿// <auto-generated />
using DeepOrangeWebApi.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DeepOrangeWebApi.Migrations
{
    [DbContext(typeof(DbContextApp))]
    [Migration("20230331165845_ChangeTechDirecOneToOneInOneToMany")]
    partial class ChangeTechDirecOneToOneInOneToMany
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DeepOrangeWebApi.DAL.Entities.Direction", b =>
                {
                    b.Property<int>("DirectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DirectionId"));

                    b.Property<string>("DirectionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DirectionId");

                    b.ToTable("Directions");
                });

            modelBuilder.Entity("DeepOrangeWebApi.DAL.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DeepOrangeWebApi.DAL.Entities.Technology", b =>
                {
                    b.Property<int>("TechnologyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TechnologyId"));

                    b.Property<int>("DirectionId")
                        .HasColumnType("integer");

                    b.Property<string>("TechnologyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TechnologyId");

                    b.HasIndex("DirectionId");

                    b.ToTable("Technologies");
                });

            modelBuilder.Entity("EmployeeTechnology", b =>
                {
                    b.Property<int>("EmployeesEmployeeId")
                        .HasColumnType("integer");

                    b.Property<int>("TechnologiesTechnologyId")
                        .HasColumnType("integer");

                    b.HasKey("EmployeesEmployeeId", "TechnologiesTechnologyId");

                    b.HasIndex("TechnologiesTechnologyId");

                    b.ToTable("EmployeeTechnologies", (string)null);
                });

            modelBuilder.Entity("DeepOrangeWebApi.DAL.Entities.Technology", b =>
                {
                    b.HasOne("DeepOrangeWebApi.DAL.Entities.Direction", "Direction")
                        .WithMany("Technologies")
                        .HasForeignKey("DirectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Direction");
                });

            modelBuilder.Entity("EmployeeTechnology", b =>
                {
                    b.HasOne("DeepOrangeWebApi.DAL.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeepOrangeWebApi.DAL.Entities.Technology", null)
                        .WithMany()
                        .HasForeignKey("TechnologiesTechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeepOrangeWebApi.DAL.Entities.Direction", b =>
                {
                    b.Navigation("Technologies");
                });
#pragma warning restore 612, 618
        }
    }
}
