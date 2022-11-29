using Microsoft.AspNetCore.Mvc;
using SistemaDeVentasCoder.ADO.NET;
using SistemaDeVentasCoder.Models;
using System.Data.SqlClient;

namespace SistemaDeVentasCoder.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioHandler handler = new UsuarioHandler();

        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
            try
            {
                List<Usuario> lista = handler.GetUsuario();
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
    }
}