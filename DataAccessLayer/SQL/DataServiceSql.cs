using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Pokedex.Models;

namespace The_Pokedex.DataAccessLayer.SQL
{
    class DataServiceSql : IDataService
    {
        #region Fields

        private List<Pokemon> _pokemon;

        #endregion

        #region Constructors

        public DataServiceSql()
        {
            DataSet pokemon_ds = GetDataSet();
            _pokemon = GetPokemon(pokemon_ds);
        }

        #endregion

        #region Methods

        /// <summary>
        /// queries the data set and generates a list of pokemon
        /// </summary>
        private List<Pokemon> GetPokemon(DataSet pokemon_ds)
        {
            DataTable pokemon_dt = pokemon_ds.Tables["Pokemon"];

            List<Pokemon> pokemon = (from p in pokemon_dt.AsEnumerable()
                                     select new Pokemon()
                                     {
                                         ID = Convert.ToInt32(p["Id"]),
                                         Name = Convert.ToString(p["Name"]),
                                         PokemonType = ConvertToEnum(p["Type"]),
                                         Weakness = ConvertToEnum(p["Weakness"]),
                                         Abilities = Convert.ToString(p["Abilities"]),
                                         Height = Convert.ToDouble(p["Height"]),
                                         Weight = Convert.ToDouble(p["Weight"]),
                                         Description = Convert.ToString(p["Description"]),
                                         Category = Convert.ToString(p["Category"]),
                                         ImageFileName = Convert.ToString(p["ImageFileName"])
                                     }).ToList();

            return pokemon;
        }

        /// <summary>
        /// Converts Type/Weakness from object into a list<Type>
        /// </summary>
        private List<Pokemon.Type> ConvertToEnum(object type)
        {
            List<Pokemon.Type> pokemonTypes = new List<Pokemon.Type>();
            string phrase = Convert.ToString(type);
            string[] stringTypes = phrase.Split(',');
            Pokemon.Type typeParsed;

            foreach (string item in stringTypes)
            {
                Enum.TryParse(item, out typeParsed);
                pokemonTypes.Add(typeParsed);
            }

            return pokemonTypes;
        }

        /// <summary>
        /// connect to sql and return all the tables
        /// </summary>
        /// <returns></returns>
        private DataSet GetDataSet()
        {
            DataSet pokemon_DataSet = new DataSet();

            string connectionString = SqlDataSettings.ConnectionString;
            string sqlCommandString = "SELECT * from Pokemon";

            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlCommandString, sqlConn);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConn.Open();

                    sqlDataAdapter.Fill(pokemon_DataSet, "Pokemon");
                }
                catch (SqlException sqlException)
                {
                    var exceptionMessage = sqlException.Message;
                    throw;
                }
            }

            return pokemon_DataSet;
        }

        /// <summary>
        /// gets all of the pokemon
        /// </summary>
        public IEnumerable<Pokemon> GetAll() 
        {
            return _pokemon;
        }

        /// <summary>
        /// retirieves pokemon by ID
        /// </summary>
        public Pokemon GetByID(int id) 
        {
            return _pokemon.FirstOrDefault(p => p.ID == id);
        }

        /// <summary>
        /// add a Pokemon
        /// </summary>
        public void Add(Pokemon pokemon) 
        {
            string connectionString = SqlDataSettings.ConnectionString;

            var sb = new StringBuilder("INSERT INTO Pokemon");
            sb.Append(" ([Id]), ([Name], [Type], [Weakness], [Abilities], [Weight], [Height], [Description], [Category], [ImageFileName]");
            sb.Append(" Values (");
            sb.Append("'").Append(pokemon.ID).Append("',");
            sb.Append("'").Append(pokemon.Name).Append("',");
            sb.Append("'").Append(pokemon.PokemonType).Append("',");
            sb.Append("'").Append(pokemon.Weakness).Append("',");
            sb.Append("'").Append(pokemon.Abilities).Append("',");
            sb.Append("'").Append(pokemon.Weight).Append("',");
            sb.Append("'").Append(pokemon.Height).Append("',");
            sb.Append("'").Append(pokemon.Description).Append("',");
            sb.Append("'").Append(pokemon.Category).Append("',");
            sb.Append("'").Append(pokemon.ImageFileName).Append("')");

            string sqlCommandString = sb.ToString();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString)) 
            {
                try
                {
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                    sqlConnection.Open();
                    sqlAdapter.InsertCommand = new SqlCommand(sqlCommandString, sqlConnection);
                    sqlAdapter.InsertCommand.ExecuteNonQuery();
                }
                catch (Exception msg)
                {
                    var exceptionMessage = msg.Message;
                    throw;
                }
            }
        }

        /// <summary>
        /// delete a pokemon
        /// </summary>
        public void Delete(int id) 
        {
            string connectionString = SqlDataSettings.ConnectionString;

            var sb = new StringBuilder("DELETE FROM Pokemon");
            sb.Append(" WHERE Id = ").Append(id);
            string sqlCommandString = sb.ToString();

            using(SqlConnection sqlConnection = new SqlConnection(connectionString)) 
            {
                try
                {
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                    sqlConnection.Open();
                    sqlAdapter.DeleteCommand = new SqlCommand(sqlCommandString, sqlConnection);
                    sqlAdapter.DeleteCommand.ExecuteNonQuery();
                }
                catch (Exception msg)
                {
                    var exceptionMessage = msg.Message;
                    throw;
                }
            }
        }

        /// <summary>
        /// updates a pokemon
        /// </summary>
        public void Update(Pokemon pokemon) 
        {
            string connectionString = SqlDataSettings.ConnectionString;

            var sb = new StringBuilder("UPDATE Pokemon SET ");
            sb.Append("Id = '").Append(pokemon.ID).Append("' ");
            sb.Append("Name = '").Append(pokemon.Name).Append("' ");
            sb.Append("Type = '").Append(pokemon.PokemonType).Append("' ");
            sb.Append("Weakness = '").Append(pokemon.Weakness).Append("' ");
            sb.Append("Abilities = '").Append(pokemon.Abilities).Append("' ");
            sb.Append("Weight = '").Append(pokemon.Weight).Append("' ");
            sb.Append("Height = '").Append(pokemon.Height).Append("' ");
            sb.Append("Description = '").Append(pokemon.Description).Append("' ");
            sb.Append("Category = '").Append(pokemon.Category).Append("' ");
            sb.Append("ImageFileName = '").Append(pokemon.ImageFileName).Append("' ");
            sb.Append("WHERE Id = ").Append(pokemon.ID);

            string sqlCommandString = sb.ToString();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                    sqlConnection.Open();
                    sqlAdapter.DeleteCommand = new SqlCommand(sqlCommandString, sqlConnection);
                    sqlAdapter.DeleteCommand.ExecuteNonQuery();
                }
                catch (Exception msg)
                {
                    var exceptionMessage = msg.Message;
                    throw;
                }
            }
        }

        public IEnumerable<Pokemon> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void WriteAll(IEnumerable<Pokemon> pokemon)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
