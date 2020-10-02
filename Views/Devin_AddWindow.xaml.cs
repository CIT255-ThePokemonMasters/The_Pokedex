using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using The_Pokedex.Models;
using The_Pokedex.ViewModels;

namespace The_Pokedex.Views
{
    /// <summary>
    /// Interaction logic for Devin_AddWindow.xaml
    /// </summary>
    public partial class Devin_AddWindow : Window
    {
        public Devin_AddWindow(PokemonOperation pokemonOperation)
        {
            InitializeComponent();
            Devin_AddWindowViewModel devin_AddWindowViewModel = new Devin_AddWindowViewModel(pokemonOperation);
            DataContext = devin_AddWindowViewModel;
        }
    }
}
