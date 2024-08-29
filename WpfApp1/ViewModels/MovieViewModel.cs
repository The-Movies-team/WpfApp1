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
    public class MovieViewModel : INotifyPropertyChanged
    {
        // Private felter til binding
        private string title;
        private int duration;
        private string genre;

        
        private MovieRepository movieRepository = new MovieRepository();

        
        public ObservableCollection<Movie> movies { get; set; }

        // Event til at håndtere property ændringer
        public event PropertyChangedEventHandler? PropertyChanged;

        // Kommando til at tilføje en ny film
        public ICommand AddMovieCommand { get; private set; }

        
        public MovieViewModel()
        {
            movies = new ObservableCollection<Movie>();
            AddMovieCommand = new RelayCommand(AddMovie);
            movieRepository.ReadFromFile(movies);
        }

        // Metode til at tilføje en ny film
        private void AddMovie(object obj)
        {
            movies.Add(new Movie { Title = title, Duration = duration, Genre = genre });
            movieRepository.SaveToFile(movies);
        }

        // Properties med OnPropertyChanged kald
        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        public int Duration
        {
            get { return duration; }
            set { duration = value; OnPropertyChanged(); }
        }

        public string Genre
        {
            get { return genre; }
            set { genre = value; OnPropertyChanged(); }
        }

        // Metode til at håndtere property ændringer
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}