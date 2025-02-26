using ApiEvalD2P2P3.Entities;
using ApiEvalD2P2P3.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiEvalD2P2P3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordService _passwordService;

        public PasswordController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        // GET: api/password
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PasswordEntity>>> GetPasswords()
        {
            var passwords = await _passwordService.GetPasswordsAsync();
            return Ok(passwords);
        }

        // GET: api/password/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PasswordEntity>> GetPassword(int id)
        {
            var password = await _passwordService.GetPasswordByIdAsync(id);
            if (password == null)
            {
                return NotFound();
            }
            return Ok(password);
        }

        // POST: api/password
        [HttpPost]
        public async Task<ActionResult<PasswordEntity>> AddPassword(PasswordEntity password)
        {
            var createdPassword = await _passwordService.AddPasswordAsync(password);
            return CreatedAtAction(nameof(GetPassword), new { id = createdPassword.Id }, createdPassword);
        }

        // DELETE: api/password/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassword(int id)
        {
            var success = await _passwordService.DeletePasswordAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
