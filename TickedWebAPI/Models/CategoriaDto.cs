using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TickedWebAPI.Interfaces;

namespace TickedWebAPI.Models
{
    public class CategoriaDto : IBaseModel
    {
        [Key] 
        public int id { get; set; }
        public string? categoria { get; set; }
        public bool? estado_cat { get; set; }
    }


    public class CategoriaSubcat
    {
        public int id { get; set; }
        public string? categoria { get; set; }
        public bool? estado_Cat { get; set; }
        [NotMapped]
        public object? detalles { get; set; }
    }
}
