using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Proba1.Models;

namespace Proba1.Migrations
{
    [DbContext(typeof(DbDataContext))]
    [Migration("20170718084059_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Proba1.Models.Tovar", b =>
                {
                    b.Property<int>("TovarId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Cena");

                    b.Property<int>("Kod");

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.HasKey("TovarId");

                    b.ToTable("Tovars");
                });
        }
    }
}
