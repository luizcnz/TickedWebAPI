using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TickedWebAPI.Models;
using System.Data;
using TickedWebAPI.Interfaces;


namespace TickedWebAPI.Repositories.Aplications
{
    public class InsertarNumeroTicked
    {
        public void InsertarNumero(int id)
        {
            SqlConnection connString = new SqlConnection();
            connString.ConnectionString = ConnectionConf.conn;
            connString.Open();
            string procedureName = "[postTkNumero]";
            try
            {
                using (SqlCommand command2 = new SqlCommand(procedureName, connString))
                {
                    command2.CommandType = CommandType.StoredProcedure;
                    command2.Parameters.Add(new SqlParameter("@id", id));
                    command2.ExecuteReader();
                }
                   
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                connString.Close();
                
            }
        }
    }
}