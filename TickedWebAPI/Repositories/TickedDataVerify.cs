using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TickedWebAPI.Interfaces.Tickeds;
using TickedWebAPI.Models;

namespace TickedWebAPI.Repositories
{
    public class TickedDataVerify : ITickedDataVerify
    {
        private readonly TickedContext tickedContext;
        public TickedDataVerify(TickedContext tickedContext)
        {
            this.tickedContext = tickedContext;
        }
        public string VerificarDatos([FromBody] CrearTickedDto ticked)
        {
            string procedurePrioridad = "[VerifyPrioridad]";
            string procedureSubcategoria = "[GetSubcategoriasById]";
            string procedureUsuario = "[VerifyUsuario]";

            if (ticked.Descripcion == null)
            {
                return "Debe ingresar una descripcion" ;
            }
            var prioridad = this.tickedContext.Prioridades.FromSqlRaw("exec {0} @Id = {1}", procedurePrioridad, ticked.PrioridadId).ToList();
            if (prioridad.Count == 0)
            {
                return "Debe ingresar una prioridad valida";
            }

            var subcategoria = this.tickedContext.SubcategoriasConInnerJoin.FromSqlRaw("exec {0} @Id = {1}", procedureSubcategoria, ticked.SubcategoriaId).ToList();
            if (subcategoria.Count == 0)
            {
                return "Debe ingresar una subcategoria valida";
            }

            var usuario = this.tickedContext.Usuarios.FromSqlRaw("exec {0} @Id = {1}", procedureUsuario, ticked.UsuarioSolicitanteId).ToList();
            if (usuario.Count == 0)
            {
                return "Debe ingresar un usuario valido";
            }

            return null;
        }
    }
}
