using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicio_Peluquerias.Data;
using Servicio_Peluquerias.Entidades;
using Servicio_Peluquerias.Entidades.cliente;

namespace Servicio_Peluquerias.Controllers
{
   
    [ApiController]
    public class Cliente : ControllerBase
    {
        private IConfiguration _config;
        public Cliente(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost]
        [Route("api/peluqueria/client")]

        public structure_post_int addClient(Entidades. Cliente cliente)
        {
            structure_post_int estructura = new structure_post_int();
            estructura.status = "400";
            if (cliente == null)
            {
                estructura.statusMessage = "Valor ingresado esta vacio";
                return estructura;
            }

            if (!ModelState.IsValid)
            {
                estructura.statusMessage = "Se encontraron atributos vacios Todos son obligatorios ";
                return estructura;
            }

            estructura  = new Db_Cliente(_config["Sqlconnetion"]).RegistrarCliente(cliente);
              
            return estructura;
        }

        [HttpPost]
        [Route("api/peluqueria/login")]

        public structure_output_client login(Entidades.User user)
        {
            structure_output_client estructura = new structure_output_client();
            estructura.status = "400";
            if (user == null)
            {
                estructura.statusMessage = "Valor ingresado esta vacio";
                return estructura;
            }

            if (!ModelState.IsValid)
            {
                estructura.statusMessage = "Se encontraron atributos vacios Todos son obligatorios ";
                return estructura;
            }

            estructura = new Db_Cliente(_config["Sqlconnetion"]).login(user);

            return estructura;
        }

    }
}
