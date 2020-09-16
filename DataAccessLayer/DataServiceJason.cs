using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Pokedex.Models;

namespace The_Pokedex.DataAccessLayer
{
    public class DataServiceJason : IDataService
    {
        private string _dataFilePath;

        /// <summary>
        /// read from json file
        /// </summary>
        public IEnumerable<Pokemon> ReadAll()
        {
            List<Pokemon> pokemon;

            try
            {
                using (StreamReader sr = new StreamReader(_dataFilePath))
                {
                    string jsonString = sr.ReadToEnd();

                    pokemon = JsonConvert.DeserializeObject<List<Pokemon>>(jsonString);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return pokemon;
        }

        /// <summary>
        /// write to json file
        /// </summary>
        public void WriteAll(IEnumerable<Pokemon> pokemon)
        {
            string jsonString = JsonConvert.SerializeObject(pokemon, Formatting.Indented);

            try
            {
                StreamWriter writer = new StreamWriter(_dataFilePath);
                using (writer)
                {
                    writer.WriteLine(jsonString);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataServiceJason() 
        {
            _dataFilePath = DataConfig.DataPathJson;
        }
    }
}
