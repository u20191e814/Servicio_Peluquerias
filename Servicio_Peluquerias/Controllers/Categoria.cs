using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicio_Peluquerias.Data;
using Servicio_Peluquerias.Entidades.categoria;


namespace Servicio_Peluquerias.Controllers
{
    
    [ApiController]
    public class Categoria : ControllerBase
    {
        private IConfiguration _config;
        public Categoria(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        [Route("api/peluqueria/categoria")]

        public structure_output_categoria  getCategories()
        {

            return new Db_Categoria(_config["Sqlconnetion"]).getCategories();


        }



    }
}
