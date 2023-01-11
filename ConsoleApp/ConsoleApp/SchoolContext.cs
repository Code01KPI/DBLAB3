using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp;

public partial class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<AuthorBook> AuthorBooks { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Library> Libraries { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Reader> Readers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=1mn2487rt;Database=School;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("Author_pkey");

            entity.ToTable("Author");

            entity.Property(e => e.AuthorId)
                .ValueGeneratedNever()
                .HasColumnName("author_id");
            entity.Property(e => e.CountryOfOrigin)
                .HasColumnType("character varying")
                .HasColumnName("country_of_origin");
            entity.Property(e => e.FullName)
                .HasColumnType("character varying")
                .HasColumnName("full_name");
        });

        modelBuilder.Entity<AuthorBook>(entity =>
        {
            entity.HasKey(e => e.AuthorBookId).HasName("Author_Book_pkey");

            entity.ToTable("Author_Book");

            entity.Property(e => e.AuthorBookId)
                .ValueGeneratedNever()
                .HasColumnName("author_book_id");
            entity.Property(e => e.AuthorFk).HasColumnName("author_fk");
            entity.Property(e => e.BookFk).HasColumnName("book_fk");

            entity.HasOne(d => d.AuthorFkNavigation).WithMany(p => p.AuthorBooks)
                .HasForeignKey(d => d.AuthorFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("at_ab_fkey");

            entity.HasOne(d => d.BookFkNavigation).WithMany(p => p.AuthorBooks)
                .HasForeignKey(d => d.BookFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bk_ab_fkey");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("Book_pkey");

            entity.ToTable("Book");

            entity.Property(e => e.BookId)
                .ValueGeneratedNever()
                .HasColumnName("book_id");
            entity.Property(e => e.BkLibraryId).HasColumnName("bk_library_id");
            entity.Property(e => e.BookName)
                .HasColumnType("character varying")
                .HasColumnName("book_name");
            entity.Property(e => e.DateOfPublication).HasColumnName("date_of_publication");
            entity.Property(e => e.Genre)
                .HasColumnType("character varying")
                .HasColumnName("genre");
            entity.Property(e => e.NumberOfPages).HasColumnName("number_of_pages");

            entity.HasOne(d => d.BkLibrary).WithMany(p => p.Books)
                .HasForeignKey(d => d.BkLibraryId)
                .HasConstraintName("Book_fkey");
        });

        modelBuilder.Entity<Library>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Library_pkey");

            entity.ToTable("Library");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ActualReturnTime).HasColumnName("actual_return_time");
            entity.Property(e => e.GivingTime).HasColumnName("giving_time");
            entity.Property(e => e.ReturnTime).HasColumnName("return_time");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("Person_pkey");

            entity.ToTable("Person");

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnName("person_id");
            entity.Property(e => e.FullName)
                .HasColumnType("character varying")
                .HasColumnName("full_name");
            entity.Property(e => e.IsHaveTicket).HasColumnName("is_have_ticket");
        });

        modelBuilder.Entity<Reader>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Reader_pkey");

            entity.ToTable("Reader");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.LibraryId).HasColumnName("library_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.TakenBook)
                .HasColumnType("character varying")
                .HasColumnName("taken_book");

            entity.HasOne(d => d.Library).WithMany(p => p.Readers)
                .HasForeignKey(d => d.LibraryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("r_library_fkey");

            entity.HasOne(d => d.Person).WithMany(p => p.Readers)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("p_person_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
