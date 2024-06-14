using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;

namespace BigTimeApi
{
    public class DataContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            return new SqliteConnection(Configuration.GetConnectionString("Default"));
        }

        public async Task Init()
        {
            using var connection = CreateConnection();
            await _initCustomer();

            async Task _initCustomer()
            {
                var sql = """
                CREATE TABLE IF NOT EXISTS Customer (
                    CustomerId INTEGER PRIMARY KEY AUTOINCREMENT,
                    FirstName TEXT,
                    LastName TEXT,
                    CompanyName TEXT,
                    Street TEXT,
                    City TEXT,
                    State TEXT,
                    Zip TEXT
                );
                INSERT INTO Customer 
                    (FirstName, LastName, CompanyName, Street, City, State, Zip)
                SELECT 
                    'Kevin', 'Dougherty', 'BigTime Software', '123 Cicadageddon St', 'Chicago', 'IL', '60101'
                WHERE
                    NOT EXISTS (SELECT 1 FROM Customer);
                """;
                await connection.ExecuteAsync(sql);
            }
        }
    }
}