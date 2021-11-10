using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPlantax.Server.Data
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

        public List<DatosSensor> CargarInformacion()
        {
            List<DatosSensor> lista = new List<DatosSensor>();
            DateTime fecha = new DateTime(); ;
            int temperatura = 0;
            int humedad = 0;

            using (var reader = new StreamReader(File.OpenRead(@"Resources/Datos.csv")))
            {
                while (!reader.EndOfStream)
                {
                    var linea = reader.ReadLine();
                    var valores = linea.Split(',');

                    fecha = new DateTime(Convert.ToInt32(valores[2]), Convert.ToInt32(valores[1]), Convert.ToInt32(valores[0]));
                    humedad = Convert.ToInt32(valores[3]);
                    temperatura = Convert.ToInt32(valores[4]);

                    DatosSensor i = new DatosSensor(fecha, humedad, temperatura);
                    lista.Add(i);

                }

            }

            return lista;
        }
    }
}
