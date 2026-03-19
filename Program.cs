using DigimonApp.Controllers;
using DigimonApp.Data;
using DigimonApp.Views;

// Les inn CSV og opprett controller
string csvPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "DigiDB_digimonlist.csv");

var reader     = new DigimonCsvReader(csvPath);
var digimons   = reader.ReadAll();
var controller = new DigimonController(digimons);

// Hoved-løkke
bool running = true;
while (running)
{
    DigimonView.PrintMenu();
    string? valg = Console.ReadLine()?.Trim();

    switch (valg)
    {
        case "1":
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
            running = false;
            Console.WriteLine("\nVelkommen tilbake!");
            break;

        default:
            Console.WriteLine("\nUgyldig valg, prøv igjen.");
            break;
    }

    if (running)
        DigimonView.PauseForUser();
}