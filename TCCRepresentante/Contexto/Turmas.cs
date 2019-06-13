namespace TCCRepresentante.Contexto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Turmas
    {
        [Key]
        public int IDTurma { get; set; }

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }
    }
}
