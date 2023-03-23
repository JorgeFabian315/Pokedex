using Pokedex.ViewModels;
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

namespace Pokedex.Views.PokemonsViews
{
    /// <summary>
    /// Lógica de interacción para AgregarPokemonView.xaml
    /// </summary>
    public partial class AgregarPokemonView : UserControl
    {
        public AgregarPokemonView()
        {
            InitializeComponent();
        }

        private void fondonegro_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var d = this.DataContext as PokemonViewModel;
            if (d != null)
            {
                d.MostrarErroresCommad.Execute("");
            }
        }
    }
}
