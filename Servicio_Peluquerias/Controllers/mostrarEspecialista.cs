using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicio_Peluquerias.Data;
using Servicio_Peluquerias.Entidades.mostrarEspecialistas;

namespace Servicio_Peluquerias.Controllers
{
     
    [ApiController]
    public class MostrarEspecialista : ControllerBase
    {
        private IConfiguration _config;
        public MostrarEspecialista(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        [Route("api/peluqueria/getRegion")] 
        public structure_output_mostrarEspecialistas getRegion()
        {

            return new Db_mostrarEspecialistas(_config["Sqlconnetion"]).getRegion();


        }

        [HttpGet]
        [Route("api/peluqueria/getProvince")]
        public structure_output_mostrarEspecialistas getProvince(int id_region)
        {

            return new Db_mostrarEspecialistas(_config["Sqlconnetion"]).getProvince(id_region);


        }

        [HttpGet]
        [Route("api/peluqueria/getDistrict")]
        public structure_output_mostrarEspecialistas getDistrict(int id_province)
        {

            return new Db_mostrarEspecialistas(_config["Sqlconnetion"]).getDistrict(id_province);

        }

        [HttpGet]
        [Route("api/peluqueria/getEspecialistas")]
        public structure_output_especialistas getEspecialistas(int id_categoria, int id_provincia, int id_distrito)
        {

            return new Db_mostrarEspecialistas(_config["Sqlconnetion"]).getEspecialistas(id_categoria, id_provincia, id_distrito);

        }
    }
}
