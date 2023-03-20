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

        EntrenadoresCatalogo centrenadores = new();

        public Entrenadores Entrenador { get; set; } = new();

        public bool MostrarErrores { get; set; } = false;

        public Vista Vista { get; set; }

        public string Error { get; set; } = "";
        public ICommand VerAgregarEntrenadorCommand { get; set; }
        public ICommand AgregarEntrenadorCommand { get; set; }
        public ICommand RegresarCommand { get; set; }
        public ICommand VerEliminarEntrenadorCommand { get; set; }
        public ICommand EliminarEntrenadorCommand { get; set; }
        public ICommand MostrarErroresCommand { get; set; }


        public EntrenadorViewModel()
        {
            GetEntrenadores();
            VerAgregarEntrenadorCommand = new RelayCommand(VerAagregarEntrenador);
            AgregarEntrenadorCommand = new RelayCommand<string>(AgregarEntrenador);
            RegresarCommand = new RelayCommand(Regresar);

            VerEliminarEntrenadorCommand = new RelayCommand<int>(VerEliminarEntrenador);
            EliminarEntrenadorCommand = new RelayCommand(EliminarEntrenador);



            Actualizar();
        }

        private void EliminarEntrenador()
        {
            if(Entrenador is not null)
            {
                centrenadores.Delete(Entrenador);
                GetEntrenadores();
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
            Actualizar();
        }

        private void AgregarEntrenador(string sexo)
        {

            if(Entrenador != null) 
            {
                Error = "";
                if (centrenadores.ValidarEntrenador(Entrenador, out List<string> errores))
                {
                    if (sexo == "Masculino")
                        Entrenador.Sexo = "M";
                    else
                        Entrenador.Sexo = "F";

                    centrenadores.Create(Entrenador);
                    GetEntrenadores();
                    Regresar();
                }
                else
                {
                    foreach (var item in errores)
                    {
                        Error = $"{Error} {Environment.NewLine} {item}";
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
