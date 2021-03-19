using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Doctolib.Data
{
    class DataBase
    {
        private static string chaine = @"Data Source=(LocalDB)\BaseM2iSQL;Integrated Security=True";
        public static SqlConnection Connection = new SqlConnection(chaine);
    }
}
