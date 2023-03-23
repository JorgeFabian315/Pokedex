using Pokedex.Catalogos;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.ViewModels
{
    public class AccionesEntrenadorViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<Accionesentrenadores> ListaAccionesEntrenador { get; set; } = new();

        AccionesEntrenadorCatalogo cacciones = new();


        public AccionesEntrenadorViewModel()
        {
            GetAccionesEntrenador();
            Actualizar();
        }
        public void GetAccionesEntrenador()
        {
            ListaAccionesEntrenador.Clear();
            foreach (var item in cacciones.GetAccionesEntrenador())
            {
                ListaAccionesEntrenador.Add(item);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void Actualizar(string? prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
