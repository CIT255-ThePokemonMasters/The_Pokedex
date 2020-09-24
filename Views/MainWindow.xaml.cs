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
using System.Windows.Navigation;
using System.Windows.Shapes;
using The_Pokedex.BusinessLayer;
using The_Pokedex.ViewModels;
using The_Pokedex.Views;

namespace The_Pokedex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ViewSelection_Button_Click(object sender, RoutedEventArgs e)
        {
            //PokemonBusiness pokemonBusiness = new PokemonBusiness();

            //string selection = ViewSelection.SelectionBoxItem as string;

            //switch (selection)
            //{
            //    case "Bruce's View":
            //        break;
            //    case "Christine's View":
            //        Christine_ViewModel christine_ViewModel = new Christine_ViewModel(pokemonBusiness);

            //        Christine_MainWindow christine_MainWindow = new Christine_MainWindow();
            //        christine_MainWindow.DataContext = christine_ViewModel;
            //        christine_MainWindow.Show();
            //        this.Close();
            //        break;
            //    case "Devin's View":
            //        Devin_ViewModel devin_ViewModel = new Devin_ViewModel(pokemonBusiness);

            //        Devin_MainWindow devin_MainWindow = new Devin_MainWindow();
            //        devin_MainWindow.DataContext = devin_ViewModel;
            //        devin_MainWindow.Show();
            //        this.Close();
            //        break;
            //    default:
            //        break;
        }
    }
}
