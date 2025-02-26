using ApiEvalD2P2P3.Entities;
using ApiEvalD2P2P3.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiEvalD2P2P3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        // GET: api/application
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationEntity>>> GetApplications()
        {
            var applications = await _applicationService.GetApplicationsAsync();
            return Ok(applications);
        }

        // GET: api/application/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationEntity>> GetApplication(int id)
        {
            var application = await _applicationService.GetApplicationByIdAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            return Ok(application);
        }

        // POST: api/application
        [HttpPost]
        public async Task<ActionResult<ApplicationEntity>> AddApplication(ApplicationEntity application)
        {
            var createdApplication = await _applicationService.AddApplicationAsync(application);
            return CreatedAtAction(nameof(GetApplication), new { id = createdApplication.Id }, createdApplication);
        }

        // DELETE: api/application/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            var success = await _applicationService.DeleteApplicationAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
