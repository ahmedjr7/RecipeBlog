﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using RecipeBlog.Models;

#nullable disable

namespace RecipeBlog.Migrations
{
    [DbContext(typeof(ModelContext))]
    partial class ModelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("C##MVCF1")
                .UseCollation("USING_NLS_COMP")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("CATEGORY_SEQ");

            modelBuilder.HasSequence("RECIPE_SEQ");

            modelBuilder.HasSequence("ROLE_SEQ");

            modelBuilder.HasSequence("USER_ID_SEQ");

            modelBuilder.HasSequence("USER_SEQ");

            modelBuilder.Entity("RecipeBlog.Models.Category", b =>
                {
                    b.Property<decimal>("Categoryid")
                        .HasColumnType("NUMBER")
                        .HasColumnName("CATEGORYID");

                    b.Property<string>("Categoryimage")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(255)")
                        .HasColumnName("CATEGORYIMAGE");

                    b.Property<string>("Categoryname")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(100)")
                        .HasColumnName("CATEGORYNAME");

                    b.HasKey("Categoryid")
                        .HasName("SYS_C008420");

                    b.ToTable("CATEGORIES", "C##MVCF1");
                });

            modelBuilder.Entity("RecipeBlog.Models.Chef", b =>
                {
                    b.Property<decimal>("Chefid")
                        .HasColumnType("NUMBER")
                        .HasColumnName("CHEFID");

                    b.Property<DateTime?>("Subscriptionenddate")
                        .HasColumnType("DATE")
                        .HasColumnName("SUBSCRIPTIONENDDATE");

                    b.Property<DateTime?>("Subscriptionstartdate")
                        .HasColumnType("DATE")
                        .HasColumnName("SUBSCRIPTIONSTARTDATE");

                    b.Property<string>("Subscriptiontype")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(10)")
                        .HasColumnName("SUBSCRIPTIONTYPE");

                    b.Property<decimal?>("Userid")
                        .HasColumnType("NUMBER")
                        .HasColumnName("USERID");

                    b.HasKey("Chefid")
                        .HasName("SYS_C008438");

                    b.HasIndex("Userid");

                    b.ToTable("CHEF", "C##MVCF1");
                });

            modelBuilder.Entity("RecipeBlog.Models.Feedback", b =>
                {
                    b.Property<decimal>("Feedbackid")
                        .HasColumnType("NUMBER")
                        .HasColumnName("FEEDBACKID");

                    b.Property<DateTime?>("Postedat")
                        .HasColumnType("DATE")
                        .HasColumnName("POSTEDAT");

                    b.Property<decimal?>("Recipeid")
                        .HasColumnType("NUMBER")
                        .HasColumnName("RECIPEID");

                    b.Property<string>("Usercomment")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(255)")
                        .HasColumnName("USERCOMMENT");

                    b.Property<decimal?>("Userid")
                        .HasColumnType("NUMBER")
                        .HasColumnName("USERID");

                    b.HasKey("Feedbackid")
                        .HasName("SYS_C008428");

                    b.HasIndex("Recipeid");

                    b.HasIndex("Userid");

                    b.ToTable("FEEDBACK", "C##MVCF1");
                });

            modelBuilder.Entity("RecipeBlog.Models.Giftcard", b =>
                {
                    b.Property<decimal>("Cardid")
                        .HasColumnType("NUMBER")
                        .HasColumnName("CARDID");

                    b.Property<DateTime?>("Activationdate")
                        .HasColumnType("DATE")
                        .HasColumnName("ACTIVATIONDATE");

                    b.Property<decimal?>("Balance")
                        .HasColumnType("NUMBER(10,2)")
                        .HasColumnName("BALANCE");

                    b.Property<DateTime?>("Expirationdate")
                        .HasColumnType("DATE")
                        .HasColumnName("EXPIRATIONDATE");

                    b.Property<decimal?>("Userid")
                        .HasColumnType("NUMBER")
                        .HasColumnName("USERID");

                    b.HasKey("Cardid")
                        .HasName("SYS_C008426");

                    b.HasIndex("Userid");

                    b.ToTable("GIFTCARDS", "C##MVCF1");
                });

            modelBuilder.Entity("RecipeBlog.Models.Payment", b =>
                {
                    b.Property<decimal>("Paymentid")
                        .HasColumnType("NUMBER")
                        .HasColumnName("PAYMENTID");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("NUMBER(10,2)")
                        .HasColumnName("AMOUNT");

                    b.Property<DateTime?>("Cardexpirydate")
                        .HasColumnType("DATE")
                        .HasColumnName("CARDEXPIRYDATE");

                    b.Property<string>("Cardholdername")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(100)")
                        .HasColumnName("CARDHOLDERNAME");

                    b.Property<string>("Cardid")
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(16)")
                        .HasColumnName("CARDID");

                    b.Property<string>("Cardsecuritynumber")
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(3)")
                        .HasColumnName("CARDSECURITYNUMBER");

                    b.Property<string>("Paymentstatus")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(50)")
                        .HasColumnName("PAYMENTSTATUS");

                    b.Property<decimal?>("Recipeid")
                        .HasColumnType("NUMBER")
                        .HasColumnName("RECIPEID");

                    b.Property<DateTime?>("Transactiondate")
                        .HasColumnType("DATE")
                        .HasColumnName("TRANSACTIONDATE");

                    b.Property<decimal?>("Userid")
                        .HasColumnType("NUMBER")
                        .HasColumnName("USERID");

                    b.HasKey("Paymentid")
                        .HasName("SYS_C008434");

                    b.HasIndex("Recipeid");

                    b.HasIndex("Userid");

                    b.HasIndex(new[] { "Cardid" }, "SYS_C008435")
                        .IsUnique()
                        .HasFilter("\"CARDID\" IS NOT NULL");

                    b.ToTable("PAYMENTS", "C##MVCF1");
                });

            modelBuilder.Entity("RecipeBlog.Models.Recipe", b =>
                {
                    b.Property<decimal>("Recipeid")
                        .HasColumnType("NUMBER")
                        .HasColumnName("RECIPEID");

                    b.Property<DateTime?>("Addedtime")
                        .HasColumnType("DATE")
                        .HasColumnName("ADDEDTIME");

                    b.Property<decimal?>("Categoryid")
                        .HasColumnType("NUMBER")
                        .HasColumnName("CATEGORYID");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(255)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("Ingredients")
                        .HasColumnType("CLOB")
                        .HasColumnName("INGREDIENTS");

                    b.Property<string>("Instructions")
                        .HasColumnType("CLOB")
                        .HasColumnName("INSTRUCTIONS");

                    b.Property<string>("Mainimage")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(255)")
                        .HasColumnName("MAINIMAGE");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(100)")
                        .HasColumnName("NAME");

                    b.Property<decimal?>("Price")
                        .HasColumnType("NUMBER(10,2)")
                        .HasColumnName("PRICE");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(50)")
                        .HasColumnName("STATUS");

                    b.Property<decimal?>("Userid")
                        .HasColumnType("NUMBER")
                        .HasColumnName("USERID");

                    b.HasKey("Recipeid")
                        .HasName("SYS_C008421");

                    b.HasIndex("Categoryid");

                    b.HasIndex("Userid");

                    b.ToTable("RECIPES", "C##MVCF1");
                });

            modelBuilder.Entity("RecipeBlog.Models.Recipesale", b =>
                {
                    b.Property<decimal>("Saleid")
                        .HasColumnType("NUMBER")
                        .HasColumnName("SALEID");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("NUMBER(10,2)")
                        .HasColumnName("AMOUNT");

                    b.Property<decimal?>("Recipeid")
                        .HasColumnType("NUMBER")
                        .HasColumnName("RECIPEID");

                    b.Property<DateTime?>("Saledate")
                        .HasColumnType("DATE")
                        .HasColumnName("SALEDATE");

                    b.Property<decimal?>("Userid")
                        .HasColumnType("NUMBER")
                        .HasColumnName("USERID");

                    b.HasKey("Saleid")
                        .HasName("SYS_C008431");

                    b.HasIndex("Recipeid");

                    b.HasIndex("Userid");

                    b.ToTable("RECIPESALES", "C##MVCF1");
                });

            modelBuilder.Entity("RecipeBlog.Models.Role", b =>
                {
                    b.Property<decimal>("Roleid")
                        .HasColumnType("NUMBER")
                        .HasColumnName("ROLEID");

                    b.Property<string>("Rolename")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(50)")
                        .HasColumnName("ROLENAME");

                    b.HasKey("Roleid")
                        .HasName("SYS_C008415");

                    b.ToTable("ROLES", "C##MVCF1");
                });

            modelBuilder.Entity("RecipeBlog.Models.Testimonial", b =>
                {
                    b.Property<decimal>("Testimonialid")
                        .HasColumnType("NUMBER")
                        .HasColumnName("TESTIMONIALID");

                    b.Property<string>("Testimonialcontent")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(255)")
                        .HasColumnName("TESTIMONIALCONTENT");

                    b.Property<decimal?>("Userid")
                        .HasColumnType("NUMBER")
                        .HasColumnName("USERID");

                    b.HasKey("Testimonialid")
                        .HasName("SYS_C008424");

                    b.HasIndex("Userid");

                    b.ToTable("TESTIMONIALS", "C##MVCF1");
                });

            modelBuilder.Entity("RecipeBlog.Models.User", b =>
                {
                    b.Property<decimal>("Userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER")
                        .HasColumnName("USERID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Userid"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(100)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(255)")
                        .HasColumnName("PASSWORD");

                    b.Property<string>("Profileimage")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(255)")
                        .HasColumnName("PROFILEIMAGE");

                    b.Property<decimal?>("Roleid")
                        .HasColumnType("NUMBER")
                        .HasColumnName("ROLEID");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(50)")
                        .HasColumnName("USERNAME");

                    b.HasKey("Userid")
                        .HasName("SYS_C008416");

                    b.HasIndex("Roleid");

                    b.HasIndex(new[] { "Username" }, "SYS_C008417")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "SYS_C008418")
                        .IsUnique();

                    b.ToTable("USERS", "C##MVCF1");
                });

            modelBuilder.Entity("RecipeBlog.Models.Chef", b =>
                {
                    b.HasOne("RecipeBlog.Models.User", "User")
                        .WithMany("Chefs")
                        .HasForeignKey("Userid")
                        .HasConstraintName("SYS_C008439");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RecipeBlog.Models.Feedback", b =>
                {
                    b.HasOne("RecipeBlog.Models.Recipe", "Recipe")
                        .WithMany("Feedbacks")
                        .HasForeignKey("Recipeid")
                        .HasConstraintName("SYS_C008429");

                    b.HasOne("RecipeBlog.Models.User", "User")
                        .WithMany("Feedbacks")
                        .HasForeignKey("Userid")
                        .HasConstraintName("SYS_C008430");

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RecipeBlog.Models.Giftcard", b =>
                {
                    b.HasOne("RecipeBlog.Models.User", "User")
                        .WithMany("Giftcards")
                        .HasForeignKey("Userid")
                        .HasConstraintName("SYS_C008427");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RecipeBlog.Models.Payment", b =>
                {
                    b.HasOne("RecipeBlog.Models.Recipe", "Recipe")
                        .WithMany("Payments")
                        .HasForeignKey("Recipeid")
                        .HasConstraintName("SYS_C008437");

                    b.HasOne("RecipeBlog.Models.User", "User")
                        .WithMany("Payments")
                        .HasForeignKey("Userid")
                        .HasConstraintName("SYS_C008436");

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RecipeBlog.Models.Recipe", b =>
                {
                    b.HasOne("RecipeBlog.Models.Category", "Category")
                        .WithMany("Recipes")
                        .HasForeignKey("Categoryid")
                        .HasConstraintName("SYS_C008423");

                    b.HasOne("RecipeBlog.Models.User", "User")
                        .WithMany("Recipes")
                        .HasForeignKey("Userid")
                        .HasConstraintName("SYS_C008422");

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RecipeBlog.Models.Recipesale", b =>
                {
                    b.HasOne("RecipeBlog.Models.Recipe", "Recipe")
                        .WithMany("Recipesales")
                        .HasForeignKey("Recipeid")
                        .HasConstraintName("SYS_C008433");

                    b.HasOne("RecipeBlog.Models.User", "User")
                        .WithMany("Recipesales")
                        .HasForeignKey("Userid")
                        .HasConstraintName("SYS_C008432");

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RecipeBlog.Models.Testimonial", b =>
                {
                    b.HasOne("RecipeBlog.Models.User", "User")
                        .WithMany("Testimonials")
                        .HasForeignKey("Userid")
                        .HasConstraintName("SYS_C008425");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RecipeBlog.Models.User", b =>
                {
                    b.HasOne("RecipeBlog.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("Roleid")
                        .HasConstraintName("SYS_C008419");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("RecipeBlog.Models.Category", b =>
                {
                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("RecipeBlog.Models.Recipe", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Payments");

                    b.Navigation("Recipesales");
                });

            modelBuilder.Entity("RecipeBlog.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("RecipeBlog.Models.User", b =>
                {
                    b.Navigation("Chefs");

                    b.Navigation("Feedbacks");

                    b.Navigation("Giftcards");

                    b.Navigation("Payments");

                    b.Navigation("Recipes");

                    b.Navigation("Recipesales");

                    b.Navigation("Testimonials");
                });
#pragma warning restore 612, 618
        }
    }
}