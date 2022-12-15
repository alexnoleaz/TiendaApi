namespace TiendaApi.Connection
{
    public class ConnectionDB
    {
        private string connectionString = string.Empty;
        public ConnectionDB()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            connectionString = builder.GetSection("ConnectionStrings:ConnectionMaster").Value;
        }
        public string ConnectionString() => connectionString;
    }
}
