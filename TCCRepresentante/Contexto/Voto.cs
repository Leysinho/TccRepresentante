namespace TCCRepresentante.Contexto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Voto")]
    public partial class Voto
    {
        [Key]
        public int candiato { get; set; }

        public int? Aluno { get; set; }

        [Column("Voto")]
        public int Voto1 { get; set; }

        public virtual Alunos Alunos { get; set; }
    }
}
