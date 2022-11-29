using Microsoft.AspNetCore.Mvc;
using SistemaDeVentasCoder.ADO.NET;
using SistemaDeVentasCoder.Models;
using System.Data.SqlClient;

namespace SistemaDeVentasCoder.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class VentaController : ControllerBase
    {
        private VentaHandler handler = new VentaHandler();

        [HttpGet]
        public ActionResult<List<Venta>> Get()
        {
            try
            {
                List<Venta> lista = handler.GetVenta();
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
    }
}