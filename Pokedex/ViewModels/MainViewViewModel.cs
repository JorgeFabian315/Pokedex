using GalaSoft.MvvmLight.Command;
using Pokedex.Models;
using Pokedex.Views;
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
        AccionesEntrenadorViewModel accionesentrenadorviewmodel = new();


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
        public ICommand AccionesEntrenadorViewModelCommand { get; set; }


        public MainViewViewModel()
        {
            ViewModelActual = entrenadorviewmodel;

            PokemonViewModelCommand = new RelayCommand(NavegarVistaPokemon);

            EntrenadorViewModelCommand = new RelayCommand(NavegarVistaEntrenador);
            AccionesEntrenadorViewModelCommand = new RelayCommand(NavegarVistaAccionesEntrenador);
        }

        private void NavegarVistaAccionesEntrenador()
        {
            accionesentrenadorviewmodel.GetAccionesEntrenador();
            ViewModelActual = accionesentrenadorviewmodel;
            Actualizar();
        }

        private void NavegarVistaEntrenador()
        {
            entrenadorviewmodel.Vista = Vista.VerEntrenadores;
            entrenadorviewmodel.GetEntrenadores();
            ViewModelActual = entrenadorviewmodel;
            Actualizar();
        }

        private void NavegarVistaPokemon()
        {
            pokemonviewmodel.GetEntrenadores();
            pokemonviewmodel.Vista = Vista.VerPokemons;
            pokemonviewmodel.Entrenador = pokemonviewmodel.ListaEntrenadores.FirstOrDefault();
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
