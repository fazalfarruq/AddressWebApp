using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AddressWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace AddressWebApp.Controllers
{
    [Route("api/canadapost")]
    [AllowAnonymous]
    public class CanadaPostApiController : Controller
    {
        private DataContext db = new DataContext();

        [Produces("application/json")]
        [HttpGet("search")]
        public async Task<IActionResult> Search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var cities = db.Addresses.Where(a => a.City.Contains(term)).Select(p => p.City).ToList();
                return Ok(cities);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}