namespace TickedWebAPI.Models
{
    public partial class App1TickedPost
    {
        public string? Numero { get; set; }
        public string? Descripcion { get; set; }
        public string? Adjunto { get; set; }
        public DateTime? Fechacreado { get; set; }

        public int? EstadoId { get; set; }
        
        public int? PrioridadId { get; set; }
        
        public int? SubcategoriaId { get; set; }
        public int? TecnicoId { get; set; }
        public int? TipoAsistenciaId { get; set; }
        public int? TratamientoId { get; set; }
        public int? UsuarioSolicitanteId { get; set; }
    }
}
