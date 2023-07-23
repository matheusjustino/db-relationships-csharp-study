namespace db_relationships_csharp_study.DTOs.Character;

using db_relationships_csharp_study.DTOs.Backpack;
using db_relationships_csharp_study.DTOs.Weapon;
using db_relationships_csharp_study.DTOs.Faction;


public record struct CreateCharacterDTO(
    string Name,
    CreateBackpackDTO Backpack,
    List<CreateWeaponDTO> Weapons,
    List<CreateFactionDTO> Factions);
