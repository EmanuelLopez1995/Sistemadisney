using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDisney.Models
{
    [Table("Pelicula")]
    public class Pelicula
    {
        [Key]
        public int PeliculaID { get; set; }

        [DisplayName("Picture")]
        public byte[] Imagen { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Column(TypeName = "varchar(50)")]
        public string Titulo { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaDeCreacion { get; set; }

        [Range(1, 5, ErrorMessage = "La calificacion es del {1} al {2} inclusive")]
        public int Calificacion { get; set; }

        // genero asociado 

        public int GeneroID { get; set; }

        [ForeignKey("GeneroID")]
        public Genero Genero { get; set; }

        // personajes asociados 

        public List<Personaje> Personajes { get; set; }
    }
}
