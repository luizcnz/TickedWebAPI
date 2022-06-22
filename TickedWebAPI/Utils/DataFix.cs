using System.Data;

namespace TickedWebAPI.Utils
{
    public static class DataFix
    {
        public static string? GetStringOrNull(this IDataReader reader, int ordinal)
        {
            return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
        }

        public static int GetIntOrNull(this IDataReader reader, int ordinal)
        {
            return reader.IsDBNull(ordinal) ? 0 : reader.GetInt32(ordinal);
        }

        public static bool GetBoolOrNull(this IDataReader reader, int ordinal)
        {
            return reader.IsDBNull(ordinal) ? false : reader.GetBoolean(ordinal);
        }
    }
}
