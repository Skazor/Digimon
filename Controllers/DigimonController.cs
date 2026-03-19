using DigimonApp.Models;

namespace DigimonApp.Controllers;

// Ansvar: Ta imot brukervalg og kjøre LINQ-spørringer mot datasettet
// Vet om data, men ingenting om hvordan det vises
public class DigimonController
{
    // Listen med alle Digimon objekter, lastet inn en gang og gjenbrukt
    private readonly List<Digimon> _digimons;

    // Konstruktør, tar imot listen fra Program.cs
    public DigimonController(List<Digimon> digimons)
    {
        _digimons = digimons;
    }

    // SELECT, henter navn fra alle objekter
    // henter kun en property fra hvert objekt
    // d => d.Name er en lambda – d representerer en Digimon i listen
    public IEnumerable<string> GetAllNames() =>
        _digimons.Select(d => d.Name);

    // WHERE, filtrerer på Stage
    // WHERE filtrering, returnerer kun objekter som oppfyller kriteriet
    // Returnerer IEnumerable<Digimon> fordi man trenger hele objektet, ikke bare en property
    public IEnumerable<Digimon> GetMegas() =>
        _digimons.Where(d => d.Stage == "Mega");

    // WHERE, filtrerer på angrep
    // WHERE med parameter, grensen kan bestemmes av kalleren
    public IEnumerable<Digimon> GetHighAttack(int grense) =>
        _digimons.Where(d => d.Atk >= grense);

    // ORDER BY, topp N raskeste
    // ORDER BY + TAKE, sorterer synkende og begrenser antall resultater
    // Take(topN) stopper etter topN elementer
    public IEnumerable<Digimon> GetFastest(int topN) =>
        _digimons.OrderByDescending(d => d.Spd).Take(topN);

    // GROUP BY, antall per Type
    // GROUP BY, grupperer objekter på en felles verdi (Type)
    // g.Key = grupperingsverdien (f.eks "Virus")
    // g.Count() = antall Digimon i den gruppen
    // Returnerer en liste, (Type, Antall) er en anonym datastruktur
    public IEnumerable<(string Type, int Antall)> GetCountByType() =>
        _digimons
            .GroupBy(d => d.Type)
            .Select(g => (Type: g.Key, Antall: g.Count()))
            .OrderByDescending(g => g.Antall);
}