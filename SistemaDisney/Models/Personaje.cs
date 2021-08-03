using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDisney.Models
{
    [Table("Personaje")]
    public class Personaje
    {
        [Key]
        public int PersonajeID { get; set; }

        [DisplayName("Picture")]
        public Byte[] Imagen { get; set; }
        public int Edad { get; set; }
        public decimal Peso { get; set; }

        [Column(TypeName = "varchar(50)")]
        [DataType(DataType.MultilineText)]
        public string Historia { get; set; }

        //Pelicula relacionada

        public int PeliculaID { get; set; }

        [ForeignKey("PeliculaID")]
        public Pelicula Pelicula { get; set; }
    }
}
