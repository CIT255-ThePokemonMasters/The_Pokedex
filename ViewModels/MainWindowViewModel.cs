using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using The_Pokedex.BusinessLayer;
using The_Pokedex.UtilityClass;
using The_Pokedex.Views;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

            Christine_ViewModel christine_ViewModel = new Christine_ViewModel(pokemonBusiness);
            Christine_MainWindow christine_MainWindow = new Christine_MainWindow();

            Devin_ViewModel devin_ViewModel = new Devin_ViewModel(pokemonBusiness);
            Devin_MainWindow devin_MainWindow = new Devin_MainWindow();

            Bruce_ViewModel bruce_ViewModel = new Bruce_ViewModel(pokemonBusiness);
            Bruce_MainWindow bruce_MainWindow = new Bruce_MainWindow();

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
                    bruce_MainWindow.DataContext = bruce_ViewModel;
                    bruce_MainWindow.Show();
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
