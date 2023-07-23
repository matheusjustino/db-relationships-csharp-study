namespace db_relationships_csharp_study.Models;

public class Character : Entity
{
    public string Name { get; set; }

    public Backpack Backpack { get; set; }

    public List<Weapon> Weapons { get; set; }

    public List<Faction> Factions { get; set; }
}
