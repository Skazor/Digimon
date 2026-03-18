using Digimon.Models;

namespace Digimon.Data;

// Ansvar: Lese CSV-filen og parse hver rad til et Digimon-objekt
public class DigimonCsvReader
{
    private readonly string _filePath;

    public DigimonCsvReader(string filePath)
    {
        _filePath = filePath;
    }

    // Leser alle linjer og returnerer en liste med Digimon-objekter
    public List<Digimon> ReadAll()
    {
        if (!File.Exists(_filePath))
            throw new FileNotFoundException($"Fant ikke CSV-filen: {_filePath}");

        string[] linjer = File.ReadAllLines(_filePath);

        // Første linje er header, hopp over den med Skip(1)
        return linjer
            .Skip(1)
            .Where(linje => !string.IsNullOrWhiteSpace(linje))
            .Select(linje => ParseLine(linje))
            .ToList();
    }

    // Parser en CSV-linje til et Digimon-objekt
    private static Digimon ParseLine(string linje)
    {
        string[] deler = linje.Split(',');

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