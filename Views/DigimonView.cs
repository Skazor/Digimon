using DigimonApp.Models;

namespace DigimonApp.Views;

// Ansvar: All presntasjon til konsollen, ingen logikk, kun utskrift
public static class DigimonView
{
    public static void PrintMenu()
    {
        Console.WriteLine("\n=== DIGIMON MENY ===");
        Console.WriteLine("[1] Vis alle navn");
        Console.WriteLine("[2] Vis kun Mega-Digimon");
        Console.WriteLine("[3] Vis Digimon med høyt angrep (>= 150)");
        Console.WriteLine("[4] Vis topp 10 raskeste");
        Console.WriteLine("[5] Vis antall per Type");
        Console.WriteLine("[0] Avslutt");
        Console.Write("\nVelg: ");
    }

    public static void ShowNames(IEnumerable<string> navn)
    {
        Console.WriteLine("\n--- Alle Digimon-navn ---");
        int i = 1;
        foreach (var n in navn)
            Console.WriteLine($"  {i++}. {n}");
    }

    public static void ShowDigimonList(IEnumerable<Digimon> liste, string tittel)
    {
        Console.WriteLine($"\n--- {tittel} ---");
        foreach (var d in liste)
            Console.WriteLine($"  #{d.Number} {d.Name} | Stage: {d.Stage} | ATK: {d.Atk} | SPD: {d.Spd}");
        Console.WriteLine($"  Totalt: {liste.Count()} Digimon");
    }

    public static void ShowCountByType(IEnumerable<(string Type, int Antall)> grupper)
    {
        Console.WriteLine("\n--- Antall per Type ---");
        foreach (var (type, antall) in grupper)
            Console.WriteLine($"  {type}: {antall}");
    }

    public static void PauseForUser()
    {
        Console.WriteLine("\n[Trykk Enter for å fortsette...]");
        Console.ReadLine();
    }
}