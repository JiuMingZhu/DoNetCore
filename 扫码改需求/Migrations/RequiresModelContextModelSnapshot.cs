﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using 扫码改需求.Models;

namespace 扫码改需求.Migrations
{
    [DbContext(typeof(RequiresModelContext))]
    partial class RequiresModelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("扫码改需求.Models.RequireModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ConfirmStatus");

                    b.Property<string>("ContactPerson");

                    b.Property<string>("ContactTel");

                    b.Property<string>("Content");

                    b.Property<DateTime>("LastestDate");

                    b.Property<DateTime>("OriDate");

                    b.Property<int>("Priority");

                    b.Property<string>("Title");

                    b.Property<int>("WorkingStatus");

                    b.HasKey("Id");

                    b.ToTable("RequireModelItems");
                });
#pragma warning restore 612, 618
        }
    }
}
