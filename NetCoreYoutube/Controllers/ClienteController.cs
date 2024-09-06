using Microsoft.AspNetCore.Mvc;
using NetCoreYoutube.Models;

namespace NetCoreYoutube.Controllers
{
    [ApiController]
    [Route("cliente")] //direccion/cliente/clientes
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("clientes")]
        public dynamic listarCliente() 
        {

            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente
                {
                    id = "1",
                    edad = "39",
                    nombre = "Cristiano",
                    correo = "cristiano@gmail.com",
                },
                new Cliente
                {
                    id="2",
                    edad="24",
                    nombre="Kylian",
                    correo = "kylian@gmail.com"
                }
            };
            return clientes;
        
        }

        [HttpGet]
        [Route("id")]
        public dynamic getClientebyId(string id)
        {
            return new Cliente 
            { 
                id = id,
                nombre = "Otra persona",
                edad = "19",
                correo = "otro@gmail.com",
            };    

        }

        [HttpPost]
        [Route("guardar")]
        public dynamic guardarCliente(Cliente cliente)
        {
            cliente.id = cliente.id ?? "5";
            return new
            {
                success = true,
                message = "Cliente registrado",
                result = cliente
            };
        }

        [HttpDelete]
        [Route("eliminar")]
        public dynamic eliminarCliente(Cliente cliente)
        {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
            // Validar si el token tiene valor
            if(token == null) return new { success = false, message = "Token must have a value", cliente = "" };

            // Validar si es un token valido
            if (token != "admin") return new { success = false, message = "Invalid token", cliente = "" };

            // Eliminar cliente de la bd
            return new
            {
                success = true,
                message = "Cliente eliminado",
                result = cliente
            };
        }


    }
}
