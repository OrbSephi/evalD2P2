using ApiEvalD2P2P3.Dto;
using ApiEvalD2P2P3.Encryption;
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
        private readonly IApplicationService _applicationService;
        private readonly EncryptionStrategyFactory _encryptionFactory;
        public PasswordController(IPasswordService passwordService, IApplicationService applicationService, EncryptionStrategyFactory encryptionFactory)
        {
            _passwordService = passwordService;
            _applicationService = applicationService;
            _encryptionFactory = encryptionFactory;
        }

        // GET: api/password
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PasswordDto>>> GetPasswords()
        {
            var passwords = await _passwordService.GetPasswordsAsync();
            var decryptedPassword = new PasswordDto();
            var decryptedPasswords = new List<PasswordDto>();

            foreach (var password in passwords)
            {
                var strategy = _encryptionFactory.GetStrategy(password.Application.Type); // Récupérer la stratégie en fonction du type d'application
                decryptedPassword.Password = strategy.Decrypt(password.EncryptedPassword); // Déchiffrer le mot de passe
                decryptedPasswords.Add(decryptedPassword);
            }
            return Ok(decryptedPasswords);
        }

        // GET: api/password/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PasswordDto>> GetPassword(int id)
        {
            var password = await _passwordService.GetPasswordByIdAsync(id);
            if (password == null)
            {
                return NotFound();
            }
            password.Application= await _applicationService.GetApplicationByIdAsync(password.ApplicationId);
            
            var passwordDto = new PasswordDto();
            var strategy = _encryptionFactory.GetStrategy(password.Application.Type); // Récupérer la stratégie en fonction du type d'application
            passwordDto.Password = strategy.Decrypt(password.EncryptedPassword);
            passwordDto.ApplicationId = password.ApplicationId;
            return Ok(passwordDto);
        }

        // POST: api/password
        [HttpPost]
        public async Task<ActionResult<PasswordDto>> AddPassword(PasswordDto dto)
        {
            var application = await _applicationService.GetApplicationByIdAsync(dto.ApplicationId);
            var strategy = _encryptionFactory.GetStrategy(application.Type); // Récupérer la stratégie en fonction du type d'application
            var encryptedPassword = strategy.Encrypt(dto.Password);
            var password = new PasswordEntity {
                
                ApplicationId = dto.ApplicationId,
                Application = application,
                EncryptedPassword = encryptedPassword
            };
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
