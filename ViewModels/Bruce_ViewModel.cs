﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using The_Pokedex.BusinessLayer;
using The_Pokedex.DataAccessLayer;
using The_Pokedex.Models;
using The_Pokedex.UtilityClass;
using The_Pokedex.Views;

namespace The_Pokedex.ViewModels
{
    public class Bruce_ViewModel : ObservableObject
    {
        #region Commands

        /// <summary>
        /// view character comman
        /// </summary>
        public ICommand ViewCharacterCommand { get; set; }

        public ICommand SortPokemonCommand
        {
            get { return new RelayCommand(new Action<object>(OnSortPokemon)); }
        }

        public ICommand SearchByNameCommand
        {
            get { return new RelayCommand(new Action<object>(OnSearchByName)); }
        }

        public ICommand ResetPokemonListCommand
        {
            get { return new RelayCommand(new Action<object>(OnResetPokemonList)); }
        }

        public ICommand FilterPokemonCommand
        {
            get { return new RelayCommand(new Action<object>(OnFilterPokemon)); }
        }

        public ICommand ViewSelectionCommand
        {
            get { return new RelayCommand(new Action<object>(ViewSelection)); }
        }

        #endregion

        #region Fields

        private ObservableCollection<Pokemon> _pokemon;
        private Pokemon _selectedPokemon;
        private Pokemon _detailedViewPokemon;
        private PokemonBusiness _pokemonBusiness;

        private string _typeToString;
        private string _weaknessToString;
        private string _searchText;
        private string _filterText;
        private string _errorMessage;

        private ComboBox _filterComboBox;
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
                ConvertTypeToString();
                ConvertWeaknessToString();
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

        public string TypeToString
        {
            get { return _typeToString; }
            set
            {
                _typeToString = value;
                OnPropertyChanged(nameof(TypeToString));
            }
        }

        public string WeaknessToString
        {
            get { return _weaknessToString; }
            set
            {
                _weaknessToString = value;
                OnPropertyChanged(nameof(WeaknessToString));
            }
        }

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }

        public string FilterText
        {
            get { return _filterText; }
            set
            {
                _filterText = value;
                OnPropertyChanged(nameof(FilterText));
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }

            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public ComboBox FilterComboBox
        {
            get { return _filterComboBox; }
            set
            {
                _filterComboBox = value;
                OnPropertyChanged(nameof(FilterComboBox));
            }
        }
        #endregion

        #region Constructors

        public Bruce_ViewModel(PokemonBusiness pokemonBusiness)
        {
            _pokemonBusiness = pokemonBusiness;
            _pokemon = new ObservableCollection<Pokemon>(_pokemonBusiness.AllPokemon());

            ViewCharacterCommand = new RelayCommand(new Action<object>(OnViewPokemon));

            SearchText = "";
            FilterText = "";

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

        /// <summary>
        /// convert type to string
        /// </summary>
        private void ConvertTypeToString()
        {
            TypeToString = "";

            if (SelectedPokemon != null)
            {
                if (SelectedPokemon.PokemonType.Count > 1)
                {
                    foreach (Pokemon.Type type in SelectedPokemon.PokemonType)
                    {
                        TypeToString += type.ToString() + "/ ";
                    }
                }
                else
                {
                    foreach (Pokemon.Type type in SelectedPokemon.PokemonType)
                    {
                        TypeToString += type.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// convert weakness to string
        /// </summary>
        private void ConvertWeaknessToString()
        {
            WeaknessToString = "";

            if (SelectedPokemon != null)
            {
                if (SelectedPokemon.Weakness.Count > 1)
                {
                    foreach (Pokemon.Type weakness in SelectedPokemon.Weakness)
                    {
                        WeaknessToString += weakness.ToString() + "/ ";
                    }
                }
                else
                {
                    foreach (Pokemon.Type type in SelectedPokemon.PokemonType)
                    {
                        TypeToString += type.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// sorts pokemon based on name or number
        /// </summary>
        private void OnSortPokemon(object obj)
        {
            string sortType = obj.ToString();

            switch (sortType)
            {
                case "Name":
                    Pokemons = new ObservableCollection<Pokemon>(Pokemons.OrderBy(p => p.Name));
                    break;
                case "Number":
                    Pokemons = new ObservableCollection<Pokemon>(Pokemons.OrderBy(p => p.ID));
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// search by name
        /// </summary>
        private void OnSearchByName(object obj)
        {
            _pokemon = new ObservableCollection<Pokemon>(_pokemonBusiness.AllPokemon());
            UpdateImageFilePath();

            Pokemons = new ObservableCollection<Pokemon>(_pokemon.Where(p => p.Name.ToLower().Contains(_searchText.ToLower())));

            if (Pokemons.Count == 0 && SearchText != " ")
            {
                ErrorMessage = "*Sorry, that Pokemon was not found";
            }
            else if (SearchText == " ")
            {
                ErrorMessage = " ";
            }
        }

        /// <summary>
        /// Reset Pokemon list
        /// </summary>
        private void OnResetPokemonList(object obj)
        {
            SearchText = "";
            FilterText = "";
            ErrorMessage = "";

            _pokemon = new ObservableCollection<Pokemon>(_pokemonBusiness.AllPokemon());
            UpdateImageFilePath();

            Pokemons = _pokemon;
        }

        /// <summary>
        /// Filter Pokemon list
        /// </summary>
        private void OnFilterPokemon(object obj)
        {
            if (Enum.TryParse<Pokemon.Type>(FilterText.ToUpper(), out Pokemon.Type type))
            {
                _pokemon = new ObservableCollection<Pokemon>(_pokemonBusiness.AllPokemon());
                UpdateImageFilePath();
                Pokemons = new ObservableCollection<Pokemon>(_pokemon.Where(p => p.PokemonType.Contains(type)));
            }
            else
            {
                ErrorMessage = $"*Sorry, you do not have any {FilterText.ToUpper()} type Pokemon in your Pokedex";
            }
        }

        /// <summary>
        /// method for menu bar
        /// </summary>
        private void ViewSelection(object obj)
        {
            string viewString = obj.ToString();
            switch (viewString)
            {
                case "Exit":
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}