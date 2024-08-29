using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class CinemaViewModel : INotifyPropertyChanged
    {
        // Private felter til binding
        private string title;
        private string duration;
        private string genre;
        private string cinemaName;
        private string city;
        private string premier;
        private string instructor;
        private string date;

        
        private CinemaRepository cinemaRepository = new CinemaRepository();

        
        public ObservableCollection<Cinema> cinemas { get; set; }

        // Event til at håndtere property ændringer
        public event PropertyChangedEventHandler? PropertyChanged;

        // Kommando til at tilføje en ny biograf
        public ICommand AddCinemaCommand { get; private set; }

        
        public CinemaViewModel()
        {
            cinemas = new ObservableCollection<Cinema>();
            AddCinemaCommand = new RelayCommand(AddCinema);
            cinemaRepository.ReadFromFile(cinemas);
        }

        // Metode til at tilføje en ny biograf
        public void AddCinema(object obj)
        {
            cinemas.Add(new Cinema
            {
                Title = title,
                Duration = duration,
                Genre = genre,
                CinemaName = cinemaName,
                City = city,
                Date = date,
                Instructor = instructor,
                Premier = premier
            });
            cinemaRepository.SaveToFile(cinemas);
        }

        // Properties med OnPropertyChanged kald
        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        public string Duration
        {
            get { return duration; }
            set { duration = value; OnPropertyChanged(); }
        }

        public string Genre
        {
            get { return genre; }
            set { genre = value; OnPropertyChanged(); }
        }

        public string CinemaName
        {
            get { return cinemaName; }
            set { cinemaName = value; OnPropertyChanged(); }
        }

        public string City
        {
            get { return city; }
            set { city = value; OnPropertyChanged(); }
        }

        public string Premier
        {
            get { return premier; }
            set { premier = value; OnPropertyChanged(); }
        }

        public string Instructor
        {
            get { return instructor; }
            set { instructor = value; OnPropertyChanged(); }
        }

        public string Date
        {
            get { return date; }
            set { date = value; OnPropertyChanged(); }
        }

        // Metode til at håndtere property ændringer
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}