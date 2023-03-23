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
    public class PokemonViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<Entrenadores> ListaEntrenadores { get; set; } = new();
        public ObservableCollection<Pokemones> ListaPokemons { get; set; } = new();
        public ObservableCollection<Tipos> ListaTipos { get; set; } = new();

        EntrenadoresCatalogo centrenadores = new();

        PokemonCatalogo cpokemon = new();

        public Entrenadores Entrenador { get; set; } = new();
        public Pokemones Pokemon { get; set; } = new();

        public bool MostrarErrores { get; set; } = false;
        public Vista Vista { get; set; }

        public string Error { get; set; } = "";

        public ICommand VerAgregarPokemonCommand { get; set; }
        public ICommand AgregarPokemonCommand { get; set; }
        public ICommand RegresarCommand { get; set; }
        public ICommand VerEliminarPokemonCommand { get; set; }
        public ICommand EliminarPokemonCommand { get; set; }
        public ICommand GetPokemonsCommand { get; set; }
        public ICommand VerPokemonCommand { get; set; }
        public ICommand MostrarErroresCommad { get; set; }
        public PokemonViewModel()
        {
            VerAgregarPokemonCommand = new RelayCommand(VerAgregarPokemon);
            AgregarPokemonCommand = new RelayCommand<int>(AgregarPokemon);

            GetPokemonsCommand = new RelayCommand<int>(GetPokemones);
            RegresarCommand = new RelayCommand(Regresar);
            VerPokemonCommand = new RelayCommand<Pokemones>(VerPokemon);

            VerEliminarPokemonCommand = new RelayCommand(VerEliminarPokemon);
            EliminarPokemonCommand = new RelayCommand(EliminarPokemon);

            MostrarErroresCommad = new RelayCommand<string>(MostrarErroresMetodo);

            GetEntrenadores();

            Entrenador = ListaEntrenadores.FirstOrDefault();

            Actualizar();


        }

        private void MostrarErroresMetodo(string obj)
        {
            if (obj == "Si")
                MostrarErrores = true;
            else
                MostrarErrores = false;

            Actualizar();

        }

        private void EliminarPokemon()
        {
            if (Entrenador != null && Pokemon != null)
            {
                cpokemon.Delete(Pokemon);
                GetPokemones(Pokemon.Entrenador.Id);
                GetEntrenadores();
                Regresar();

            }
        }

        private void VerEliminarPokemon()
        {
            Vista = Vista.EliminarPokemon;
            Actualizar();
        }




        private void AgregarPokemon(int id)
        {
            if (Pokemon is not null && Entrenador is not null)
            {
                MostrarErrores = false;
                Error = "";
                if (cpokemon.Validar(Pokemon, out List<string> errores))
                {

                    Pokemon.TipoId = id;

                    Pokemon.EntrenadorId = Entrenador.Id;

                    cpokemon.Create(Pokemon);

                    GetPokemones(Entrenador.Id);
                    
                    GetEntrenadores();

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

        private void Regresar()
        {
            Vista = Vista.VerPokemons;
            MostrarErrores = false;
            Error = "";
            Actualizar();
        }

        private void VerPokemon(Pokemones poke)
        {
            Vista = Vista.VerPokemon;
            Pokemon = poke;
            Actualizar();
        }

        private void VerAgregarPokemon()
        {
            if (Entrenador is not null)
            {
                Vista = Vista.AgregarPokemon;
                Error = "";
                Pokemon = new();
                GetTipos();
                Actualizar();
            }
        }



        public void GetEntrenadores()
        {
            ListaEntrenadores.Clear();
            foreach (var item in centrenadores.GetEntrenadores())
            {
                ListaEntrenadores.Add(item);
            }

        }

        public void GetTipos()
        {
            ListaTipos.Clear();
            foreach (var item in cpokemon.GetTipos())
            {
                ListaTipos.Add(item);
            }
        }

        public void GetPokemones(int id)
        {
            if (Entrenador is not null)
            {
                ListaPokemons.Clear();
                foreach (var item in cpokemon.GetPokemons(id))
                {
                    ListaPokemons.Add(item);
                }
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        public void Actualizar(string? prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
