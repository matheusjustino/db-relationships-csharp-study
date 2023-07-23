namespace db_relationships_csharp_study.Models;

using System.Text.Json.Serialization;

public class Backpack : Entity
{
    public string Description { get; set; }

    public Guid CharacterId { get; set; }

    [JsonIgnore]
    public Character Character { get; set; }
}
