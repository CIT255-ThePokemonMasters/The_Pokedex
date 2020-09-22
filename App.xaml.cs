using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using The_Pokedex.BusinessLayer;
using The_Pokedex.ViewModels;
using The_Pokedex.Views;

namespace The_Pokedex
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e) 
        {
            PokemonBusiness pokemonBusiness = new PokemonBusiness();

            //Devin_ViewModel devin_ViewModel = new Devin_ViewModel(pokemonBusiness);

            //Devin_MainWindow devin_MainWindow = new Devin_MainWindow();
            //devin_MainWindow.DataContext = devin_ViewModel;
            //devin_MainWindow.Show();            

            Christine_ViewModel christine_ViewModel = new Christine_ViewModel(pokemonBusiness);

            Christine_MainWindow christine_MainWindow = new Christine_MainWindow();
            christine_MainWindow.DataContext = christine_ViewModel;
            christine_MainWindow.Show();
        }
    }
}
