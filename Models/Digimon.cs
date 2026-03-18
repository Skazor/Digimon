namespace DigimonApp.Models;

// Representerer én rad i CSV-filen, en Digimon med alle dens egenskaper
public class Digimon
{
    public int    Number     { get; set; }
    public string Name       { get; set; } = string.Empty;
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