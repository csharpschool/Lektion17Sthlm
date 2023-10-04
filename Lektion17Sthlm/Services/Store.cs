using Lektion17Sthlm.Classes;

namespace Lektion17Sthlm.Services;

public class Store
{
    public List<Pet>? Pets { get; init; } = new();

    public Store()
    {
        Pets.Add(new Pet(1, Species.Rabbit, "Fluffy"));
        Pets.Add(new Pet(2, Species.Cat, "Spotty"));
        Pets.Add(new Pet(3, Species.Dog, "Max"));
        Pets.Add(new Pet(4, Species.Cat, "Lynx"));
        Pets.Add(new Pet(5, Species.Dog, "Rex"));
        Pets.Add(new Pet(61, Species.Rabbit, "Fluffy 2"));
        Pets.Add(new Pet(72, Species.Cat, "Spotty 2"));
        Pets.Add(new Pet(83, Species.Dog, "Max 2"));
        Pets.Add(new Pet(94, Species.Cat, "Lynx 2"));
        Pets.Add(new Pet(105, Species.Dog, "Rex 2"));
    }

    public List<Pet> Get(Func<Pet, bool> predicate)
    {  
        return Pets is null ? new() : Pets.Where(predicate).ToList();
    }

    public List<T> Get<T>(List<T> data, Func<T, bool> predicate)
    {
        return data.Where(predicate).ToList();
    }

    public Pet? First(Func<Pet, bool> predicate)
    {
        return Pets.FirstOrDefault(predicate);
        try
        {
            return Pets.First(predicate);
        }
        catch
        {
            return null;
        }
    }

    public Pet? Single(Func<Pet, bool> predicate)
    {
        return Pets.SingleOrDefault(predicate);
        try
        {
            return Pets.First(predicate);
        }
        catch
        {
            return null;
        }
    }

    public Pet? Single(string name)
    {
        return Pets.SingleOrDefault(p => p.Name.ToLower().StartsWith(name.ToLower()));
    }

    /*public List<string> Select(Func<Pet, bool> predicate)
    {
        return Pets.Where(predicate).Select(p => $"{p.Name} {p.Species}").ToList();
    }*/
    public List<Mamal> Select(Func<Pet, bool> predicate)
    {
        return Pets.Where(predicate).OrderBy(p => p.Name).Select(p => new Mamal(p.Id, p.Name)).ToList();
    }

    /*public void Sort(Func<Pet, bool> predicate)
    {
        Pets?.Where(predicate).ToList().Sort();
    }*/

    public List<Pet>? Sort(Func<Pet, bool> predicate)
    {
        var selection = Pets?.Where(predicate).ToList();
        selection?.Sort();
        return selection;
    }

    public List<Pet>? PetPicker(Func<Pet, bool> predicate, int page = 0, int take = 3)
    {
        return Pets?.Where(predicate).Skip(page * take).Take(take).ToList();
    }
}
