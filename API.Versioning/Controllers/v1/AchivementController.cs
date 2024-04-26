
using API.Versioning.Services.v1.Interfaces;

namespace API.Versioning.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AchivementController : BaseController
    {
        protected readonly IDriver driverService;
        protected readonly IAchivement achivementService;

        public AchivementController(IDriver driverService, IAchivement achivementService)
        {
            this.driverService = driverService;
            this.achivementService = achivementService;
        }

        [HttpPost("CreateAchivement")]
        public async Task<IActionResult> CreateAchivement(AchivementInfo model)
        {
            try
            {
                var data = await achivementService.CreateOrUpdateAchivement(model);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAchivementByDriverId")]
        public async Task<IActionResult> GetAchivementByDriverId(Guid Id)
        {
            try
            {
                var data = await achivementService.GetAchivementsByDriverId(Id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("DeleteAchivement")]
        public async Task<IActionResult> DeleteAchivement(Guid Id)
        {
            try
            {
                var data = await achivementService.DeleteAchivement(Id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
