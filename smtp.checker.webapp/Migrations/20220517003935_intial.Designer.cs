// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using smtp.checker.webapp.Models;

namespace smtp.checker.webapp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220517003935_intial")]
    partial class intial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.14");

            modelBuilder.Entity("smtp.checker.webapp.Models.SendEmailLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EmailFrom")
                        .HasColumnType("longtext");

                    b.Property<string>("EmailTo")
                        .HasColumnType("longtext");

                    b.Property<bool>("EnableSsl")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Host")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsBodyHtml")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("StatusMessage")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("SendEmailLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
