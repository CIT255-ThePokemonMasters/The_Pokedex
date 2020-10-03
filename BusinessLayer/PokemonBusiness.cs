using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Pokedex.DataAccessLayer;
using The_Pokedex.DataAccessLayer.SQL;
using The_Pokedex.Models;

namespace The_Pokedex.BusinessLayer
{
    public class PokemonBusiness
    {
        #region Properties

        public FileIoMessage fileIOStatus { get; set; }

        #endregion

        #region Constructor
        public PokemonBusiness()
        {
            //SqlUtilities.WriteSeedDataToDatabase();
        }

        #endregion

        #region Methods

        /// <summary>
        /// gets pokemon by ID
        /// </summary>
        private Pokemon GetPokemon(int id)
        {
            Pokemon pokemon = null;
            fileIOStatus = FileIoMessage.None;
            try
            {
                using (PokemonRepository pokemonRepository = new PokemonRepository())
                {
                    pokemon = pokemonRepository.GetById(id);
                }

                if (pokemon != null)
                {
                    fileIOStatus = FileIoMessage.Complete;
                }
                else
                {
                    fileIOStatus = FileIoMessage.NoRecordsFound;
                }
            }
            catch (Exception)
            {

                fileIOStatus = FileIoMessage.FileAccessError;
            }

            return pokemon;
        }

        /// <summary>
        /// gets all the pokemon
        /// </summary>
        private List<Pokemon> GetAllPokemon()
        {
            List<Pokemon> pokemon = null;
            fileIOStatus = FileIoMessage.None;

            try
            {
                using (PokemonRepository pokemonRepository = new PokemonRepository())
                {
                    pokemon = pokemonRepository.GetAll() as List<Pokemon>;
                }

                if (pokemon != null)
                {
                    fileIOStatus = FileIoMessage.Complete;
                }
                else
                {
                    fileIOStatus = FileIoMessage.NoRecordsFound;
                }
            }
            catch (Exception)
            {

                fileIOStatus = FileIoMessage.FileAccessError;
            }

            return pokemon;
        }

        /// <summary>
        /// retrieves pokemon from seed data or data path
        /// </summary>
        public List<Pokemon> AllPokemon()
        {
            //return GetAllPokemon() as List<Pokemon>;

            //return SeedData.GetAllPokemon();

            return GetAllPokemon();
        }

        /// <summary>
        /// retrieve a pokemon by id
        /// </summary>
        public Pokemon PokemonByID(int id)
        {
            return GetPokemon(id);
        }

        /// <summary>
        /// add a pokemon
        /// </summary>
        public void AddPokemon(Pokemon pokemon)
        {
            try
            {
                if (pokemon != null)
                {
                    using (PokemonRepository pokemonRepository = new PokemonRepository())
                    {
                        pokemonRepository.Add(pokemon);
                    }
                    fileIOStatus = FileIoMessage.Complete;
                }
            }
            catch (Exception)
            {

                fileIOStatus = FileIoMessage.FileAccessError;
            }
        }

        /// <summary>
        /// delete a pokemon by id 
        /// </summary>
        public void DeletePokemon(int id)
        {
            try
            {
                if (GetPokemon(id) != null)
                {
                    using (PokemonRepository pokemonRepository = new PokemonRepository())
                    {
                        pokemonRepository.Delete(id);
                    }

                    fileIOStatus = FileIoMessage.Complete;
                }
                else
                {
                    fileIOStatus = FileIoMessage.RecordNotFound;
                }
            }
            catch (Exception)
            {
                fileIOStatus = FileIoMessage.FileAccessError;
            }
        }

        /// <summary>
        /// updates pokemon by id
        /// </summary>
        public void UpdatePokemon(Pokemon pokemonToUpdate) 
        {
            try
            {
                if (GetPokemon(pokemonToUpdate.ID) != null)
                {
                    using (PokemonRepository pokemonRepository = new PokemonRepository())
                    {
                        pokemonRepository.Update(pokemonToUpdate);
                    }

                    fileIOStatus = FileIoMessage.Complete;
                }
                else
                {
                    fileIOStatus = FileIoMessage.RecordNotFound;
                }
            }
            catch (Exception)
            {
                fileIOStatus = FileIoMessage.FileAccessError;
            }
        }
        #endregion
    }
}
