namespace TickedWebAPI.Utils
{
    public class ConnectionConf
    {
        static IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);

        public static IConfigurationRoot configuration = builder.Build();

        public static string conn = configuration.GetConnectionString("ConnectionString");
    }
}
