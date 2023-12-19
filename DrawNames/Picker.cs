// See https://aka.ms/new-console-template for more information

public class Picker
{
    private readonly Random _random = new Random();
    private readonly IList<Person> _people;

    public Picker(IList<Person> people)
    {
        _people = people;
    }

    public IDictionary<string, string> PickNames()
    {
        var names = _people.Select(p => p.Name).ToList();
        var pickedNames = new Dictionary<string, string>();

        foreach (Person person in _people)
        {
            string name = PickName(person);

            pickedNames.Add(person.Name, name);
        }

        return pickedNames;
    }

    public string PickName(Person person)
    {
        var names = _people.Select(p => p.Name).ToList();
        var name = names[_random.Next(names.Count)];

        while (name == person.Name || name == person.Partner)
        {
            name = names[_random.Next(names.Count)];
        }
     
        names.Remove(name);

        return name;
    }
}
