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
        [HttpDelete]
        [Route("api/peluqueria/removeClient")]

        public structure_post_bool removeClient(int id_cliente)
        {
            structure_post_bool estructura = new structure_post_bool();
            estructura.status = "400";
            if (id_cliente <=0)
            {
                estructura.statusMessage = "Valor ingresado es incorrecto";
                return estructura;
            }



            estructura = new Db_Cliente(_config["Sqlconnetion"]).removeClient(id_cliente);


            return estructura;
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
            int cantidad = new Db_Cliente(_config["Sqlconnetion"]).ValidarCorreo(cliente.Correo);
            if (cantidad==-1)
            {
                estructura.statusMessage = "Error en la base de datos ";
                return estructura;
            }
            if (cantidad > 1)
            {
                estructura.statusMessage = "El correo ya existe registrado";
                return estructura;
            }

            estructura  = new Db_Cliente(_config["Sqlconnetion"]).RegistrarCliente(cliente);
              
            return estructura;
        }

        [HttpPost]
        [Route("api/peluqueria/updateClient")]

        public structure_post_bool updateClient(Entidades.Cliente_output cliente)
        {
            structure_post_bool estructura = new structure_post_bool();
            estructura.status = "400";
            if (cliente == null)
            {
                estructura.statusMessage = "Valor ingresado esta vacio";
                return estructura;
            }

            

            estructura = new Db_Cliente(_config["Sqlconnetion"]).updateClient(cliente);

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
