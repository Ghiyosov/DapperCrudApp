using Npgsql;

namespace Infrastructure.DataContext;

public class DapperContext
{
    private readonly string  connectionString="Host=localhost;Port=5432;Database=marketdb;User Id=postgres;Password=832111;";

    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(connectionString);
    }
}