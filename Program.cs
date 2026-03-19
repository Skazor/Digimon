using DigimonApp.Data;

string csvPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "DigiDB_digimonlist.csv");

var reader = new DigimonCsvReader(csvPath);
var digimons = reader.ReadAll();

Console.WriteLine($"Antall Digimon lastet inn: {digimons.Count}");
Console.WriteLine($"Første Digimon: {digimons[0].Name}");
Console.WriteLine($"Siste Digimon:  {digimons[^1].Name}");