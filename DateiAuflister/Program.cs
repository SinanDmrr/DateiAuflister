using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Frag den Benutzer nach dem Zielpfad
        Console.WriteLine("Bitte geben Sie den Zielpfad an:");
        string zielpfad = Console.ReadLine();

        // Überprüfe, ob der Pfad existiert
        if (Directory.Exists(zielpfad))
        {
            // Hol dir alle PDF-Dateinamen im Zielpfad (ohne Pfad)
            string[] pdfDateien = Directory.GetFiles(zielpfad, "*.pdf").Select(Path.GetFileName).ToArray();

            // Erstelle den Dateipfad für die Editor-Datei im Zielpfad
            string editorDateiPfad = Path.Combine(zielpfad, "Auflistung aller gesendeten Bewerbungen.txt");

            // Schreibe die Anzahl der beworbenen Stellen in die Editor-Datei
            File.WriteAllText(editorDateiPfad, $"Es wurde sich an {pdfDateien.Length} Stellen beworben. Nun folgen die Stellen:{Environment.NewLine}");

            // Schreibe die PDF-Dateinamen in die Editor-Datei (unter der vorherigen Meldung)
            File.AppendAllLines(editorDateiPfad, pdfDateien);

            Console.WriteLine("Editor-Datei wurde erfolgreich erstellt.");
        }
        else
        {
            Console.WriteLine("Der angegebene Pfad existiert nicht.");
        }

        Console.ReadLine(); // Damit die Konsole offen bleibt, bis der Benutzer Enter drückt
    }
}
