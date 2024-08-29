using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace WpfApp1.Models
{
    public class CinemaRepository
    {
        private readonly string filePath;

        
        public CinemaRepository(string filePath = "Uge33-TheMovies.csv")
        {
            this.filePath = filePath;
        }

        // Metode til at gemme listen af biografer til en fil
        public void SaveToFile(ObservableCollection<Cinema> cinemas)
        {
            using StreamWriter sw = new StreamWriter(filePath);
                       

            foreach (var cinema in cinemas)
            {
                sw.WriteLine($"{cinema.CinemaName};{cinema.City};{cinema.Date};{cinema.Title};{cinema.Genre};{cinema.Duration};{cinema.Instructor};{cinema.Premier}");
            }
        }

        // Metode til at læse listen af biografer fra en fil
        public void ReadFromFile(ObservableCollection<Cinema> cinemas)
        {
            if (!File.Exists(filePath))
            {
                // Opret filen, hvis den ikke eksisterer
                File.Create(filePath);
                return; 
            }

            using StreamReader sr = new StreamReader(filePath);
            string line;

            // Spring header-linjen over
            sr.ReadLine();

            while ((line = sr.ReadLine()) != null)
            {
                var columns = line.Split(';');

                // Tilføj et nyt Cinema-objekt til samlingen
                cinemas.Add(new Cinema
                {
                    CinemaName = columns[0],
                    City = columns[1],
                    Date = columns[2],
                    Title = columns[3],
                    Genre = columns[4],
                    Duration = columns[5],
                    Instructor = columns[6],
                    Premier = columns[7]
                });
            }
        }
    }
}