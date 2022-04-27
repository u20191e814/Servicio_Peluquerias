using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicio_Peluquerias.Data;
using Servicio_Peluquerias.Entidades.subCategoria;

namespace Servicio_Peluquerias.Controllers
{
   
    [ApiController]
    public class subCategorias : ControllerBase
    {
        private IConfiguration _config;
        public subCategorias(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        [Route("api/peluqueria/getsubCategoria")]

        public structure_output_subcategorias getsubCategoria(int fk_categoria)
        {

            return new Db_SubCategoria(_config["Sqlconnetion"]).getCategories(fk_categoria);


        }

    }
}
