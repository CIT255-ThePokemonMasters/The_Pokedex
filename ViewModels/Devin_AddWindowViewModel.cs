using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using The_Pokedex.Models;
using The_Pokedex.UtilityClass;

namespace The_Pokedex.ViewModels
{
    class Devin_AddWindowViewModel
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

        #endregion

        #region Properties

        public Pokemon UserPokemon { get; set; }

        #endregion

        #region Constructors

        public Devin_AddWindowViewModel(PokemonOperation pokemonOperation) 
        {
            UserPokemon = pokemonOperation.pokemon;
            _pokemonOperation = pokemonOperation;
        }

        #endregion

        #region Methods

        private void AddPokemon(object obj)
        {
            _pokemonOperation.Status = PokemonOperation.OperationStatus.OKAY;

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

        #endregion
    }
}
