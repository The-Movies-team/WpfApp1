using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Models;
using WpfApp1.ViewModels;

namespace WpfApp1.Views
{
    public partial class AddToCinemaList : Window
    {
        private CinemaViewModel viewModel;
        private CinemaRepository cinemaRepository = new CinemaRepository();

        
        public AddToCinemaList(CinemaViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.DataContext = viewModel;
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Title = txtTitle.Text;
            viewModel.Duration = AddThirtyMinutes(txtDuration.Text);
            viewModel.Genre = txtGenre.Text;
            viewModel.CinemaName = txtCinema.Text;
            viewModel.City = txtCity.Text;
            viewModel.Date = txtDate.Text;
            viewModel.Instructor = txtinstructor.Text;
            viewModel.Premier = txtPremier.Text;

            this.Close();
        }

        // Metode til at tilføje 30 minutter til varigheden
        private string AddThirtyMinutes(string duration)
        {
            if (TimeSpan.TryParse(duration, out TimeSpan timeSpan))
            {
                timeSpan = timeSpan.Add(TimeSpan.FromMinutes(30));
                return timeSpan.ToString(@"hh\:mm");
            }
            return duration; // Returner den oprindelige varighed, hvis parsing fejler
        }
    }
}