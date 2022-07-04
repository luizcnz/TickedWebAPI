using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TickedWebAPI.Models.Entities
{
    public class SubcategoriaModel
    {
        [Key]
        public int id { get; set; }
        public string? subcategoria { get; set; }
        public int? categoria_id { get; set; }
        public bool? estado_Sub { get; set; }

    }

    public class SubcategoriaConInnerJoinModel
    {
        [Key]
        public int id { get; set; }
        public string? subcategoria { get; set; }
        public string? categoria { get; set; }
        public bool? estado_Sub { get; set; }

    }
}
