using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using The_Pokedex.DataAccessLayer.SQL;

namespace The_Pokedex.DataAccessLayer
{
    public class DataConfig
    {
        // set data type
        //public static DataType dataType = DataType.JSON;
        public static DataType dataType = DataType.SQL;

        public static string DataPathJson => @"DataAccessLayer\Json\pokemonList.json";
        public static string DataPathXml => @"DataAccessLayer\Xml\pokemonList.xml";
        public static string ImagePath => @"\Images\";
        //public static string ImagePath => @"";

        public IDataService SetDataService() 
        {
            switch (dataType)
            {
                case DataType.XML:
                    return new DataServiceXml();
                case DataType.JSON:
                    return new DataServiceJason();
                case DataType.SQL:
                    return new DataServiceSql();
                default:
                    throw new Exception();
            }
        }
    }
}
