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

        public CinemaRepository(string filePath = "Cinema.csv")
        {
            this.filePath = filePath;
        }
        public void savetofile(ObservableCollection<Cinema> cinemas)
        {

            using StreamWriter sw = new StreamWriter("Cinema.csv");

            sw.WriteLine("Title;Duration;Genre;CinemaName;City;Premier;Instructor;Date");

            foreach (var cinema in cinemas)
            {

                sw.WriteLine($"{cinema.Title};{cinema.Duration};{cinema.Genre};{cinema.CinemaName};{cinema.City};{cinema.Premier};{cinema.Instructor};{cinema.Date}");
            }


        }

        public void ReadFromFile(ObservableCollection<Cinema> cinemas)
        {
            if (!File.Exists("Cinema.csv"))
            {
                File.Create("Cinema.csv");
            }

            using StreamReader sr = new StreamReader("Cinema.csv");

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                var columns = line.Split(';');

                if (int.TryParse(columns[1], out int duration))
                {
                    cinemas.Add(new Cinema
                    {
                        Title = columns[0],
                        Duration = duration,
                        Genre = columns[2],
                        CinemaName = columns[3],
                        City = columns[4],
                        Premier = columns[5],
                        Instructor = columns[6],
                        Date = columns[7]
                    });
                }


            }
        }
    }
}
