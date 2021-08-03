using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDisney.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Campo obligatorio")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Clave { get; set; }
    }
}
