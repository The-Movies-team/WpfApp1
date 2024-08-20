using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class MovieViewModel : INotifyPropertyChanged
    {

        //måske slette 
        //public Movie Movie { get; set; } kan leges med
        private string title;
        private int duration;
        private string genre;
        private MovieRepository movieRepository = new MovieRepository();

        public ObservableCollection<Movie> Movies { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand AddMovieCommand { get; private set; }

        public MovieViewModel()
        {
            Movies = new();
            AddMovieCommand = new RelayCommand(AddMovie);
            movieRepository.ReadFromFile(Movies);
            //læscsv hver gang den starter op, sæt observable til at være lig med listen
        }

        private void AddMovie(object obj)
        {
            Movies.Add(new Movie { Title = title, Duration = duration, Genre = genre });
            movieRepository.savetofile(Movies);
            
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
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
