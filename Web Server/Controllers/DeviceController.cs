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
        public async Task<IActionResult> AddDevices(int id, [FromBody] Device device)
        {
            if (id != device.Id) return BadRequest("Id does not match id in url");
            if (_context.Devices.Any(elem => elem.Id == id)) return BadRequest("this element contains in database");
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDevices), new { id = device.Id }, device);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id) 
        {
            var device = _context.Devices.Find(id);
            if (device == null) return BadRequest("Not found");
            _context.Devices.Remove(device);
            await _context.SaveChangesAsync(); 

            return Ok();
        }
    }
}
