using ApiEvalD2P2P3.Encryption;
using ApiEvalD2P2P3.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EncryptionController : ControllerBase
{
    private readonly EncryptionStrategyFactory _encryptionFactory;

    public EncryptionController(EncryptionStrategyFactory encryptionFactory)
    {
        _encryptionFactory = encryptionFactory;
    }

    [HttpPost("encrypt")]
    public IActionResult Encrypt(ApplicationType type, string text)
    {
        var strategy = _encryptionFactory.GetStrategy(type);
        var encrypted = strategy.Encrypt(text);
        return Ok(encrypted);
    }
}
