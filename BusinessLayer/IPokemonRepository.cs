using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Pokedex.Models;

namespace The_Pokedex.BusinessLayer
{
    public interface IPokemonRepository
    {
        IEnumerable<Pokemon> GetAll();
        Pokemon GetById(int id);
        void Add(Pokemon pokemon);
        void Update(Pokemon pokemon);
        void Delete(int id);
    }
}
