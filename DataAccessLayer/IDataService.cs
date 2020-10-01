using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Pokedex.Models;

namespace The_Pokedex.DataAccessLayer
{
    public interface IDataService
    {
        IEnumerable<Pokemon> ReadAll();

        IEnumerable<Pokemon> GetAll();

        void WriteAll(IEnumerable<Pokemon> pokemon);

        Pokemon GetByID(int id);

        void Add(Pokemon pokemon);

        void Update(Pokemon pokemon);

        void Delete(int id);
    }
}
