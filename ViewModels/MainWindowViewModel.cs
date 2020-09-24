using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using The_Pokedex.BusinessLayer;
using The_Pokedex.UtilityClass;
using The_Pokedex.Views;

namespace The_Pokedex.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        public MainWindowViewModel(PokemonBusiness pokemonBusiness) 
        { 
            
        }

        public ICommand ViewSelectionCommand
        {
            get { return new RelayCommand(new Action<object>(ViewSelection)); }
        }

        private void ViewSelection(object obj) 
        {
            PokemonBusiness pokemonBusiness = new PokemonBusiness();

            Devin_ViewModel devin_ViewModel = new Devin_ViewModel(pokemonBusiness);
            Devin_MainWindow devin_MainWindow = new Devin_MainWindow();

            Christine_ViewModel christine_ViewModel = new Christine_ViewModel(pokemonBusiness);
            Christine_MainWindow christine_MainWindow = new Christine_MainWindow();

            string viewString = obj.ToString();

            switch (viewString)
            {
                case "DevinsView":
                    devin_MainWindow.DataContext = devin_ViewModel;
                    devin_MainWindow.Show();
                    break;
                case "ChristinesView":
                    christine_MainWindow.DataContext = christine_ViewModel;
                    christine_MainWindow.Show();
                    break;
                case "BrucesView":
                    break;
                case "Exit":
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
    }
}
