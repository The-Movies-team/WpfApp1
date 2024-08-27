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
        public void savetofile(ObservableCollection<Movie> movies)
        {
            
            using StreamWriter sw = new StreamWriter("movies.csv");

            sw.WriteLine("Title;Duration;Genre");

            foreach (var movie in movies)
            {
                
                sw.WriteLine($"{movie.Title};{movie.Duration};{movie.Genre}");
            }


        }

        public void ReadFromFile(ObservableCollection<Movie> movies)
        {
            if (!File.Exists("movies.csv"))
            {
                File.Create("movies.csv");
            }

            using StreamReader sr = new StreamReader("movies.csv");

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                var columns = line.Split(';');

                if (int.TryParse(columns[1], out int duration))
                {
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
