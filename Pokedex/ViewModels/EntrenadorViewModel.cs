using GalaSoft.MvvmLight.Command;
using Pokedex.Catalogos;
using Pokedex.Models;
using Pokedex.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pokedex.ViewModels
{
    public class EntrenadorViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Entrenadores> ListaEntrenadores { get; set; } = new();
        public ObservableCollection<Pokemones> ListaPokemonXEntrenadores { get; set; } = new();

        EntrenadoresCatalogo centrenadores = new();

        public Entrenadores Entrenador { get; set; } = new();

        public bool MostrarErrores { get; set; } = false;

        public int TotalEntrenadores { get; set; }
        public string PrimerPokemon { get; set; } = "";
        public string PokemonMaspesado { get; set; } = "";
        public string Sexo { get; set; } = "";

        public int PokemonsRegistrados { get; set; }
        public int PokemonsFaltantes { get; set; }
        public Vista Vista { get; set; }

        public string Error { get; set; } = "";
        public ICommand VerAgregarEntrenadorCommand { get; set; }
        public ICommand AgregarEntrenadorCommand { get; set; }
        public ICommand RegresarCommand { get; set; }
        public ICommand VerEliminarEntrenadorCommand { get; set; }
        public ICommand EliminarEntrenadorCommand { get; set; }
        public ICommand MostrarErroresCommand { get; set; }
        public ICommand VerEntrenadorCommand { get; set; }


        public EntrenadorViewModel()
        {
            GetEntrenadores();
            VerAgregarEntrenadorCommand = new RelayCommand(VerAagregarEntrenador);
            AgregarEntrenadorCommand = new RelayCommand<string>(AgregarEntrenador);
            RegresarCommand = new RelayCommand(Regresar);

            VerEliminarEntrenadorCommand = new RelayCommand<int>(VerEliminarEntrenador);
            EliminarEntrenadorCommand = new RelayCommand(EliminarEntrenador);

            TotalEntrenadores = ListaEntrenadores.Count;

            VerEntrenadorCommand = new RelayCommand<Entrenadores>(VerEntrenador);
            Actualizar();
        }

        private void VerEntrenador(Entrenadores obj)
        {
            Entrenador = obj;
            Vista = Vista.VerEntrenador;
            ListaPokemonXEntrenadores.Clear();
            foreach (var x in centrenadores.GetPokemonesEntrenador(Entrenador.Id))
            {
                ListaPokemonXEntrenadores.Add(x);
            }
            PrimerPokemon = centrenadores.GetPrimerPokemon(Entrenador.Id);
            PokemonMaspesado = centrenadores.GetPokemonMasPesado(Entrenador.Id);
            PokemonsRegistrados = Entrenador.Pokemones.Count();
            PokemonsFaltantes = 1008 - Entrenador.Pokemones.Count();

            if (Entrenador.Sexo == "M")
                Sexo = "Masculino";
            else
                Sexo = "Femenino";

            Actualizar();
        }

        private void EliminarEntrenador()
        {
            if (Entrenador is not null)
            {
                centrenadores.Delete(Entrenador);
                GetEntrenadores();
                TotalEntrenadores = ListaEntrenadores.Count;
                Actualizar();
                Regresar();
            }
        }

        private void VerEliminarEntrenador(int id)
        {
            Entrenador = centrenadores.GetEntrenadorXId(id);
            Vista = Vista.VerEliminarEntrenador;
            Actualizar();
        }

        private void Regresar()
        {
            Vista = Vista.VerEntrenadores;
            MostrarErrores = false;
            Actualizar();
        }

        private void AgregarEntrenador(string sexo)
        {

            if (Entrenador != null)
            {
                Error = "";
                if (centrenadores.ValidarEntrenador(Entrenador, out List<string> errores))
                {
                    MostrarErrores = false;

                    if (sexo == "Masculino")
                        Entrenador.Sexo = "M";
                    else
                        Entrenador.Sexo = "F";

                    centrenadores.Create(Entrenador);

                    GetEntrenadores();

                    TotalEntrenadores = ListaEntrenadores.Count;

                    Regresar();
                }
                else
                {
                    MostrarErrores = true;
                    foreach (var item in errores)
                    {
                        Error = $"{Error} {item} {Environment.NewLine}";
                    }
                    Actualizar();
                }
            }
        }

        private void VerAagregarEntrenador()
        {
            Vista = Vista.AgregarEntrenadores;
            Error = "";
            Entrenador = new();
            Actualizar();
        }

        public void GetEntrenadores()
        {
            ListaEntrenadores.Clear();

            foreach (var item in centrenadores.GetEntrenadores())
            {
                ListaEntrenadores.Add(item);
            }

        }




        public event PropertyChangedEventHandler? PropertyChanged;

        public void Actualizar(string? prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
