using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using OfficeOpenXml;

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

            sw.WriteLine("Title;Duration;Filmgenre;CinemaName;By;Premieredato;Filminstruktør;Forestillingsdato");

            foreach (var cinema in cinemas)
            {

                sw.WriteLine($"{cinema.Filmtitel};{cinema.Filmvarighed};{cinema.Filmgenre};{cinema.Biograf};{cinema.By};{cinema.Premieredato};{cinema.Filminstruktør};{cinema.Forestillingstidspunkt}");
            }


        }

        public ObservableCollection<Cinema> ReadFromFile(ObservableCollection<Cinema> cinemas)
        {
            // Path to your Excel file
            string filePath = "C:\\Users\\Ricke\\Downloads\\Uge33-TheMovies.xlsx";

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified Excel file does not exist.");
            }

            //var cinemas = new ObservableCollection<Cinema>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;
                var colCount = worksheet.Dimension.Columns;

                // Start reading from row 2 to skip the header
                for (int row = 2; row <= rowCount; row++)
                {
                    var cinema = new Cinema();
                    for (int col = 1; col <= colCount; col++)
                    {
                        var cellValue = worksheet.Cells[row, col].Text;

                        // Map cellValue to the appropriate property of the Cinema object
                        // Example: if column 1 is "Name", column 2 is "Location", etc.
                        if (col == 1) cinema.Biograf = cellValue;
                        else if (col == 2) cinema.By = cellValue;
                        // Add other properties as necessary
                    }
                    cinemas.Add(cinema);
                }
            }

            return cinemas;
        }
        //using StreamReader sr = new StreamReader("Cinema.csv");

        //string line;
        //while ((line = sr.ReadLine()) != null)
        //{
        //    var columns = line.Split(';');

        //    if (int.TryParse(columns[1], out int duration))
        //    {
        //        cinemas.Add(new Cinema
        //        {
        //            Title = columns[0],
        //            Duration = duration,
        //            Genre = columns[2],
        //            CinemaName = columns[3],
        //            City = columns[4],
        //            Premier = columns[5],
        //            Instructor = columns[6],
        //            Date = columns[7]
        //        });
        //    }


        //}
    }
}

