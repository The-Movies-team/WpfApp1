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
        private string filmtitel;
        private int filmvarighed;
        private string filmgenre;
        private string biograf;
        private string by;
        private string premieredato;
        private string filminstruktør;
        private string forestillingstidspunkt;
        

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
            cinemas.Add(new Cinema { Filmtitel = filmtitel, Filmvarighed = filmvarighed, Filmgenre = filmgenre, Biograf = biograf, By = by, Forestillingstidspunkt = forestillingstidspunkt, Filminstruktør = filminstruktør, Premieredato = premieredato  });
            cinemaRepository.savetofile(cinemas);
            

        }

        public string Filmtitel
        {
            get { return filmtitel; }
            set { filmtitel = value; OnPropertyChanged("Filmtitel"); }
        }

        public int Filmvarighed
        {
            get { return filmvarighed; }
            set { filmvarighed = value; OnPropertyChanged("Filmvarighed"); }


        }

        public string Filmgenre
        {
            get { return filmgenre; }
            set { filmgenre = value; OnPropertyChanged("Filmgenre"); }
        }
        public string Biograf
        {
            get { return Biograf; }
            set { biograf = value; OnPropertyChanged("Biograf"); }
        }
        public string By
        {
            get { return by; }
            set { by = value; OnPropertyChanged("By"); }
        }
        public string Premieredato
        {
            get { return premieredato; }
            set { premieredato = value; OnPropertyChanged("Premieredato"); }
        }
        public string Filminstruktør
        {
            get { return filminstruktør; }
            set { filminstruktør = value; OnPropertyChanged("Filminstruktør"); }
        }
        public string Forestillingstidspunkt
        {
            get { return forestillingstidspunkt; }
            set { forestillingstidspunkt = value; OnPropertyChanged("Forestillingstidspunkt"); }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
