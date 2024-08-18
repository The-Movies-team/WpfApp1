using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    class MovieRepository
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }

        //ObservableCollection<List> Movies { get; set; }

        public void savetofile()
        {
            using StreamWriter sw = new StreamWriter("movies.csv");

            //foreach (var movie in Movies)
            //{
                //List<string> columns = line.Split(',').ToList();
                //sw.WriteLine($"{movie.Title},{movie.Duration},{movie.Genre}");
            //}
            


        }

        public void ReadFromFile()
        {
            using StreamReader sr = new StreamReader("movies.csv");

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                List<string> columns = line.Split(',').ToList();
                //Movies.Add(new Movie { Title = columns[0], Duration = columns[1], Genre = columns[2] });
            }
        }





        public void AddMovie(string title, string duration, string genre)
        {
            //Movies.Add(new Movie { Title = title, Duration = duration, Genre = genre });
        }

    }
}
