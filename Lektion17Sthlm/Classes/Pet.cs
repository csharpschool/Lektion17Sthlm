namespace Lektion17Sthlm.Classes;

public enum Species
{
    Cat,
    Dog,
    Rabbit,
    Donkey
}

public class Pet : IComparable<Pet>
{
    public int Id { get; set; }
    public Species Species { get; set; }
    public string Name { get; set; }

    public Pet(int id, Species species, string name) =>
        (Id, Species, Name) = (id, species, name);

    public int CompareTo(Pet? other)
    {
        if(other == null) return 1;
        if(other == this) return 0;
        if (Species > other.Species) return 1;
        if (Species < other.Species) return -1;
        return 0;
    }
}
