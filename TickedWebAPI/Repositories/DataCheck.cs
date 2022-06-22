﻿using Microsoft.Data.SqlClient;
using System.Data;

namespace TickedWebAPI.Repositories
{
    public static class DataCheck
    {
        public static bool VerificarExistencia(string procedure, int? id)
        {
            bool existe = false;

            SqlConnection connString = new SqlConnection();
            connString.ConnectionString = ConnectionConf.conn;
            connString.Open();

            string procedureName = procedure;

            try
            {
                using (SqlCommand command = new SqlCommand(procedureName, connString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    using (SqlDataReader? reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            existe = true;
                        }
                        else
                        {
                            existe = false;
                        }
                    }
                }
                return existe;
            }
            catch (Exception ex)
            {
                connString.Close();
                Console.Write("Se han encontrado los siguientes errores mientras se los datos: " + ex + "");
                return existe;
            }
        }
    }
}