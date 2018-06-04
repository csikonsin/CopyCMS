using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyCMS.Data
{
    public class Connection
    {
        public static SqlConnection GetSql()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            return new System.Data.SqlClient.SqlConnection(connectionString);
        }
    }
}
