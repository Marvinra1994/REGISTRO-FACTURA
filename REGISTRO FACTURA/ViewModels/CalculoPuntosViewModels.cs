using REGISTRO_FACTURA.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace REGISTRO_FACTURA.ViewModels
{
    public class CalculoPuntosViewModels : INotifyPropertyChanged
    {

        public CalculoPuntosViewModels()
        {


            CrearPuntos = new Command(() =>
            {
                Puntos p1 = new Puntos()
                {
                    punto = this.punto,
                    nombre = this.nombre,
                    fecha_factura = this.fecha_factura,
                    monto = this.monto,
                    num_factura = this.num_factura,
                    metodopago = this.metodopago,
                    tipo_factura = this.tipo_factura

                };

                p1.calculopuntos();
                

                listapuntos.Add(p1);

                Resultado = p1.toString();

                Resultado = "";
                foreach (Puntos tmp in listapuntos)
                {

                    Resultado += tmp.toString() + "\r\n";
                }

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "Puntos.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, listapuntos);
                archivo.Close();



            });



            AbrirLista = new Command(() => {

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "Puntos.aut");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

                listapuntos = (ObservableCollection<Puntos>)formatter.Deserialize(archivo);
                archivo.Close();

                Resultado = "";

                foreach (Puntos tmp in listapuntos)
                {

                    Resultado += tmp.toString() + "\r\n";

                }


            });

            LimpiarLista = new Command(() => {

                listapuntos = new ObservableCollection<Puntos>();

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "Puntos.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, listapuntos);
                archivo.Close();

                Resultado = "";

            });

        }


        ObservableCollection<Puntos> listapuntos = new ObservableCollection<Puntos>();

        String nombre;

        public String Nombre
        {
            get => nombre;

            set
            {

                nombre = value;
                var args = new PropertyChangedEventArgs(nameof(Nombre));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string resultado;

        public string Resultado
        {
            get => resultado;

            set
            {

                resultado = value;
                var args = new PropertyChangedEventArgs(nameof(Resultado));
                PropertyChanged?.Invoke(this, args);
            }
        }

        String fecha_factura;
        public String Fecha_Factura
        {
            get => fecha_factura;

            set
            {

                fecha_factura = value;
                var args = new PropertyChangedEventArgs(nameof(Fecha_Factura));
                PropertyChanged?.Invoke(this, args);

            }
        }

        int monto;
        public int Monto
        {
            get => monto;

            set
            {

                monto = value;
                var args = new PropertyChangedEventArgs(nameof(Monto));
                PropertyChanged?.Invoke(this, args);

            }
        }

        int num_factura;
        public int Num_Factura
        {
            get => monto;

            set
            {

                num_factura = value;
                var args = new PropertyChangedEventArgs(nameof(Num_Factura));
                PropertyChanged?.Invoke(this, args);

            }
        }

        String metodopago;
        public String MetodoPago
        {
            get => metodopago;

            set
            {

                metodopago = value;
                var args = new PropertyChangedEventArgs(nameof(MetodoPago));
                PropertyChanged?.Invoke(this, args);

            }
        }

        String tipo_factura;
        public String Tipo_Factura
        {
            get => tipo_factura;

            set
            {

                tipo_factura = value;
                var args = new PropertyChangedEventArgs(nameof(Tipo_Factura));
                PropertyChanged?.Invoke(this, args);

            }
        }

        int punto;
        public int Punto
        {
            get => punto;

            set
            {

                punto = value;
                var args = new PropertyChangedEventArgs(nameof(Punto));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public Command CrearPuntos { get; }

        public Command AbrirLista { get; }

        public Command LimpiarLista { get; }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
