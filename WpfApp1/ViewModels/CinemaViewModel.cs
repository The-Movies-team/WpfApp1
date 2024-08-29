using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class CinemaViewModel
    {
        private string title;
        private int duration;
        private string genre;
        private string cinemaName;
        private string city;
        private string premier;
        private string instructor;
        private string date;
        

        private CinemaRepository cinemaRepository = new CinemaRepository();

        public ObservableCollection<Cinema> cinemas { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand AddCinemaCommand { get; private set; }

        public CinemaViewModel()
        {
            cinemas = new();
            AddCinemaCommand = new RelayCommand(AddCinema);
            cinemaRepository.ReadFromFile(cinemas);
            
        }

        private void AddCinema(object obj)
        {
            cinemas.Add(new Cinema { Title = title, Duration = duration, Genre = genre, CinemaName = cinemaName, City = city, Date = date, Instructor = instructor, Premier = premier  });
            cinemaRepository.savetofile(cinemas);
            

        }

        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged("Title"); }
        }

        public int Duration
        {
            get { return duration; }
            set { duration = value; OnPropertyChanged("Duration"); }


        }

        public string Genre
        {
            get { return genre; }
            set { genre = value; OnPropertyChanged("Genre"); }
        }
        public string CinemaName
        {
            get { return cinemaName; }
            set { cinemaName = value; OnPropertyChanged("CinemaName"); }
        }
        public string City
        {
            get { return city; }
            set { city = value; OnPropertyChanged("City"); }
        }
        public string Premier
        {
            get { return premier; }
            set { premier = value; OnPropertyChanged("Premier"); }
        }
        public string Instructor
        {
            get { return instructor; }
            set { instructor = value; OnPropertyChanged("Instructor"); }
        }
        public string Date
        {
            get { return date; }
            set { date = value; OnPropertyChanged("Date"); }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
