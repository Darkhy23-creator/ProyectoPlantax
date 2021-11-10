using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoPlantax.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ProyectoPlantax.Server.Resources;


namespace ProyectoPlantax.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DatosSensorController : ControllerBase
    {
        private readonly ILogger<DatosSensorController> _logger;

        public DatosSensorController(ILogger<DatosSensorController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IEnumerable<DatosSensor> Get()
        {
            List<DatosSensor> lista = new List<DatosSensor>();
            DateTime fecha = new DateTime(); ;
            int temperatura = 0;
            int humedad = 0;
            using (var reader = new StreamReader(System.IO.File.OpenRead(@"Resources/Datos.csv")))
            {
                //var pos = 0;
                while (!reader.EndOfStream)
                {
                    var linea = reader.ReadLine();
                    /*if (pos != 0)
                    {*/
                        var valores = linea.Split(',');

                        fecha = new DateTime(Convert.ToInt32("20" + valores[2]), Convert.ToInt32(valores[1]), Convert.ToInt32(valores[0]));
                        humedad = Convert.ToInt32(valores[3]);
                        temperatura = Convert.ToInt32(valores[4]);

                        DatosSensor i = new DatosSensor(fecha, humedad, temperatura);
                        lista.Add(i);
                    /*}
                    else
                        pos++;*/

                }

            }

            return lista;
        }
    }
}
