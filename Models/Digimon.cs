namespace DigimonApp.Models;

// Model laget i MVC, representerer en rad i CSV-filen
// En instans av denne klassen = en Digimon
public class Digimon
{
    // { get; set; } property, privat felt med get og set metoder
    // int = heltall, string = tekst
    public int    Number     { get; set; }
    public string Name       { get; set; } = string.Empty; // = string.Empty unngår null advarsel
    public string Stage      { get; set; } = string.Empty;
    public string Type       { get; set; } = string.Empty;
    public string Attribute  { get; set; } = string.Empty;
    public int    Memory     { get; set; }
    public int    EquipSlots { get; set; }
    public int    HP         { get; set; }
    public int    SP         { get; set; }
    public int    Atk        { get; set; }
    public int    Def        { get; set; }
    public int    Int        { get; set; }
    public int    Spd        { get; set; }
}