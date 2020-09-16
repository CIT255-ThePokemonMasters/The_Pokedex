using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Pokedex.Models
{
    class PokemonOperation
    {
        public enum OperationStatus { OKAY, CANCEL }
        public OperationStatus Status { get; set; }
        public Pokemon pokemon { get; set; }
    }
}
