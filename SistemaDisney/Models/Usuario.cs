using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDisney.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int IdUusario { get; set; }

        [Required(ErrorMessage ="Campo obligatorio")]
        [Column(TypeName = "varchar(50)")]
        public string User { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Column(TypeName = "varchar(50)")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage ="Las contraseñas no coinciden")]
        [NotMapped]
        [Column(TypeName = "varchar(50)")]
        public string ConfirmaClave { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Sal { get; set; }
    }
}
