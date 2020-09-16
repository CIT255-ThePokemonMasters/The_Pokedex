using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using The_Pokedex.Models;

namespace The_Pokedex.DataAccessLayer
{
    public class DataServiceXml : IDataService
    {
        private string _dataFilePath;

        /// <summary>
        /// read the xml file and load a list of pokemon
        /// </summary>
        /// <returns>list of widgets</returns>
        public IEnumerable<Pokemon> ReadAll()
        {
            List<Pokemon> pokemon = new List<Pokemon>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Pokemon>));

            try
            {
                StreamReader reader = new StreamReader(_dataFilePath);
                using (reader)
                {
                    pokemon = (List<Pokemon>)serializer.Deserialize(reader);
                }

            }
            catch (Exception)
            {
                throw;
            }

            return pokemon;
        }

        /// <summary>
        /// write the current list of pokemon to the xml data file
        /// </summary>
        public void WriteAll(IEnumerable<Pokemon> pokemon)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Pokemon>), new XmlRootAttribute("Pokemon"));

            try
            {
                StreamWriter writer = new StreamWriter(_dataFilePath);
                using (writer)
                {
                    serializer.Serialize(writer, pokemon);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataServiceXml()
        {
            _dataFilePath = DataConfig.DataPathXml;
        }
    }
}
