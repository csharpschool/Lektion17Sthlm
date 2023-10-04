namespace Lektion17Sthlm.Classes;

public class Mamal
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Mamal(int id, string name) =>
        (Id, Name) = (id, name);

}
