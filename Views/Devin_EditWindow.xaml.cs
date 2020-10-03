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
    /// Interaction logic for Devin_EditWindow.xaml
    /// </summary>
    public partial class Devin_EditWindow : Window
    {
        public Devin_EditWindow(PokemonOperation pokemonOperation)
        {
            InitializeComponent();
            Devin_EditWindowViewModel devin_EditWindowViewModel = new Devin_EditWindowViewModel(pokemonOperation);
            DataContext = devin_EditWindowViewModel;
        }
    }
}
