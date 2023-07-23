namespace db_relationships_csharp_study.Models;

using System.Text.Json.Serialization;

public class Faction : Entity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    [JsonIgnore]
    public List<Character> Characters { get; set; }
}
