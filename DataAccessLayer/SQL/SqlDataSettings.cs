using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Pokedex.DataAccessLayer.SQL
{
    public static class SqlDataSettings
    {
        public static string ConnectionString = @"Data Source=DESKTOP-8GI2QG3;Initial Catalog=Pokemon;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //public static string ConnectionString = @"Data Source=(localDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\khyr\source\repos\The_Pokedex\DATAACCESSLAYER\SQL\POKEMON.MDF""; Integrated Security=True";

    }
}
