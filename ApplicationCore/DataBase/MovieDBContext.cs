using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace ApplicationCore.DataBase
{
    public class MovieDBContext
    {
        public string GetConnectionString()
        {
            SqlConnection connection = new SqlConnection();
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            return builder.GetConnectionString("MovieProject");
        }
    }
}
