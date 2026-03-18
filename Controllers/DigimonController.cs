using DigimonApp.Models;

namespace DigimonApp.Controllers;

// Ansvar: Ta imot brukervalg og kjøre LINQ-spørringer mot datasettet
public class DigimonController
{
    private readonly List<Digimon> _digimons;

    public DigimonController(List<Digimon> digimons)
    {
        _digimons = digimons;
    }

    // SELECT, henter navn fra alle objekter
    public IEnumerable<string> GetAllNames() =>
        _digimons.Select(d => d.Name);

    // WHERE, filtrerer på Stage
    public IEnumerable<Digimon> GetMegas() =>
        _digimons.Where(d => d.Stage == "Mega");

    // WHERE, filtrerer på angrep
    public IEnumerable<Digimon> GetHighAttack(int grense) =>
        _digimons.Where(d => d.Atk >= grense);

    // ORDER BY, topp N raskeste
    public IEnumerable<Digimon> GetFastest(int topN) =>
        _digimons.OrderByDescending(d => d.Spd).Take(topN);

    // GROUP BY, antall per Type
    public IEnumerable<(string Type, int Antall)> GetCountByType() =>
        _digimons
            .GroupBy(d => d.Type)
            .Select(g => (Type: g.Key, Antall: g.Count()))
            .OrderByDescending(g => g.Antall);
}