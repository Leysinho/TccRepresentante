namespace TCCRepresentante.Contexto
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TccRepresentantes : DbContext
    {
        public TccRepresentantes()
            : base("name=TccRepresentantes")
        {
        }

        public virtual DbSet<Alunos> Alunos { get; set; }
        public virtual DbSet<LoginUsuarios> LoginUsuarios { get; set; }
        public virtual DbSet<Turmas> Turmas { get; set; }
        public virtual DbSet<Voto> Voto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alunos>()
                .Property(e => e.Aluno)
                .IsUnicode(false);

            modelBuilder.Entity<Alunos>()
                .Property(e => e.Turma)
                .IsUnicode(false);

            modelBuilder.Entity<Alunos>()
                .HasMany(e => e.Voto)
                .WithOptional(e => e.Alunos)
                .HasForeignKey(e => e.Aluno);

            modelBuilder.Entity<LoginUsuarios>()
                .Property(e => e.Usuario)
                .IsUnicode(false);

            modelBuilder.Entity<LoginUsuarios>()
                .Property(e => e.Senha)
                .IsUnicode(false);

            modelBuilder.Entity<Turmas>()
                .Property(e => e.Nome)
                .IsUnicode(false);
        }
    }
}
