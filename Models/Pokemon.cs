using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Pokedex.Models
{
    public class Pokemon
    {
        #region Enums

        public enum Type
        {
            Normal,
            Fighting,
            Fire,
            Water,
            Grass,
            Electric,
            Flying,
            Poison,
            Ground,
            Rock,
            Psychic,
            Ice,
            Dragon,
            Ghost,
            Dark,
            Steel,
            Fairy,
            Bug
        }

        #endregion

        #region Properties

        private int _id;
        private double _weight;
        private double _height;
        private string _name;
        private string _description;
        private string _abilities;
        private string _category;
        private string _imageFileName;
        private string _imageFilePath;
        private List<Type> _pokemonType;
        private List<Type> _weakness;

        #endregion

        #region Fields

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public double Weight 
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description 
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Abilities
        {
            get { return _abilities; }
            set { _abilities = value; }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public string ImageFileName 
        {
            get { return _imageFileName; }
            set { _imageFileName = value; }
        }

        public string ImageFilePath 
        { 
            get { return _imageFilePath; }
            set { _imageFilePath = value; }
        }

        public List<Type> PokemonType
        {
            get { return _pokemonType; }
            set { _pokemonType = value; }
        }

        public List<Type> Weakness
        {
            get { return _weakness; }
            set { _weakness = value; }
        }

        #endregion

        #region Constructors



        #endregion

        #region Methods

        public Pokemon Copy() 
        {
            return new Pokemon
            {
                ID = _id,
                Name = _name,
                PokemonType = _pokemonType,
                Weakness = _weakness,
                Abilities = _abilities,
                Weight = _weight,
                Height = _height,
                Description = _description,
                Category = _category,
                ImageFileName = _imageFileName
            };
        }

        #endregion

    }
}
