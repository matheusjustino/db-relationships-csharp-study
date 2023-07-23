namespace db_relationships_csharp_study.Services;

using Microsoft.EntityFrameworkCore;
using db_relationships_csharp_study.Data;
using db_relationships_csharp_study.Models;
using db_relationships_csharp_study.DTOs.Character;

public class TlouService : ITlouService
{
    private readonly ILogger<TlouService> _logger;
    private readonly ApplicationDbContext _context;

    public TlouService(ApplicationDbContext context, ILogger<TlouService> logger)
    {
        this._logger = logger;
        this._context = context;
    }

    public async Task<List<Character>> CreateCharacter(CreateCharacterDTO data)
    {
        this._logger.Log(LogLevel.Information, $"Create Character - {data.ToString()}");

        var newCharacter = new Character
        {
            Name = data.Name,
        };
        var backpack = new Backpack { Description = data.Backpack.Description, Character = newCharacter };
        var weapons = data.Weapons.Select(w => new Weapon { Name = w.Name, Character = newCharacter }).ToList();
        var factions = data.Factions.Select(f => new Faction { Name = f.Name, Characters = new List<Character> { newCharacter } }).ToList();

        newCharacter.Backpack = backpack;
        newCharacter.Weapons = weapons;
        newCharacter.Factions = factions;

        await this._context.Characters.AddAsync(newCharacter);
        await this._context.SaveChangesAsync();

        return await this._context.Characters
            .Include(c => c.Backpack)
            .Include(c => c.Weapons)
            .Include(c => c.Factions)
            .ToListAsync();
    }

    public async Task<List<Character>> ListCharacters()
    {
        this._logger.Log(LogLevel.Information, "List Characters");
        return await this._context.Characters
                .Include(c => c.Backpack)
                .Include(c => c.Weapons)
                .Include(c => c.Factions)
                .ToListAsync();
    }

    public async Task<Character?> GetCharacterById(Guid id)
    {
        this._logger.Log(LogLevel.Information, $"Get Character By Id - id: {id}");

        var character = await this._context.Characters
            .Include(c => c.Backpack)
            .Include(c => c.Weapons)
            .Include(c => c.Factions)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (character is null)
        {
            throw new BadHttpRequestException("Character not found");
        }

        return character;
    }
}
