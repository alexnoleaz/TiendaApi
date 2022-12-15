using Microsoft.AspNetCore.Mvc;
using TiendaApi.Data;
using TiendaApi.Models;

namespace TiendaApi.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<MProducts>>> Get()
        {
            var function = new DProducts();
            var list = await function.ShowProducts();
            return list;
        }

        [HttpPost]
        public async Task Post([FromBody] MProducts values)
        {
            var function = new DProducts();
            await function.AddProducts(values);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,[FromBody] MProducts values)
        {
            var function = new DProducts();
            values.Id = id;

            await function.UpdateProducts(values);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id){
            var function = new DProducts();
            var parameters = new MProducts();
            parameters.Id = id;

            await function.DeleteProducts(parameters);
            return NoContent();
        }
    }
}
