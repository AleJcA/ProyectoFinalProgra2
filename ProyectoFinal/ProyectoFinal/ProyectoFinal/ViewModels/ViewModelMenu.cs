using ProyectoFinal.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ProyectoFinal.ViewModels
{
    public class ViewModelMenu : INotifyPropertyChanged
    {
        public ViewModelMenu() {

            navegarCrearAereo = new Command(() =>
            {

                var paginaAereo = new CrearAereo();
                Application.Current.MainPage.Navigation.PushAsync(paginaAereo);

            });

            navegarCrearTerrestre = new Command(() =>
            {

                var paginaTerrestre = new Page1();
                Application.Current.MainPage.Navigation.PushAsync(paginaTerrestre);

            });

            navegarCrearMostrarVehiculos = new Command(() =>
            {

                var paginaMostrarVehiculos = new MostrarVehiculos();
                Application.Current.MainPage.Navigation.PushAsync(paginaMostrarVehiculos);

            });



        }

        public Command navegarCrearAereo { get; }
        public Command navegarCrearTerrestre { get; }
        public Command navegarCrearMostrarVehiculos { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
