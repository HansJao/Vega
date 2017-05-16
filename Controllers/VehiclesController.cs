using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vega.Models;
using Vega.Models.Request;
using Vega.Persistence;

namespace Vega.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly VegaDbContext context;
        public VehiclesController(VegaDbContext context)
        {
            this.context = context;

        }
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleRequest vehicleRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = new Vehicle();
            result.LastUpdate = DateTime.Now;
            result.IsRegistered = vehicleRequest.IsRegistered;
            result.ModelId = vehicleRequest.ModelId;
            result.ContactPhone = vehicleRequest.Contact.Phone;
            result.ContactName = vehicleRequest.Contact.Name;
            result.ContactEmail = vehicleRequest.Contact.Email;
            //result.Features.Add(new VehicleFeature{});
            context.Vehicles.Add(result);
            await context.SaveChangesAsync();
            return Ok(result);
        }
    }
}