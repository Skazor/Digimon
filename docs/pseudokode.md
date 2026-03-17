# Pseudokode – Digimon MVC

## Programflyt (overordnet)

START
  Les inn CSV-fil fra Data/
  Parse hver linje til et Digimon-objekt
  Lagre alle objekter i en liste
  
  Vis meny til bruker
  Ta imot brukerens valg
  Kjør tilhørende LINQ-spørring
  Vis resultatet
  Gjenta til bruker velger å avslutte
SLUTT

## Ansvarsfordeling (MVC)

MODEL (Models/Digimon.cs)
  - Representerer en rad fra CSV-filen
  - Egenskaper: Number, Name, Stage, Type, Attribute,
                Memory, EquipSlots, HP, SP, Atk, Def, Int, Spd

DATA / READER (Data/DigimonCsvReader.cs)
  - Leser CSV-filen med File.ReadAllLines()
  - Splitter hver linje på komma med .Split(',')
  - Returnerer en List<Digimon>

CONTROLLER (Controllers/DigimonController.cs)
  - Tar imot List<Digimon> fra Reader
  - Utfører LINQ-spørringer mot listen:
      Select()  --> henter ut en property fra alle objekter
      Where()   --> filtrerer listen på et kriterium
      OrderBy() --> sorterer liten
      GroupBy() --> grupperer listen

VIEW (Views/DigimonView.cs)
  - Skriver ut meny og resultater til konsollen
  - Ingen logikk, kun presentasjon

PROGRAM (Program.cs)
  - Knytter alt sammen
  - Starter Reader --> Controller --> løkke med View