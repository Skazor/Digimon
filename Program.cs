using DigimonApp.Controllers;
using DigimonApp.Data;
using DigimonApp.Views;

// Path.Combine setter sammen mappenavn og filnavn på en måte som fungerer på alle operativsystemer
// Directory.GetCurrentDirectory() returnerer mappen programmet kjøres fra
string csvPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "DigiDB_digimonlist.csv");

// Reader har ansvar for å lese og parse CSV-filen til C# objekter
var reader     = new DigimonCsvReader(csvPath);
// ReadAll() returnerer en List<Digimon> med alle radene fra CSV-filen
var digimons   = reader.ReadAll();
// Controlleren tar imot listen, gjør det mulig å kjøre LINQ-spøringer mot den
var controller = new DigimonController(digimons);

// Hoved-løkke, kjører til bruker velger 0
// bool running styrer om løkken skal fortsette
bool running = true;
while (running)
{
    // View har ansvar for all utskrift, sender aldri data direkte til Console her
    DigimonView.PrintMenu();
    
    // string? betyr at valg kan være null, f.eks hvis bruker bare trykker Enter
    // Trim() fjerner mellomrom før og etter teksten
    string? valg = Console.ReadLine()?.Trim();

    // switch sammenligner valg mot hver case og kjører riktig blokk
    switch (valg)
    {
        case "1":
            // Controller henter data, View viser den, de snakker ikke direkte med hverandre
            DigimonView.ShowNames(controller.GetAllNames());
            break;

        case "2":
            DigimonView.ShowDigimonList(controller.GetMegas(), "Mega-Digimon");
            break;

        case "3":
            DigimonView.ShowDigimonList(controller.GetHighAttack(150), "Digimon med Angrep >= 150");
            break;

        case "4":
            DigimonView.ShowDigimonList(controller.GetFastest(10), "Topp 10 raskeste");
            break;

        case "5":
            DigimonView.ShowCountByType(controller.GetCountByType());
            break;

        case "0":
            // Setter running til false slik at løkken avsluttes etter denne runden
            running = false;
            Console.WriteLine("\nVelkommen tilbake!");
            break;

        default:
            Console.WriteLine("\nUgyldig valg, prøv igjen.");
            break;
    }

    // Pauser kun hvis programmet fortsatt kjører, ungår unødvendig pause ved avslutning
    if (running)
        DigimonView.PauseForUser();
}