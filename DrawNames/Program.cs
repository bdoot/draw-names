// See https://aka.ms/new-console-template for more information

using System.Text.Json;

string input = await Console.In.ReadToEndAsync();

Console.WriteLine($"Input: {input}");

JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

IList<Person>? people = JsonSerializer.Deserialize<IList<Person>>(input, options);

if (people is null)
{
    Console.WriteLine("Invalid json, expected { \"Name\": \"<name>\", \"Partner\": \"<partner>\" }");
    return;
}

var picker = new Picker(people);

IDictionary<string, string> pickedNames = picker.PickNames();

foreach (var (name, partner) in pickedNames)
{
    Console.WriteLine($"{name} -> {partner}");
}