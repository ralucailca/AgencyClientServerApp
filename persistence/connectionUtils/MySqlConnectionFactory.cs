using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistence.connectionUtils
{
    public class MySqlConnectionFactory : ConnectionFactory
    {
        public override IDbConnection createConnection()
        {
            //MySql Connection
            String connectionString = "Database=AgentieTurism;" +
                                        "Data Source=localhost;" +
                                        "User id=root;" +
                                        "Password=rootpass@123;";
            return new MySqlConnection(connectionString);


        }
    }
}
