using System.ComponentModel.DataAnnotations;

namespace TickedWebAPI.Models
{
    public partial class SubcategoriaDto
    {
        [Key]
        public int Id { get; set; }
        public string SubcategoriaTicked { get; set; } = null!;
        public int CategoriaId { get; set; }
        public bool? EstadoSub { get; set; }

    }

    public partial class SubcategoriaJoin
    {
        public int Id { get; set; }
        public string? Subcategoria { get; set; } = null!;
        public string? Categoria { get; set; }
        public bool? EstadoSub { get; set; }

    }
}
