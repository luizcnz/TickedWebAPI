using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using TickedWebAPI.Models;


using System.Data;
using System.Threading.Tasks;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TickedWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TickedController : ControllerBase
    {
        private readonly tickedContext context;
        

        public TickedController(tickedContext context)
        {
            this.context = context;
        }

        #region obtener tickeds sin llaves foraneas
        // GET: api/<TickedController>
        //[HttpGet]
        //public List<TickedGET> GetList()
        //{

        //    SqlConnection connString = new SqlConnection();

        //    connString.ConnectionString = @"Server =localhost; Database = ticked; Trusted_Connection = True;";

        //    connString.Open();

        //    string procedureName = "[obtenerTickeds]";
        //    var result = new List<TickedGET>();
        //    using (SqlCommand command = new SqlCommand(procedureName,
        //    connString))
        //    {
        //        command.CommandType = CommandType.StoredProcedure;
        //        //command.Parameters.Add(new SqlParameter("@estado", 4));

        //        using (SqlDataReader? reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                int? id = reader.GetIntOrNull(0);
        //                string? numero = reader.GetStringOrNull(1);
        //                string? descripcion = reader.GetStringOrNull(2);
        //                string? adjunto = reader.GetStringOrNull(3);
        //                DateTime? fechacreado = reader.GetDateOrNull(4);
        //                DateTime? fechaAtendido = reader.GetDateOrNull(5);
        //                int? estadoread = reader.GetIntOrNull(6);
        //                int? prioridad = reader.GetIntOrNull(7);
        //                int? subcategoria = reader.GetIntOrNull(7);
        //                int? tecnico = reader.GetIntOrNull(9);
        //                int? tipoAsistencia = reader.GetIntOrNull(10);
        //                int? tratamiento = reader.GetIntOrNull(11);
        //                int? usuarioSolicitante = reader.GetIntOrNull(12);

        //                TickedGET tmpRecord = new TickedGET()
        //                {
        //                    Id = id,
        //                    Numero = numero,
        //                    Descripcion = descripcion,
        //                    Adjunto = adjunto,
        //                    Fechacreado = fechacreado,
        //                    FechaAtendido = fechaAtendido,
        //                    Estado = estadoread,
        //                    Prioridad = prioridad,
        //                    Subcategoria = subcategoria,
        //                    Tecnico = tecnico,
        //                    TipoAsistencia = tipoAsistencia,
        //                    Tratamiento = tratamiento,
        //                    UsuarioSolicitante = usuarioSolicitante

        //            };
        //            result.Add(tmpRecord);
        //            }
        //        }
        //    }
        //    return result;
        //}
        #endregion

        #region obtener tickeds con llaves foraneas
        // GET: api/<TickedController>
        [HttpGet]
        public List<TickedGETJoin> GetList()
        {

            SqlConnection connString = new SqlConnection();

            connString.ConnectionString = @"Server =localhost; Database = ticked; Trusted_Connection = True;";

            connString.Open();

            string procedureName = "[getTickeds]";
            var result = new List<TickedGETJoin>();
            using (SqlCommand command = new SqlCommand(procedureName,
            connString))
            {
                command.CommandType = CommandType.StoredProcedure;
                //command.Parameters.Add(new SqlParameter("@estado", 4));

                using (SqlDataReader? reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int? id = reader.GetIntOrNull(0);
                        string? numero = reader.GetStringOrNull(1);
                        string? descripcion = reader.GetStringOrNull(2);
                        string? adjunto = reader.GetStringOrNull(3);
                        DateTime? fechacreado = reader.GetDateOrNull(4);
                        DateTime? fechaAtendido = reader.GetDateOrNull(5);
                        string? estadoread = reader.GetStringOrNull(6);
                        string? prioridad = reader.GetStringOrNull(7);
                        string? subcategoria = reader.GetStringOrNull(7);
                        string? tecnico = reader.GetStringOrNull(9);
                        string? tipoAsistencia = reader.GetStringOrNull(10);
                        string? tratamiento = reader.GetStringOrNull(11);
                        string? usuarioSolicitante = reader.GetStringOrNull(12);

                        TickedGETJoin tmpRecord = new TickedGETJoin()
                        {
                            Id = id,
                            Numero = numero,
                            Descripcion = descripcion,
                            Adjunto = adjunto,
                            Fechacreado = fechacreado,
                            FechaAtendido = fechaAtendido,
                            Estado = estadoread,
                            Prioridad = prioridad,
                            Subcategoria = subcategoria,
                            Tecnico = tecnico,
                            TipoAsistencia = tipoAsistencia,
                            Tratamiento = tratamiento,
                            UsuarioSolicitante = usuarioSolicitante

                        };
                        result.Add(tmpRecord);
                    }
                }
            }
            return result;
        }
        #endregion

        #region metodo post procedimiento almacenado en codigo
        // POST api/<TickedController>
        //[HttpPost]
        //public ActionResult Post([FromBody]App1TickedPost ticked)
        //{

        //    string connString = @"Server =localhost; Database = ticked; Trusted_Connection = True;";

        //    int Estado, Prioridad, Subcategoria, Tecnico, TipoAsistencia, Tratamiento, UsuarioSolicitante;
        //    DateTime Fechacreado, FechaAtendido, FechaCerrado;
        //    string Adjunto, Descripcion, Numero;

        //    Numero = ticked.Numero;
        //    Descripcion = ticked.Descripcion;
        //    Adjunto = ticked.Adjunto;
        //    Fechacreado = (DateTime)ticked.Fechacreado;
        //    Estado = (int)ticked.EstadoId;
        //    Prioridad = (int)ticked.PrioridadId;
        //    Subcategoria = (int)ticked.SubcategoriaId;
        //    Tecnico = (int)ticked.TecnicoId;
        //    TipoAsistencia = (int)ticked.TipoAsistenciaId;
        //    Tratamiento = (int)ticked.TratamientoId;
        //    UsuarioSolicitante = (int)ticked.UsuarioSolicitanteId;



        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connString))
        //        {

        //            string query = @"INSERT into app1_ticked (
        //                            numero
        //                            ,descripcion
        //                            ,adjunto
        //                            ,fechacreado
        //                            ,estado_id
        //                            ,prioridad_id
        //                            ,subcategoria_id
        //                            ,tecnico_id
        //                            ,tipoAsistencia_id
        //                            ,tratamiento_id
        //                            ,usuarioSolicitante_id) VALUES ('" + Numero+ "','" + Descripcion+ "','" +Adjunto+ "','" + Fechacreado+ "'," + Estado+ ","+Prioridad+ ","+Subcategoria+ ","+Tecnico+ ","+TipoAsistencia+ ","+Tratamiento+ ","+UsuarioSolicitante+ ");" ;

        //            SqlCommand cmd = new SqlCommand(query, conn);

        //            conn.Open();

        //            SqlDataReader dr = cmd.ExecuteReader();

        //            Console.WriteLine(Environment.NewLine + "Iniciando insercion de datos..." + Environment.NewLine);
                    

        //            //close data reader
        //            dr.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Exception: " + ex.Message);
        //        return null;
        //    }

        //    return Ok();

        //}
        #endregion

        #region metodo post procedimiento almacenado en base de datos
        // POST api/<TickedController>
        [HttpPost]
        public ActionResult Post([FromBody] App1TickedPost ticked)
        {
            SqlConnection connString = new SqlConnection();

            connString.ConnectionString = @"Server =localhost; Database = ticked; Trusted_Connection = True;";

            connString.Open();

            string procedureName = "[postTicked]";
            
            //int Estado, Prioridad, Subcategoria, Tecnico, TipoAsistencia, Tratamiento, UsuarioSolicitante;
            //DateTime Fechacreado, FechaAtendido, FechaCerrado;
            //string Adjunto, Descripcion, Numero;

            string? Numero = ticked.Numero;
            string? Descripcion = ticked.Descripcion;
            string? Adjunto = ticked.Adjunto;
            DateTime Fechacreado = (DateTime)ticked.Fechacreado;
            int? Estado = (int)ticked.EstadoId;
            int? Prioridad = (int)ticked.PrioridadId;
            int? Subcategoria = (int)ticked.SubcategoriaId;
            int? Tecnico = (int)ticked.TecnicoId;
            int? TipoAsistencia = (int)ticked.TipoAsistenciaId;
            int? Tratamiento = (int)ticked.TratamientoId;
            int? UsuarioSolicitante = (int)ticked.UsuarioSolicitanteId;


            try
            {
                using (SqlCommand command = new SqlCommand(procedureName,
                connString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Numero", Numero));
                    command.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
                    command.Parameters.Add(new SqlParameter("@Adjunto", Adjunto));
                    command.Parameters.Add(new SqlParameter("@Fechacreado", Fechacreado));
                    command.Parameters.Add(new SqlParameter("@Estado", Estado));
                    command.Parameters.Add(new SqlParameter("@Prioridad", Prioridad));
                    command.Parameters.Add(new SqlParameter("@Subcategoria", Subcategoria));
                    command.Parameters.Add(new SqlParameter("@Tecnico", Tecnico));
                    command.Parameters.Add(new SqlParameter("@TipoAsistencia", TipoAsistencia));
                    command.Parameters.Add(new SqlParameter("@Tratamiento", Tratamiento));
                    command.Parameters.Add(new SqlParameter("@UsuarioSolicitante", UsuarioSolicitante));

                    using (SqlDataReader? reader = command.ExecuteReader())
                    connString.Close();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                connString.Close();
                return null;
            }

            return Ok();

        }
        #endregion
    }

}

