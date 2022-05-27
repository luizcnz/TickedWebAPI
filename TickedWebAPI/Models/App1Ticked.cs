using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TickedWebAPI.Models
{
    public class App1Ticked
    {
        public string? Numero { get; set; }
        public string? Descripcion { get; set; }
        public string? Adjunto { get; set; }
        public string? Fechacreado { get; set; }
        public string? Fechaatendido { get; set; }
        public string? Estado { get; set; }
        public string? Prioridad { get; set; }
        public string? Subcategoria { get; set; }
        public string? UsuarioSolicitante { get; set; }
        public virtual ICollection<App1DetalleTicked> Detalles { get; set; }
    }

    public class App1TickedPost
    {
        //Pendiente de averiguar si eliminar el campo o no
        //[Required(ErrorMessage = "Se debe ingresar el numero del Ticked")]
        //public string? Numero { get; set; }

        [Required(ErrorMessage = "Se debe dar una descripcion para el Ticked")]
        public string? Descripcion { get; set; }

        //Pendiente de decidir si hacer obligatorio el campo o no
        public string? Adjunto { get; set; }

        [Required(ErrorMessage = "Se debe proporcionar una fecha")]
        public DateTime? Fechacreado { get; set; }

        [Required(ErrorMessage = "Se debe ingresar un nivel de prioridad")]
        public int? PrioridadId { get; set; }

        [Required(ErrorMessage = "Se debe ingresar la subcategoria del Ticked")]
        public int? SubcategoriaId { get; set; }

        [Required(ErrorMessage = "Se debe ingresar el codigo del usuario solicitante")]
        public int? UsuarioSolicitanteId { get; set; }
    }
}
