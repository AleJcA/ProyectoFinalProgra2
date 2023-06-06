using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace ProyectoFinal.ViewModels
{
    public class ViewModelAereo : INotifyPropertyChanged
    {

        public ViewModelAereo() {


            try
            {

                byte[] data = File.ReadAllBytes(ruta);
                MemoryStream memory = new MemoryStream(data);
                BinaryFormatter formater = new BinaryFormatter();
                listaAereo = (ObservableCollection<Aereo>)formater.Deserialize(memory);
                memory.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Sin archivo por cargar de Medios de Transporte");

            }

            crearAereo = new Command(() => {

                Aereo medioAereo = new Aereo()
                {
                    NombreA = this.nombreAereo,
                    ModeloA = this.modeloAereo,
                    AñoL = this.AñoLAereo,
                    ColorA = this.ColorAereo,
                    CantHelices = this.CantidadHAereo,
                    CantAlas = this.CantidadAAereo

                    

                };

                listaAereo.Add(medioAereo);

                BinaryFormatter formateador = new BinaryFormatter();
                MemoryStream memoria = new MemoryStream();
                formateador.Serialize(memoria, listaAereo);
                byte[] datoSerializados = memoria.ToArray();
                memoria.Close();

                File.WriteAllBytes(ruta, datoSerializados);

                nombreaereo = String.Empty;
                modeloaereo = String.Empty;
                añolaereo = 0;
                coloraereo = String.Empty;
                cantidadhaereo = 0;
                cantidadaaereo = 0;




            });
            
        }

        public ObservableCollection<Aereo> listaAereo { get; set; } = new ObservableCollection<Aereo>();

        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MediosAereos.bin");

        string nombreAereo;

        public string nombreaereo
        {

            get => nombreAereo;
            set
            {
                nombreAereo = value;
                var args = new PropertyChangedEventArgs(nameof(nombreaereo));
                PropertyChanged?.Invoke(this, args);
            }
        }

        string modeloAereo;

        public string modeloaereo
        {

            get => modeloAereo;
            set
            {
                modeloAereo = value;
                var args = new PropertyChangedEventArgs(nameof(modeloaereo));
                PropertyChanged?.Invoke(this, args);
            }
        }

        short AñoLAereo;

        public short añolaereo
        {

            get => AñoLAereo;
            set
            {
                AñoLAereo = value;
                var args = new PropertyChangedEventArgs(nameof(añolaereo));
                PropertyChanged?.Invoke(this, args);
            }
        }

        string ColorAereo;

        public string coloraereo
        {

            get => ColorAereo;
            set
            {
                ColorAereo = value;
                var args = new PropertyChangedEventArgs(nameof(coloraereo));
                PropertyChanged?.Invoke(this, args);
            }
        }

        short CantidadHAereo;

        public short cantidadhaereo
        {

            get => CantidadHAereo;
            set
            {
                CantidadHAereo= value;
                var args = new PropertyChangedEventArgs(nameof(cantidadhaereo));
                PropertyChanged?.Invoke(this, args);
            }
        }

        short CantidadAAereo;

        public short cantidadaaereo
        {

            get => CantidadAAereo;
            set
            {
                CantidadAAereo = value;
                var args = new PropertyChangedEventArgs(nameof(cantidadaaereo));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command crearAereo { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
