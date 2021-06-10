using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApplication1.DATA
{
    public class Conexion
    {
        public static string rutaConnexionSQL = ConfigurationManager.ConnectionStrings["WebApplication1.Properties.Settings.SqlServer"].ConnectionString;
        //public string rutaConnexion = "Data Source=(local);Initial Catalog=test;Persist Security Info=True;User ID=sa; password: sistema;MultipleActiveResultSets=True;";
    }
}