using DigimonApp.Models;

namespace DigimonApp.Views;

// Ansvar: All presntasjon til konsollen, ingen logikk, kun utskrift
// View-laget i MVC, all presentasjon samlet på ett sted
// static klasse, trenger å opprette et objekt, kaller direkte på klassen
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

    // IEnumerable<string> tar imot en sekvens av strings
    // Fungerer med List, array og LINQ-resultater
    public static void ShowNames(IEnumerable<string> navn)
    {
        Console.WriteLine("\n--- Alle Digimon-navn ---");
        int i = 1;
        // n er en string (ett navn) per iterasjon
        foreach (var n in navn)
            Console.WriteLine($"  {i++}. {n}"); // i++ øker i med 1 etter hver utskrift
    }

    // Gjenbrukbar metode, brukes for flere menyvalg, tittel styrer overskriften
    public static void ShowDigimonList(IEnumerable<Digimon> liste, string tittel)
    {
        Console.WriteLine($"\n--- {tittel} ---");
        foreach (var d in liste)
        // Interpolert string med $, setter inn verdier direkte i teksten
            Console.WriteLine($"  #{d.Number} {d.Name} | Stage: {d.Stage} | ATK: {d.Atk} | SPD: {d.Spd}");
        Console.WriteLine($"  Totalt: {liste.Count()} Digimon");
    }

    // Tar imot en liste med tuppel, (string Type, int Antall)
    // Destrukturering: (type, antall) pakker ut tuppel direkte i foreach
    public static void ShowCountByType(IEnumerable<(string Type, int Antall)> grupper)
    {
        Console.WriteLine("\n--- Antall per Type ---");
        foreach (var (type, antall) in grupper)
            Console.WriteLine($"  {type}: {antall}");
    }

    // Stopper programmet til bruker tryker Enter
    // Gir tid til å lese resultatet før menyen vises igjen
    public static void PauseForUser()
    {
        Console.WriteLine("\n[Trykk Enter for å fortsette...]");
        Console.ReadLine();
    }
}