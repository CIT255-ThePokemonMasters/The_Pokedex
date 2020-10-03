using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using The_Pokedex.BusinessLayer;
using The_Pokedex.Models;
using The_Pokedex.UtilityClass;

namespace The_Pokedex.ViewModels
{
    class Devin_AddWindowViewModel : ObservableObject
    {
        #region Commands

        public ICommand ButtonSaveCommand
        {
            get
            {
                return new RelayCommand(new Action<object>(AddPokemon));
            }
        }

        public ICommand ButtonCancelCommand
        {
            get
            {
                return new RelayCommand(new Action<object>(DeletePokemon));
            }
        }

        #endregion

        #region Fields

        private PokemonOperation _pokemonOperation;
        private PokemonBusiness _pokemonBusiness;

        //type bools for checkboxes
        private bool _fireIsChecked;
        private bool _waterIsChecked;
        private bool _grassIsChecked;

        //weakness bool for checkboxes
        private bool _weaknessToFireIsChecked;
        private bool _weaknessToWaterIsChecked;
        private bool _weaknessToGrassIsChecked;

        #endregion

        #region Properties

        public Pokemon UserPokemon { get; set; }

        #region Type bools

        public bool FireIsChecked
        {
            get { return _fireIsChecked; }
            set
            {
                _fireIsChecked = value;
                OnPropertyChanged(nameof(FireIsChecked));
            }
        }

        public bool WaterIsChecked
        {
            get { return _waterIsChecked; }
            set
            {
                _waterIsChecked = value;
                OnPropertyChanged(nameof(WaterIsChecked));
            }
        }

        public bool GrassIsChecked
        {
            get { return _grassIsChecked; }
            set
            {
                _grassIsChecked = value;
                OnPropertyChanged(nameof(GrassIsChecked));
            }
        }

        #endregion

        #region Weakness Bools

        public bool WeaknessToFireIsChecked
        {
            get { return _weaknessToFireIsChecked; }
            set
            {
                _weaknessToFireIsChecked = value;
                OnPropertyChanged(nameof(WeaknessToFireIsChecked));
            }
        }

        public bool WeaknessToWaterIsChecked
        {
            get { return _weaknessToWaterIsChecked; }
            set
            {
                _weaknessToWaterIsChecked = value;
                OnPropertyChanged(nameof(WeaknessToWaterIsChecked));
            }
        }

        public bool WeaknessToGrassIsChecked
        {
            get { return _weaknessToGrassIsChecked; }
            set
            {
                _weaknessToGrassIsChecked = value;
                OnPropertyChanged(nameof(WeaknessToGrassIsChecked));
            }
        }

        #endregion


        #endregion

        #region Constructors

        public Devin_AddWindowViewModel(PokemonOperation pokemonOperation)
        {
            UserPokemon = pokemonOperation.pokemon;
            _pokemonOperation = pokemonOperation;
            _pokemonBusiness = new PokemonBusiness();
        }

        #endregion

        #region Methods

        private void AddPokemon(object obj)
        {
            UserPokemon.PokemonType = ConvertTypeChecksIntoType();
            UserPokemon.Weakness = ConvertWeaknessChecksIntoType();
            _pokemonOperation.Status = PokemonOperation.OperationStatus.OKAY;
            _pokemonBusiness.AddPokemon(UserPokemon);

            if (obj is System.Windows.Window)
            {
                (obj as System.Windows.Window).Close();
            }
        }

        private void DeletePokemon(object obj)
        {
            _pokemonOperation.Status = PokemonOperation.OperationStatus.CANCEL;

            if (obj is System.Windows.Window)
            {
                (obj as System.Windows.Window).Close();
            }
        }

        private List<Pokemon.Type> ConvertTypeChecksIntoType()
        {
            List<Pokemon.Type> types = new List<Pokemon.Type>();

            if (FireIsChecked == true)
            {
                types.Add(Pokemon.Type.FIRE);
            }
            else if (WaterIsChecked == true)
            {
                types.Add(Pokemon.Type.WATER);
            }
            else if (GrassIsChecked == true)
            {
                types.Add(Pokemon.Type.GRASS);
            }
            else
            {
                types.Add(Pokemon.Type.NONE);
            }
            return types;
        }


        private List<Pokemon.Type> ConvertWeaknessChecksIntoType()
        {
            List<Pokemon.Type> weaknessTypes = new List<Pokemon.Type>();

            if (WeaknessToFireIsChecked == true)
            {
                weaknessTypes.Add(Pokemon.Type.FIRE);
            }
            else if (WeaknessToWaterIsChecked == true)
            {
                weaknessTypes.Add(Pokemon.Type.WATER);
            }
            else if (WeaknessToGrassIsChecked == true)
            {
                weaknessTypes.Add(Pokemon.Type.GRASS);
            }
            else
            {
                weaknessTypes.Add(Pokemon.Type.NONE);
            }
            return weaknessTypes;
        }
        #endregion
    }
}
