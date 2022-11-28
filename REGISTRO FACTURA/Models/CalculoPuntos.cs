using System;
using System.Collections.Generic;
using System.Text;

namespace REGISTRO_FACTURA.Models
{
    [Serializable]
    internal class Puntos
    {
        public String nombre { get; set; }
        public String fecha_factura { get; set; }
        public int num_factura { get; set; }
        public double monto { get; set; }

        public String metodopago { get; set; }
        public String tipo_factura { get; set; }

        public int punto { get; set; }

        public void calculopuntos()
        {
            punto = 0;

            if (tipo_factura == "Consumo")
            {
                punto = 0;
            }

            else if (metodopago == "Tarjeta")
            {
                punto = (int)(monto * 0.02);
            }

            else if (metodopago == "Efectivo")
            {
                punto = (int)(monto * 0.03);
            }
            else
            {
                punto = 0;
            }
            

        }

        public string toString()
        {
            return "Sus puntos asignados son " + punto;
        }
    }
}
