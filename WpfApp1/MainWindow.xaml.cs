using WpfApp1.ViewModel;
using System.Windows;


namespace WpfApp1
{
    public partial class MainWindow : Window

    {
        public MainWindow()

        {
            InitializeComponent();
            MainWindowViewModel vm = new MainWindowViewModel();
            DataContext = vm;
        }
    }
    ]

