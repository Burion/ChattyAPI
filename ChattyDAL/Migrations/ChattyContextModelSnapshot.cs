﻿// <auto-generated />
using System;
using ChattyDAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChattyDAL.Migrations
{
    [DbContext(typeof(ChattyContext))]
    partial class ChattyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ChattyDAL.Models.Message", b =>
                {
                    b.Property<string>("AuthorLogin")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ReceiverLogin")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("SendingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AttachedImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorLogin", "ReceiverLogin", "SendingDate");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ChattyDAL.Models.User", b =>
                {
                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DisplyedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicturePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Login");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
