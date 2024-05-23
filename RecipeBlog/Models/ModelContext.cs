using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RecipeBlog.Models;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Chef> Chefs { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Giftcard> Giftcards { get; set; }

    public virtual DbSet<Pagecontent> Pagecontents { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<Recipesale> Recipesales { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Testimonial> Testimonials { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("USER ID=C##MVCF1;PASSWORD=ahmed8899500;DATA SOURCE=localhost:1521/xe");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("C##MVCF1")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Categoryid).HasName("SYS_C008420");

            entity.ToTable("CATEGORIES");

            entity.Property(e => e.Categoryid)
                .HasColumnType("NUMBER")
                .HasColumnName("CATEGORYID");
            entity.Property(e => e.Categoryimage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CATEGORYIMAGE");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CATEGORYNAME");
        });

        modelBuilder.Entity<Chef>(entity =>
        {
            entity.HasKey(e => e.Chefid).HasName("SYS_C008438");

            entity.ToTable("CHEF");

            entity.Property(e => e.Chefid)
                .HasColumnType("NUMBER")
                .HasColumnName("CHEFID");
            entity.Property(e => e.Subscriptionenddate)
                .HasColumnType("DATE")
                .HasColumnName("SUBSCRIPTIONENDDATE");
            entity.Property(e => e.Subscriptionstartdate)
                .HasColumnType("DATE")
                .HasColumnName("SUBSCRIPTIONSTARTDATE");
            entity.Property(e => e.Subscriptiontype)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SUBSCRIPTIONTYPE");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER")
                .HasColumnName("USERID");

            entity.HasOne(d => d.User).WithMany(p => p.Chefs)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("SYS_C008439");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Feedbackid).HasName("SYS_C008428");

            entity.ToTable("FEEDBACK");

            entity.Property(e => e.Feedbackid)
                .HasColumnType("NUMBER")
                .HasColumnName("FEEDBACKID");
            entity.Property(e => e.Postedat)
                .HasColumnType("DATE")
                .HasColumnName("POSTEDAT");
            entity.Property(e => e.Recipeid)
                .HasColumnType("NUMBER")
                .HasColumnName("RECIPEID");
            entity.Property(e => e.Usercomment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("USERCOMMENT");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER")
                .HasColumnName("USERID");

            entity.HasOne(d => d.Recipe).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.Recipeid)
                .HasConstraintName("SYS_C008429");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("SYS_C008430");
        });

        modelBuilder.Entity<Giftcard>(entity =>
        {
            entity.HasKey(e => e.Cardid).HasName("SYS_C008426");

            entity.ToTable("GIFTCARDS");

            entity.Property(e => e.Cardid)
                .HasColumnType("NUMBER")
                .HasColumnName("CARDID");
            entity.Property(e => e.Activationdate)
                .HasColumnType("DATE")
                .HasColumnName("ACTIVATIONDATE");
            entity.Property(e => e.Balance)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("BALANCE");
            entity.Property(e => e.Expirationdate)
                .HasColumnType("DATE")
                .HasColumnName("EXPIRATIONDATE");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER")
                .HasColumnName("USERID");

            entity.HasOne(d => d.User).WithMany(p => p.Giftcards)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("SYS_C008427");
        });

        modelBuilder.Entity<Pagecontent>(entity =>
        {
            entity.HasKey(e => e.Pagecontentid).HasName("SYS_C008443");

            entity.ToTable("PAGECONTENT");

            entity.Property(e => e.Pagecontentid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PAGECONTENTID");
            entity.Property(e => e.Contentkey)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CONTENTKEY");
            entity.Property(e => e.Contentvalue)
                .HasColumnType("CLOB")
                .HasColumnName("CONTENTVALUE");
            entity.Property(e => e.Pagename)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PAGENAME");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Paymentid).HasName("SYS_C008434");

            entity.ToTable("PAYMENTS");

            entity.HasIndex(e => e.Cardid, "SYS_C008435").IsUnique();

            entity.Property(e => e.Paymentid)
                .HasColumnType("NUMBER")
                .HasColumnName("PAYMENTID");
            entity.Property(e => e.Amount)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("AMOUNT");
            entity.Property(e => e.Cardexpirydate)
                .HasColumnType("DATE")
                .HasColumnName("CARDEXPIRYDATE");
            entity.Property(e => e.Cardholdername)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CARDHOLDERNAME");
            entity.Property(e => e.Cardid)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("CARDID");
            entity.Property(e => e.Cardsecuritynumber)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("CARDSECURITYNUMBER");
            entity.Property(e => e.Paymentstatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PAYMENTSTATUS");
            entity.Property(e => e.Recipeid)
                .HasColumnType("NUMBER")
                .HasColumnName("RECIPEID");
            entity.Property(e => e.Transactiondate)
                .HasColumnType("DATE")
                .HasColumnName("TRANSACTIONDATE");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER")
                .HasColumnName("USERID");

            entity.HasOne(d => d.Recipe).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Recipeid)
                .HasConstraintName("SYS_C008437");

            entity.HasOne(d => d.User).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("SYS_C008436");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.Recipeid).HasName("SYS_C008421");

            entity.ToTable("RECIPES");

            entity.Property(e => e.Recipeid)
                .HasColumnType("NUMBER")
                .HasColumnName("RECIPEID");

            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STATUS")
                .HasConversion(
                    v => v.ToString(),
                    v => (Recipe.RecipeStatus)Enum.Parse(typeof(Recipe.RecipeStatus), v));

            entity.Property(e => e.Addedtime)
                .HasColumnType("DATE")
                .HasColumnName("ADDEDTIME");

            entity.Property(e => e.Categoryid)
                .HasColumnType("NUMBER")
                .HasColumnName("CATEGORYID");

            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");

            entity.Property(e => e.Ingredients)
                .HasColumnType("CLOB")
                .HasColumnName("INGREDIENTS");

            entity.Property(e => e.Instructions)
                .HasColumnType("CLOB")
                .HasColumnName("INSTRUCTIONS");

            entity.Property(e => e.Mainimage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("MAINIMAGE");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");

            entity.Property(e => e.Price)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("PRICE");

            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER")
                .HasColumnName("USERID");

            entity.HasOne(d => d.Category).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.Categoryid)
                .HasConstraintName("SYS_C008423");

            entity.HasOne(d => d.User).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("SYS_C008422");
        });

        modelBuilder.Entity<Recipesale>(entity =>
        {
            entity.HasKey(e => new { e.Recipeid, e.Userid, e.Saledate });

            entity.ToTable("RECIPESALES");

            entity.HasIndex(e => e.Saleid, "UNIQUE_SALEID").IsUnique();

            entity.Property(e => e.Recipeid)
                .HasColumnType("NUMBER")
                .HasColumnName("RECIPEID");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER")
                .HasColumnName("USERID");
            entity.Property(e => e.Saledate)
                .HasColumnType("DATE")
                .HasColumnName("SALEDATE");
            entity.Property(e => e.Amount)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("AMOUNT");
            entity.Property(e => e.Saleid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("SALEID");

            entity.HasOne(d => d.Recipe).WithMany(p => p.Recipesales)
                .HasForeignKey(d => d.Recipeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C008433");

            entity.HasOne(d => d.User).WithMany(p => p.Recipesales)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C008432");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("SYS_C008415");

            entity.ToTable("ROLES");

            entity.Property(e => e.Roleid)
                .HasColumnType("NUMBER")
                .HasColumnName("ROLEID");
            entity.Property(e => e.Rolename)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROLENAME");
        });

        modelBuilder.Entity<Testimonial>(entity =>
        {
            entity.HasKey(e => e.Testimonialid).HasName("SYS_C008424");

            entity.ToTable("TESTIMONIALS");

            entity.Property(e => e.Testimonialid)
                .HasColumnType("NUMBER")
                .HasColumnName("TESTIMONIALID");
            entity.Property(e => e.Testimonialcontent)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TESTIMONIALCONTENT");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER")
                .HasColumnName("USERID");

            entity.HasOne(d => d.User).WithMany(p => p.Testimonials)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("FK_TESTIMONIALS_USERS");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("SYS_C008416");

            entity.ToTable("USERS");

            entity.HasIndex(e => e.Username, "SYS_C008417").IsUnique();

            entity.HasIndex(e => e.Email, "SYS_C008418").IsUnique();

            entity.Property(e => e.Userid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("USERID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Profileimage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PROFILEIMAGE");
            entity.Property(e => e.Roleid)
                .HasColumnType("NUMBER")
                .HasColumnName("ROLEID");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USERNAME");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.Roleid)
                .HasConstraintName("SYS_C008419");
        });
        modelBuilder.HasSequence("CATEGORY_SEQ");
        modelBuilder.HasSequence("PAGECONTENTSEQ");
        modelBuilder.HasSequence("RECIPE_SEQ");
        modelBuilder.HasSequence("ROLE_SEQ");
        modelBuilder.HasSequence("SALEID_SEQ");
        modelBuilder.HasSequence("USER_ID_SEQ");
        modelBuilder.HasSequence("USER_SEQ");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
