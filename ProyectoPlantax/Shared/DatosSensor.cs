using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoPlantax.Shared
{
    public class DatosSensor
    {
        public DateTime fecha { get; set; }

        public int temperatura { get; set; }

        public int humedad { get; set; }
        public DatosSensor() { }

        public DatosSensor(DateTime f, int i, int m)
        {
            this.fecha = f;
            this.temperatura = i;
            this.humedad = m;
        }
    }
}
