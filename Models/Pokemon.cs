using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Pokedex.UtilityClass;

namespace The_Pokedex.Models
{
    public class Pokemon : ObservableObject
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

        #region Fields

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

        #region Properties

        public int ID
        {
            get { return _id; }
            set 
            { 
                _id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public double Weight 
        {
            get { return _weight; }
            set 
            { 
                _weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        public double Height
        {
            get { return _height; }
            set 
            { 
                _height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Description 
        {
            get { return _description; }
            set 
            { 
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string Abilities
        {
            get { return _abilities; }
            set 
            { 
                _abilities = value;
                OnPropertyChanged(nameof(Abilities));
            }
        }

        public string Category
        {
            get { return _category; }
            set 
            { 
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        public string ImageFileName 
        {
            get { return _imageFileName; }
            set 
            { 
                _imageFileName = value;
                OnPropertyChanged(nameof(ImageFileName));
            }
        }

        public string ImageFilePath 
        { 
            get { return _imageFilePath; }
            set 
            { 
                _imageFilePath = value;
                OnPropertyChanged(nameof(ImageFilePath));
            }
        }

        public List<Type> PokemonType
        {
            get { return _pokemonType; }
            set 
            { 
                _pokemonType = value;
                OnPropertyChanged(nameof(PokemonType));
            }
        }

        public List<Type> Weakness
        {
            get { return _weakness; }
            set 
            { 
                _weakness = value;
                OnPropertyChanged(nameof(Weakness));
            }
        }

        #endregion

        #region Constructors

        public Pokemon() 
        { 
        
        }

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
