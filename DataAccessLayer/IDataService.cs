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

        void WriteAll(IEnumerable<Pokemon> pokemon);
    }
}
