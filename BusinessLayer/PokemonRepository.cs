using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Pokedex.DataAccessLayer;
using The_Pokedex.Models;

namespace The_Pokedex.BusinessLayer
{
    class PokemonRepository : IPokemonRepository, IDisposable
    {
        private IDataService _dataService;
        List<Pokemon> _pokemon;

        public PokemonRepository()
        {
            DataConfig dataConfig = new DataConfig();
            _dataService = dataConfig.SetDataService();

            try
            {
                _pokemon = _dataService.GetAll() as List<Pokemon>;
            }
            catch (Exception e)
            {
                string message = e.Message;
                throw;
            }
        }

        /// <summary>
        /// returns correct data type
        /// </summary>
        private IDataService SetDataService()
        {
            switch (DataConfig.dataType)
            {
                case DataType.JSON:
                    return new DataServiceJason();
                default:
                    throw new Exception();
            }
        }

        /// <summary>
        /// retrieves all Pokemon
        /// </summary>
        public IEnumerable<Pokemon> GetAll()
        {
            return _pokemon;
        }

        /// <summary>
        /// gets pokemon by ID
        /// </summary>
        public Pokemon GetById(int id)
        {
            return _pokemon.FirstOrDefault(c => c.ID == id);
        }

        /// <summary>
        /// Adds a new pokemon
        /// </summary>
        public void Add(Pokemon pokemon)
        {
            try
            {
                _dataService.Add(pokemon);
                //_pokemon.Add(pokemon);
                //_dataService.WriteAll(_pokemon);
            }
            catch (Exception e)
            {
                string message = e.Message;
                throw;
            }
        }

        /// <summary>
        /// deletes a pokemon by ID
        /// </summary>
        public void Delete(int id)
        {
            try
            {
                _dataService.Delete(id);
                //_pokemon.Remove(_pokemon.FirstOrDefault(p => p.ID == id));

                //_dataService.WriteAll(_pokemon);
            }
            catch (Exception e)
            {
                string message = e.Message;
                throw;
            }
        }

        /// <summary>
        /// updates a pokemon by id
        /// </summary>
        public void Update(Pokemon pokemon)
        {
            try
            {
                _dataService.Update(pokemon);

                //_pokemon.Remove(_pokemon.FirstOrDefault(p => p.ID == pokemon.ID));
                //_pokemon.Add(pokemon);
                //_dataService.WriteAll(_pokemon);
            }
            catch (Exception e)
            {
                string message = e.Message;
                throw;
            }
        }

        public void Dispose()
        {
            _dataService = null;
            _pokemon = null;
        }

    }
}
