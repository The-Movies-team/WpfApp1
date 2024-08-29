using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModels;

namespace WpfApp1.Models
{
    public class MovieRepository
    {
        private readonly string filePath;

        
        public MovieRepository(string filePath = "movies.csv")
        {
            this.filePath = filePath;
        }

        // Metode til at gemme listen af film til en fil
        public void SaveToFile(ObservableCollection<Movie> movies)
        {
            using StreamWriter sw = new StreamWriter(filePath);

            // Skriv header-linjen
            sw.WriteLine("Title;Duration;Genre");

            foreach (var movie in movies)
            {
                sw.WriteLine($"{movie.Title};{movie.Duration};{movie.Genre}");
            }
        }

        // Metode til at læse listen af film fra en fil
        public void ReadFromFile(ObservableCollection<Movie> movies)
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

                if (int.TryParse(columns[1], out int duration))
                {
                    // Tilføj et nyt Movie-objekt til samlingen
                    movies.Add(new Movie
                    {
                        Title = columns[0],
                        Duration = duration,
                        Genre = columns[2]
                    });
                }
            }
        }
    }
}