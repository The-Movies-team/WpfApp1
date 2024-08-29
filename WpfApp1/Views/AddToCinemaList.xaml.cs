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
        CinemaRepository cinemaRepository = new CinemaRepository();
        
        

        public AddToCinemaList(CinemaViewModel viewModel)
        {
            InitializeComponent();
            viewModel = new CinemaViewModel();
            this.viewModel = viewModel;
            this.DataContext = viewModel;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
            if (viewModel == null)
            {
                MessageBox.Show("ViewModel is not initialized.");
                return;
            }
            viewModel.Filmtitel = txtTitle.Text;
            viewModel.Filmvarighed = Convert.ToInt32(txtDuration.Text);
            viewModel.Filmgenre = txtGenre.Text;
            viewModel.Biograf = txtCinema.Text;
            viewModel.By = txtCity.Text;
            viewModel.Forestillingstidspunkt = txtDate.Text;
            viewModel.Filminstruktør = txtinstructor.Text;
            viewModel.Premieredato = txtPremier.Text;


            this.Close();
        }
    }
}
