using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Pokedex.DataAccessLayer
{
    public class DataConfig
    {
        // set data type
        public static DataType dataType = DataType.JSON;

        public static string DataPathJson => @"DataAccessLayer\Json\pokemonList.json";
        public static string DataPathXml => @"DataAccessLayer\Xml\pokemonList.xml";
        public static string ImagePath => @"\DataAccessLayer\Images\";
    }
}
