using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Meus_Livros_WebApplication.Domains;

#nullable disable

namespace Meus_Livros_WebApplication.Contexts
{
    public partial class LivrosContext : DbContext
    {
        public LivrosContext()
        {
        }

        public LivrosContext(DbContextOptions<LivrosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autores { get; set; }
        public virtual DbSet<Editora> Editoras { get; set; }
        public virtual DbSet<Favorito> Favoritos { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Livro> Livros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-IGB2804;Database=Livros;User Id=sa;Password=tavares;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.IdAutor)
                    .HasName("PK__autor__9AE8206AE88F7356");

                entity.ToTable("autor");

                entity.Property(e => e.IdAutor).HasColumnName("idAutor");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Editora>(entity =>
            {
                entity.HasKey(e => e.IdEditora)
                    .HasName("PK__editora__C4FDFFF74396125C");

                entity.ToTable("editora");

                entity.Property(e => e.IdEditora).HasColumnName("idEditora");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Favorito>(entity =>
            {
                entity.HasKey(e => e.IdFav)
                    .HasName("PK__favorito__39C0426F9C7EB491");

                entity.ToTable("favorito");

                entity.Property(e => e.IdFav).HasColumnName("idFav");

                entity.HasOne(d => d.IdEditoraNavigation)
                    .WithMany(p => p.Favoritos)
                    .HasForeignKey(d => d.IdEditora)
                    .HasConstraintName("FK__favorito__IdEdit__4F7CD00D");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdGenero)
                    .HasName("PK__genero__85223DA367A7E059");

                entity.ToTable("genero");

                entity.HasIndex(e => e.Nome, "UQ__genero__6F71C0DCD9622A77")
                    .IsUnique();

                entity.Property(e => e.IdGenero).HasColumnName("idGenero");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Livro>(entity =>
            {
                entity.HasKey(e => e.IdLivro)
                    .HasName("PK__livro__63C546D7B1C8BBCC");

                entity.ToTable("livro");

                entity.HasIndex(e => e.Nome, "UQ__livro__6F71C0DCA7007872")
                    .IsUnique();

                entity.Property(e => e.IdLivro).HasColumnName("idLivro");

                entity.Property(e => e.Capa)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("capa");

                entity.Property(e => e.DataPubli)
                    .HasColumnType("date")
                    .HasColumnName("data_Publi");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(700)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.HasOne(d => d.IdAutorNavigation)
                    .WithMany(p => p.Livros)
                    .HasForeignKey(d => d.IdAutor)
                    .HasConstraintName("FK__livro__IdAutor__4BAC3F29");

                entity.HasOne(d => d.IdEditoraNavigation)
                    .WithMany(p => p.Livros)
                    .HasForeignKey(d => d.IdEditora)
                    .HasConstraintName("FK__livro__IdEditora__4CA06362");

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Livros)
                    .HasForeignKey(d => d.IdGenero)
                    .HasConstraintName("FK__livro__IdGenero__4AB81AF0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
