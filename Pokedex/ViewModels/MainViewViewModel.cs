using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pokedex.ViewModels
{
    public class MainViewViewModel:INotifyPropertyChanged
    {

        PokemonViewModel pokemonviewmodel = new();
        EntrenadorViewModel entrenadorviewmodel = new();

        private object viewmodelactual = null!;

        public object ViewModelActual
        {
            get { return viewmodelactual; }
            set { viewmodelactual = value;
                Actualizar();
            
            }
        }
        public ICommand PokemonViewModelCommand { get; set; } 
        public ICommand EntrenadorViewModelCommand { get; set; }


        public MainViewViewModel()
        {
            ViewModelActual = entrenadorviewmodel;

            PokemonViewModelCommand = new RelayCommand(NavegarVistaPokemon);

            EntrenadorViewModelCommand = new RelayCommand(NavegarVistaEntrenador);
        }

        private void NavegarVistaEntrenador()
        {
            ViewModelActual = entrenadorviewmodel;
            Actualizar();
        }

        private void NavegarVistaPokemon()
        {
            viewmodelactual = pokemonviewmodel;
            Actualizar();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Actualizar(string? prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
