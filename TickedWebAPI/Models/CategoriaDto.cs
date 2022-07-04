using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TickedWebAPI.Interfaces;

namespace TickedWebAPI.Models
{
    public class CategoriaDto
    {
        [Key] 
        public int id { get; set; }
        public string? categoria { get; set; }
        public bool? estado_cat { get; set; }
    }


    public class CategoriaConSubcategoriasDto
    {
        public int id { get; set; }
        public string? categoria { get; set; }
        public bool? estado_Cat { get; set; }
        [NotMapped]
        public object? detalles { get; set; }
    }
}
