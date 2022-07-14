using CryptoApp.Services;
using CryptoApp.View.Pages;
using CryptoApp.ViewModel;

namespace CryptoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Content = new CryptocurrenciesPage();
        }
    }
}
