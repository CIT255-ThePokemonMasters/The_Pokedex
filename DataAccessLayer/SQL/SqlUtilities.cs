﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace The_Pokedex.DataAccessLayer.SQL
{
    public class SqlUtilities
    {
        public static bool WriteSeedDataToDatabase() 
        {
            bool operationSuccessful = true;

            try
            {
                DeleteAllPokemonRecords();
                AddAllPokemonRecords();
            }
            catch (Exception msg)
            {
                operationSuccessful = false;
                var message = msg.Message;
                throw;
            }

            return operationSuccessful;
        }

        /// <summary>
        /// deletes all records
        /// </summary>
        private static bool DeleteAllPokemonRecords()
        {
            string connectionString = SqlDataSettings.ConnectionString;
            string sqlCommandString = "DELETE FROM Pokemon";
            bool operationSuccessful = true;

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
                    operationSuccessful = false;
                    throw;
                }
            }

            return operationSuccessful;
        }

        /// <summary>
        /// adds pokemon records from seed data
        /// </summary>
        private static bool AddAllPokemonRecords()
        {
            string connectionString = SqlDataSettings.ConnectionString;
            bool operationSuccessful = true;

            foreach (var pokemon in SeedData.GetAllPokemon())
            {
                var sb = new StringBuilder("INSERT INTO Pokemon");
                sb.Append(" ([Id], [Name], [Type], [Weakness], [Abilities], [Weight], [Height], [Description], [Category], [ImageFileName])");
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
                        sqlAdapter.DeleteCommand = new SqlCommand(sqlCommandString, sqlConnection);
                        sqlAdapter.DeleteCommand.ExecuteNonQuery();
                    }
                    catch (Exception msg)
                    {
                        var exceptionMessage = msg.Message;
                        operationSuccessful = false;
                        throw;
                    }
                }
            }

            return operationSuccessful;
        }
    }
}
