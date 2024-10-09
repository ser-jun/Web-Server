using Microsoft.AspNetCore.Mvc;
using Web_Server.Models;
using Microsoft.EntityFrameworkCore;


namespace Web_Server.Controllers
{
    [ApiController]
    [Route("api/devices")]
    public class DeviceController : ControllerBase
    {
        private readonly DataContext _context;
        public DeviceController(DataContext context)
        {
            _context=context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Device>>> GetDevices()
        {
            return await _context.Devices.ToListAsync();
        }

        [HttpPost("{id}")] 
        public async Task<IActionResult> AddDevices(int id, [FromBody]  Device device)
        {
            return null;
        }
    }
}
