using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocioFormador.Persistence.Context;

public class SocioFormadorDapperDbContext
{
    
    private readonly string connectionString;
    
    public SocioFormadorDapperDbContext(string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException($"{nameof(connectionString)} can't be null.");
        }

        this.connectionString = connectionString;
    }
    
    public IDbConnection CreateConnection()
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new Exception($"{nameof(connectionString)} can't be null or empty.");
        }

        return new MySqlConnection(connectionString);
    }
}
