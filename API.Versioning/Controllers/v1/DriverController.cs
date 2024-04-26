
using API.Versioning.Services.v1.Interfaces;

namespace API.Versioning.Controllers.v1
{
    [ApiVersion("1", Deprecated = true)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DriverController : BaseController
    {
        protected readonly IDriver driverService;
        protected readonly IAchivement achivementService;

        public DriverController(IDriver driverService, IAchivement achivementService)
        {
            this.driverService = driverService;
            this.achivementService = achivementService;
        }

        [HttpPost("CreateDriver")]
        public async Task<IActionResult> CreateDriver(DriverInfo model)
        {
            try
            {
                var data = await driverService.CreateOrUpdateDriver(model);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllDrivers")]
        public async Task<IActionResult> GetAllDrivers()
        {
            try
            {
                var data = await driverService.GetAllDrivers();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetDriverById")]
        public async Task<IActionResult> GetDriverById(Guid Id)
        {
            try
            {
                var data = await driverService.GetDriverById(Id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("DeleteDriver")]
        public async Task<IActionResult> DeleteDriver(Guid Id)
        {
            try
            {
                var data = await driverService.DeleteDriver(Id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
