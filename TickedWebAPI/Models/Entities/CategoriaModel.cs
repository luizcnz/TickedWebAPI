using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TickedWebAPI.Models.Entities
{
    public class CategoriaModel
    {
        [Key]
        public int id { get; set; }
        public string? categoria { get; set; }
        public bool? estado_cat { get; set; }
    }
    public class CategoriaConSubcategoriasModel
    {
        public int id { get; set; }
        public string? categoria { get; set; }
        public bool? estado_Cat { get; set; }
        [NotMapped]
        public object? detalles { get; set; }
    }
}