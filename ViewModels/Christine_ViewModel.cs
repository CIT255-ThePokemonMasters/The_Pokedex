using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using The_Pokedex.BusinessLayer;
using The_Pokedex.DataAccessLayer;
using The_Pokedex.Models;
using The_Pokedex.UtilityClass;

namespace The_Pokedex.ViewModels
{
    class Christine_ViewModel : ObservableObject
    {
        #region Commands

        public ICommand ViewCharacterCommand { get; set; }

        #endregion

        #region Fields

        private ObservableCollection<Pokemon> _pokemon;
        private Pokemon _selectedPokemon;
        private Pokemon _detailedViewPokemon;
        private PokemonBusiness _pokemonBusiness;

        private bool _isEditingAdding = false;
        private bool _showAddButton;

        private string _sortType;
        private string _searchText;
        private string _minWeightText;
        private string _maxWeightText;

        #endregion

        #region Properties

        public ObservableCollection<Pokemon> Pokemons
        {
            get { return _pokemon; }
            set
            {
                _pokemon = value;
                OnPropertyChanged(nameof(Pokemons));
            }
        }

        public Pokemon SelectedPokemon
        {
            get { return _selectedPokemon; }
            set
            {
                _selectedPokemon = value;
                OnPropertyChanged(nameof(SelectedPokemon));
            }
        }

        public Pokemon DetailedPokemonView
        {
            get { return _detailedViewPokemon; }
            set
            {
                _detailedViewPokemon = value;
                OnPropertyChanged(nameof(DetailedPokemonView));
            }
        }

        #endregion

        #region Constructors

        public Christine_ViewModel(PokemonBusiness pokemonBusiness)
        {
            _pokemonBusiness = pokemonBusiness;
            _pokemon = new ObservableCollection<Pokemon>(_pokemonBusiness.AllPokemon());

            ViewCharacterCommand = new RelayCommand(new Action<object>(OnViewPokemon));

            UpdateImageFilePath();
        }

        #endregion

        #region Methods

        /// <summary>
        /// view a pokemon
        /// </summary>
        private void OnViewPokemon(object obj)
        {
            if (_selectedPokemon != null)
            {
                UpdateDetailedViewPokemonToSelected();
            }
        }

        /// <summary>
        /// updates the image file path
        /// </summary>
        private void UpdateImageFilePath()
        {
            foreach (var pokemon in _pokemon)
            {
                pokemon.ImageFilePath = DataConfig.ImagePath + pokemon.ImageFileName;
            }
        }

        private void UpdateDetailedViewPokemonToSelected()
        {
            _detailedViewPokemon = new Pokemon();
            _detailedViewPokemon.ID = _selectedPokemon.ID;
            _detailedViewPokemon.Name = _selectedPokemon.Name;
            _detailedViewPokemon.PokemonType = _selectedPokemon.PokemonType;
            _detailedViewPokemon.Abilities = _selectedPokemon.Abilities;
            _detailedViewPokemon.Weakness = _selectedPokemon.Weakness;
            _detailedViewPokemon.Description = _selectedPokemon.Description;
            _detailedViewPokemon.Category = _selectedPokemon.Category;
            _detailedViewPokemon.Height = _selectedPokemon.Height;
            _detailedViewPokemon.Weight = _selectedPokemon.Weight;
            _detailedViewPokemon.ImageFileName = _selectedPokemon.ImageFileName;
            _detailedViewPokemon.ImageFilePath = _selectedPokemon.ImageFilePath;

            OnPropertyChanged(nameof(DetailedPokemonView));
        }

        #endregion
    }
}

