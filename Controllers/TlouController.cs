namespace db_relationships_csharp_study.Controllers;

using Microsoft.AspNetCore.Mvc;
using db_relationships_csharp_study.Models;
using db_relationships_csharp_study.DTOs.Character;
using db_relationships_csharp_study.Services;

[Route("api/[controller]")]
[ApiController]
public class TlouController : ControllerBase
{
    private readonly ITlouService _tlouService;

    public TlouController(ITlouService tlouService)
    {
        this._tlouService = tlouService;
    }

    [HttpPost]
    public async Task<ActionResult<List<Character>>> CreateCharacter([FromBody] CreateCharacterDTO body)
    {
        if (!this.ModelState.IsValid)
        {
            return BadRequest(new { message = "Invalid payload" });
        }

        var newCharacter = await this._tlouService.CreateCharacter(body);
        return Ok(newCharacter);
    }

    [HttpGet]
    public async Task<ActionResult<List<Character>>> ListCharacters()
    {
        return Ok(await this._tlouService.ListCharacters());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Character?>> GetCharacterById([FromRoute] Guid id)
    {
        return Ok(await this._tlouService.GetCharacterById(id));
    }
}
