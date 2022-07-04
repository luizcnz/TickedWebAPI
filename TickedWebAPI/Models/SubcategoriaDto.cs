using System.ComponentModel.DataAnnotations;

namespace TickedWebAPI.Models
{
    public class SubcategoriaDto
    {
        public int id { get; set; }
        public string? subcategoria { get; set; }
        public int? categoria_id { get; set; }
        public bool? estado_Sub { get; set; }

    }

    public class SubcategoriaConInnerJoinDto
    {
        [Key]
        public int id { get; set; }
        public string? subcategoria { get; set; }
        public string? categoria { get; set; }
        public bool? estado_Sub { get; set; }

    }
}
