﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using The_Pokedex.BusinessLayer;
using The_Pokedex.DataAccessLayer;
using The_Pokedex.Models;
using The_Pokedex.UtilityClass;
using The_Pokedex.Views;

namespace The_Pokedex.ViewModels
{
    public class Devin_ViewModel : ObservableObject
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

        public ICommand ExitCommand
        {
            get { return new RelayCommand(new Action<object>(Exit)); }
        }

        public ICommand DeleteCommand
        {
            get { return new RelayCommand(new Action<object>(DeletePokemon)); }
        }

        public ICommand ButtonAddCommand
        {
            get { return new RelayCommand(new Action<object>(AddPokemon)); }
        }

        public ICommand ButtonEditCommand
        {
            get { return new RelayCommand(new Action<object>(EditPokemon)); }
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
        private string _errorMessage;
        private string _operationFeedback;

        private ObservableCollection<string> _typesForFilter;
        private string _type;

        private string _imageSource;
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

        public string ErrorMessage
        {
            get { return _errorMessage; }

            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public string Operationfeedback
        {
            get { return _operationFeedback; }
            set
            {
                _operationFeedback = value;
                OnPropertyChanged(nameof(Operationfeedback));
            }
        }

        public ObservableCollection<string> TypeForFilter
        {
            get { return _typesForFilter; }
            set
            {
                _typesForFilter = value;
                OnPropertyChanged(nameof(TypeForFilter));
            }
        }
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        public string ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }
        #endregion

        #region Constructors

        public Devin_ViewModel(PokemonBusiness pokemonBusiness)
        {
            _pokemonBusiness = pokemonBusiness;
            _pokemon = new ObservableCollection<Pokemon>(_pokemonBusiness.AllPokemon());
            _typesForFilter = new ObservableCollection<string>(Enum.GetNames(typeof(Pokemon.Type)));
            ViewCharacterCommand = new RelayCommand(new Action<object>(OnViewPokemon));

            Devin_MainWindow devin_MainWindow = new Devin_MainWindow();



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
            //string useablePath = @"C:\Users\Khyr\source\repos\The_Pokedex\";
            string useablePath = @"C:\NMC Classes\CIT255\The_Pokedex\";
            //string useablePath = @"C:\Users\pipbo\Documents\CIT255\Pokedex\";
            //ImageSource = new BitmapImage(new Uri(useablePath)).ToString();
            foreach (var pokemon in _pokemon)
            {
                try
                {
                    if (pokemon.ImageFileName != null)
                    {
                        //pokemon.ImageFilePath = DataConfig.ImagePath + pokemon.ImageFileName;
                        pokemon.ImageFilePath = new BitmapImage(new Uri(useablePath + DataConfig.ImagePath + pokemon.ImageFileName)).ToString();
                    }
                    else
                    {
                        pokemon.ImageFilePath = new BitmapImage(new Uri(useablePath + DataConfig.ImagePath + "defaultImage.png")).ToString();
                    }
                }
                catch (Exception e)
                {
                    var m = e.Message;
                    throw;
                }
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

            try
            {
                if (SelectedPokemon != null && SelectedPokemon.PokemonType != null)
                {
                    if (SelectedPokemon.PokemonType.Count > 1 && SelectedPokemon.PokemonType != null)
                    {
                        foreach (Pokemon.Type type in SelectedPokemon.PokemonType)
                        {
                            TypeToString += type.ToString() + "/ ";
                        }
                    }
                    else if (SelectedPokemon.PokemonType.Count == 1 && SelectedPokemon.PokemonType != null)
                    {
                        foreach (Pokemon.Type type in SelectedPokemon.PokemonType)
                        {
                            TypeToString += type.ToString();
                        }
                    }
                    else
                    {
                        SelectedPokemon.PokemonType.Add(Pokemon.Type.NONE);
                        TypeToString = SelectedPokemon.PokemonType.ToString();
                    }
                }
            }
            catch (Exception msg)
            {
                var message = msg.Message;
                throw;
            }
        }

        /// <summary>
        /// convert weakness to string
        /// </summary>
        private void ConvertWeaknessToString()
        {
            WeaknessToString = "";

            try
            {
                if (SelectedPokemon != null && SelectedPokemon.PokemonType != null)
                {
                    if (SelectedPokemon.Weakness.Count > 1 && SelectedPokemon.Weakness != null)
                    {
                        foreach (Pokemon.Type weakness in SelectedPokemon.Weakness)
                        {
                            WeaknessToString += weakness.ToString() + "/ ";
                        }
                    }
                    else if (SelectedPokemon.Weakness.Count == 1 && SelectedPokemon.Weakness != null)
                    {
                        foreach (Pokemon.Type type in SelectedPokemon.Weakness)
                        {
                            WeaknessToString += type.ToString();
                        }
                    }
                    else
                    {
                        SelectedPokemon.Weakness.Add(Pokemon.Type.NONE);
                        WeaknessToString = "NONE";
                    }
                }
            }
            catch (Exception msg)
            {
                var message = msg.Message;
                throw;
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

            if (!String.IsNullOrEmpty(SearchText))
            {
                Pokemons = new ObservableCollection<Pokemon>(_pokemon.Where(p => p.Name.ToLower().Contains(_searchText.ToLower())));
            }
            else
            {
                ErrorMessage = "*Sorry, that Pokemon was not found";
            }
            if (Pokemons.Count == 0)
            {
                ErrorMessage = $"*Could not locate {SearchText} in your Pokedex";
            }
        }

        /// <summary>
        /// Reset Pokemon list
        /// </summary>
        private void OnResetPokemonList(object obj)
        {
            SearchText = "";
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
            if (Type != null)
            {
                Enum.TryParse(Type, out Pokemon.Type typeToEnum);
                _pokemon = new ObservableCollection<Pokemon>(_pokemonBusiness.AllPokemon());
                UpdateImageFilePath();
                Pokemons = new ObservableCollection<Pokemon>(_pokemon.Where(p => p.PokemonType.Contains(typeToEnum)));
            }
            if (Pokemons.Count == 0)
            {
                ErrorMessage = $"*Sorry, you do not have any {Type} type Pokemon in your Pokedex";
            }
        }

        /// <summary>
        /// Deletes a pokemon
        /// </summary>
        public void DeletePokemon(object obj)
        {
            if (SelectedPokemon != null)
            {
                MediaPlayer mediaPlayer = new MediaPlayer();
                mediaPlayer.Open(new Uri(@"C:\NMC Classes\CIT255\The_Pokedex\Media\warning.wav"));
                mediaPlayer.Play();

                MessageBoxResult results = MessageBox.Show($"Are you sure you want to remove {SelectedPokemon.Name} from your Pokedex?", "Delete Pokemon", MessageBoxButton.YesNo);

                switch (results)
                {
                    case MessageBoxResult.Yes:
                        _pokemonBusiness.DeletePokemon(SelectedPokemon.ID);

                        Pokemons.Remove(SelectedPokemon);
                        Operationfeedback = $"{SelectedPokemon.Name} has been removed.";

                        if (Pokemons.Any()) SelectedPokemon = Pokemons[0];
                        break;
                    case MessageBoxResult.No:
                        Operationfeedback = "Deletion canceled.";
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// add a pokemon
        /// </summary>
        public void AddPokemon(object obj)
        {
            PokemonOperation pokemonOperation = new PokemonOperation()
            {
                Status = PokemonOperation.OperationStatus.CANCEL,
                pokemon = new Pokemon()
            };

            Window devin_addWindow = new Devin_AddWindow(pokemonOperation);
            devin_addWindow.ShowDialog();

            if (pokemonOperation.Status != PokemonOperation.OperationStatus.CANCEL)
            {
                _pokemonBusiness.AddPokemon(pokemonOperation.pokemon);
                Pokemons.Add(pokemonOperation.pokemon);
                UpdateImageFilePath();
            }
        }

        public void EditPokemon(object obj)
        {
            PokemonOperation pokemonOperation = new PokemonOperation()
            {
                Status = PokemonOperation.OperationStatus.CANCEL,
                pokemon = SelectedPokemon
            };

            if (SelectedPokemon != null)
            {
                Window devin_editWindow = new Devin_EditWindow(pokemonOperation);
                devin_editWindow.ShowDialog();
            }

            if (pokemonOperation.Status != PokemonOperation.OperationStatus.CANCEL)
            {
                Pokemons.Remove(SelectedPokemon);
                _pokemonBusiness.AddPokemon(pokemonOperation.pokemon);
                Pokemons.Add(pokemonOperation.pokemon);
                SelectedPokemon = pokemonOperation.pokemon;
                UpdateImageFilePath();
            }
        }

        /// <summary>
        /// method for menu bar
        /// </summary>
        private void Exit(object obj)
        {
            if (obj is System.Windows.Window)
            {
                (obj as System.Windows.Window).Close();
            }
        }
        #endregion
    }
}
