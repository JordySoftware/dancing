using Back_Factura.Data;
using Back_Factura.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_Factura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        public readonly FacturaDBContext _dbcontext;

        public FacturaController(FacturaDBContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Factura> lista = new List<Factura>();

            try
            {
                lista = _dbcontext.Facturas.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }


           
            }
        [HttpGet]
        [Route("Obtener/{id_factura:int}")]

        public IActionResult Obtener(int id_factura)
        {
            Factura oFactura = _dbcontext.Facturas.Find(id_factura);

            if (oFactura == null)
            {
                return BadRequest("Producto no encontrado");

            }

            try
            {

                oFactura = _dbcontext.Facturas.Where(p => p.id_factura == id_factura).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oFactura });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oFactura });


            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Factura objeto)
        {


            try
            {
                _dbcontext.Facturas.Add(objeto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }




        }


        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Factura objeto)
        {
            Factura oFactura = _dbcontext.Facturas.Find(objeto.id_factura);

            if (oFactura == null)
            {
                return BadRequest("Producto no encontrado");

            }

            try
            {
                oFactura.codigo = objeto.codigo is 0 ? oFactura.codigo : objeto.codigo;
                oFactura.descripcion= objeto.descripcion is null ? oFactura.descripcion : objeto.descripcion;
                oFactura.cant = objeto.cant is 0 ? oFactura.cant : objeto.cant;
                oFactura.precio = objeto.precio is 0 ? oFactura.precio: objeto.precio;
                oFactura.total = objeto.total is 0 ? oFactura.total : objeto.total;



                _dbcontext.Facturas.Update(oFactura);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }




        }

        [HttpDelete]
        [Route("Eliminar/{id_factura:int}")]
        public IActionResult Eliminar(int id_factura)
        {

            Factura oProducto = _dbcontext.Facturas.Find(id_factura);

            if (oProducto == null)
            {
                return BadRequest("Producto no encontrado");

            }

            try
            {

                _dbcontext.Facturas.Remove(oProducto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }


        }







    }
}
