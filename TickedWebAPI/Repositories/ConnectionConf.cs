using TickedWebAPI.Interfaces;

namespace TickedWebAPI.Repositories
{
    public class ConnectionConf
    {
        static IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);

        public static IConfigurationRoot configuration = builder.Build();

        public static string conn = configuration.GetConnectionString("ConnectionString");
        //public string GetConectionString()
        //{
        //    return conn;
        //}

    }
}
