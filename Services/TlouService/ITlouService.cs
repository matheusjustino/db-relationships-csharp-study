namespace db_relationships_csharp_study.Services;

using db_relationships_csharp_study.Models;
using db_relationships_csharp_study.DTOs.Character;

public interface ITlouService
{
    Task<List<Character>> CreateCharacter(CreateCharacterDTO data);

    Task<List<Character>> ListCharacters();

    Task<Character?> GetCharacterById(Guid id);
}
