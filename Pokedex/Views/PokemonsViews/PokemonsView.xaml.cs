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
    /// Lógica de interacción para PokemonsView.xaml
    /// </summary>
    public partial class PokemonsView : UserControl
    {
        public PokemonsView()
        {
            InitializeComponent();
        }

        private void cmbEntrenador_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbEntrenador.SelectedItem != null)
            {
                var f = this.DataContext as PokemonViewModel;
                if (f != null)
                    f.GetPokemonsCommand.Execute(cmbEntrenador.SelectedValue);
            }
        }
    }
}
