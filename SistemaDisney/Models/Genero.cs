using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDisney.Models
{
    [Table("Genero")]
    public class Genero
    {
        [Key]
        public int GeneroID { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }

        [DisplayName("Picture")]
        public byte[] Imagen { get; set; }

        // Peliculas asociadas

        public List<Pelicula> Peliculas { get; set; }
    }
}
