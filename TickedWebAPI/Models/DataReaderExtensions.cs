using System.Data;

namespace TickedWebAPI.Models
{
    public static class DataReaderExtensions
    {
        public static string GetStringOrNull(this IDataReader reader, int ordinal)
        {
            return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
        }

        public static int GetIntOrNull(this IDataReader reader, int ordinal)
        {
            return reader.IsDBNull(ordinal) ? 0 : reader.GetInt32(ordinal);
        }

        public static DateTime GetDateOrNull(this IDataReader reader, int ordinal)
        {
            return reader.IsDBNull(ordinal) ? new DateTime(1900, 1, 1) : reader.GetDateTime(ordinal);
        }

        public static Boolean GetBoolOrNull(this IDataReader reader, int ordinal)
        {
            return reader.IsDBNull(ordinal) ? false : reader.GetBoolean(ordinal);
        }
    }
}
