﻿// <auto-generated />
using System;
using BEAST_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BEASTAPI.Migrations
{
    [DbContext(typeof(BeastContext))]
    partial class BeastContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BEAST_API.Models.Application", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("title");

                    b.HasKey("id");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("BEAST_API.Models.Beast", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("Applicationid");

                    b.Property<string>("firstName");

                    b.Property<string>("lastName");

                    b.Property<long?>("roleid");

                    b.HasKey("id");

                    b.HasIndex("Applicationid");

                    b.HasIndex("roleid");

                    b.ToTable("Beasts");
                });

            modelBuilder.Entity("BEAST_API.Models.Role", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("title");

                    b.HasKey("id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BEAST_API.Models.Beast", b =>
                {
                    b.HasOne("BEAST_API.Models.Application")
                        .WithMany("beasts")
                        .HasForeignKey("Applicationid");

                    b.HasOne("BEAST_API.Models.Role", "role")
                        .WithMany()
                        .HasForeignKey("roleid");
                });
#pragma warning restore 612, 618
        }
    }
}