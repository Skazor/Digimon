using DigimonApp.Models;

namespace DigimonApp.Data;

// Ansvar: Lese CSV-filen og parse hver rad til et Digimon-objekt
// Data-laget, eneste klasse som vet hvordan CSV-filen er bygget opp
public class DigimonCsvReader
{
    // readonly betyr at _filePath ikke kan endres etter at objektet er opprettet
    // _ foran navnet er en konvensjon for private felt
    private readonly string _filePath;

    // Konstruktør, kjøres når man skriver new DigimonCsvReader(csvPath)
    public DigimonCsvReader(string filePath)
    {
        _filePath = filePath;
    }

    // Leser alle linjer og returnerer en liste med Digimon-objekter
    public List<Digimon> ReadAll()
    {
        // Sjekker om filen finnes før den prøver å lese den
        if (!File.Exists(_filePath))
            throw new FileNotFoundException($"Fant ikke CSV-filen: {_filePath}");

        // File.ReadAllLines() leser hele filen og returnerer én string per linje
        string[] linjer = File.ReadAllLines(_filePath);

        // LINQ-pipeline:
        // Skip(1), hopper over headerlinjen (kolonnenavn)
        // Where(...), fjerner tomme linjer
        // Select(linje => ParseLine), konverterer hver linje til et Digimon-objekt
        // ToList(), materialiserer resultatet til en List<Digimon>
        return linjer
            .Skip(1)
            .Where(linje => !string.IsNullOrWhiteSpace(linje))
            .Select(linje => ParseLine(linje))
            .ToList();
    }

    // Privat metode, kun tilgjengelig inne i denne klassen
    // static betyr at den ikke trenger tilgang til feltene i klassen
    private static Digimon ParseLine(string linje)
    {
        // Split(',') deler linjen på komma og returnerer en string-array
        // "1,Kuramon,Baby" --> ["1", "Kuramon", "Baby"]
        string[] deler = linje.Split(',');

        // int.Parse() konverterer string til int, f.eks "590" --> 590
        // Trim() fjerner mellomrom rundt verdien
        return new Digimon
        {
            Number     = int.Parse(deler[0].Trim()),
            Name       = deler[1].Trim(),
            Stage      = deler[2].Trim(),
            Type       = deler[3].Trim(),
            Attribute  = deler[4].Trim(),
            Memory     = int.Parse(deler[5].Trim()),
            EquipSlots = int.Parse(deler[6].Trim()),
            HP         = int.Parse(deler[7].Trim()),
            SP         = int.Parse(deler[8].Trim()),
            Atk        = int.Parse(deler[9].Trim()),
            Def        = int.Parse(deler[10].Trim()),
            Int        = int.Parse(deler[11].Trim()),
            Spd        = int.Parse(deler[12].Trim()),
        };
    }
}