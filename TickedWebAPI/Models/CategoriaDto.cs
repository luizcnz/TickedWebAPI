using System.ComponentModel.DataAnnotations;

namespace TickedWebAPI.Models
{
    public partial class CategoriaDto
    {
        [Key]
        public int Id { get; set; }
        public string? CategoriaTicked { get; set; } = null!;
        public bool? EstadoCat { get; set; }
    }


    public partial class CategoriaSubcat
    {
        [Key]
        public int Id { get; set; }
        public string? CategoriaTicked { get; set; } = null!;
        public bool? EstadoCat { get; set; }
        public ICollection<SubcategoriaDto>? Subcategoria { get; set; }
    }
}
