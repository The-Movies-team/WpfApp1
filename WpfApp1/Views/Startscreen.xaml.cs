using System.Windows;
using WpfApp1.Views;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Startscreen.xaml
    /// </summary>
    public partial class Startscreen : Window
    {
        public Startscreen()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddMovieWindow addMovieWindow = new AddMovieWindow();
            addMovieWindow.Show();
            this.Close();
        }

        private void btncinemaprogram_Click(object sender, RoutedEventArgs e)
        {
            CinemaWindow cinemaWindow = new CinemaWindow();
            cinemaWindow.Show();
            this.Close();
        }
    }
}
