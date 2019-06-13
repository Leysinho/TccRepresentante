namespace TCCRepresentante.Contexto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LoginUsuarios
    {
        [Key]
        [StringLength(30)]
        public string Usuario { get; set; }

        [Required]
        [StringLength(30)]
        public string Senha { get; set; }
    }
}
