using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Pokedex.Models;

namespace The_Pokedex.DataAccessLayer
{
    public class SeedData
    {
        public static List<Pokemon> GetAllPokemon() 
        {
            return new List<Pokemon>
            {
                new Pokemon
                {
                    ID = 001,
                    Name = "Bulbasaur",
                    PokemonType = new List<Pokemon.Type>(){Pokemon.Type.Grass, Pokemon.Type.Poison},            
                    Weakness = new List<Pokemon.Type>(){Pokemon.Type.Fire, Pokemon.Type.Psychic, Pokemon.Type.Ice, Pokemon.Type.Flying},
                    Abilities = "Ram, Razor Leaf",
                    Weight = 15.2,
                    Height = 2.4,
                    Description = "There is a plant seed on its back right from the day this Pokémon is born.",
                    Category = "Seed",
                    ImageFileName = "bulbasaur.png"
                },

                new Pokemon
                {
                    ID = 004,
                    Name = "Charmander",
                    PokemonType = new List<Pokemon.Type>(){Pokemon.Type.Fire},
                    Weakness = new List<Pokemon.Type>(){Pokemon.Type.Water, Pokemon.Type.Ground, Pokemon.Type.Rock},
                    Abilities = "Blaze",
                    Weight = 18.7,
                    Height = 2.0,
                    Description = "It has a preference for hot things. When it rains, steam is said to spout from the tip of its tail.",
                    Category = "Lizard",
                    ImageFileName = "charmander.png"
                },

                 new Pokemon
                {
                    ID = 007,
                    Name = "Squirtle",
                    PokemonType = new List<Pokemon.Type>(){Pokemon.Type.Water},
                    Weakness = new List<Pokemon.Type>(){Pokemon.Type.Electric, Pokemon.Type.Grass},
                    Abilities = "Torrent",
                    Weight = 19.8,
                    Height = 1.8,
                    Description = "When it retracts its long neck into its shell, it squirts out water with vigorous force.",
                    Category = "Tiny Turtle",
                    ImageFileName = "squirtle.png"
                },

                  new Pokemon
                {
                    ID = 150,
                    Name = "Mewtwo",
                    PokemonType = new List<Pokemon.Type>(){Pokemon.Type.Psychic},
                    Weakness = new List<Pokemon.Type>(){Pokemon.Type.Ghost, Pokemon.Type.Dark, Pokemon.Type.Bug},
                    Abilities = "Pressure",
                    Weight = 269.0,
                    Height = 6.7,
                    Description = "Its DNA is almost the same as Mew’s. However, its size and disposition are vastly different.",
                    Category = "Genetic",
                    ImageFileName = "mewtwo.png"
                },

                    new Pokemon
                {
                    ID = 151,
                    Name = "Mew",
                    PokemonType = new List<Pokemon.Type>(){Pokemon.Type.Psychic},
                    Weakness = new List<Pokemon.Type>(){Pokemon.Type.Ghost, Pokemon.Type.Dark, Pokemon.Type.Bug},
                    Abilities = "Synchronize",
                    Weight = 8.8,
                    Height = 1.4,
                    Description = "When viewed through a microscope, this Pokémon’s short, fine, delicate hair can be seen.",
                    Category = "New Species",
                    ImageFileName = "mew.png"
                }
            };
        }
    }
}
