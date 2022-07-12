using System.Windows.Controls;
using CryptoApp.Services;
using CryptoApp.ViewModel;

namespace CryptoApp.View.Pages
{
    /// <summary>
    /// Interaction logic for CryptocurrenciesPage.xaml
    /// </summary>
    public partial class CryptocurrenciesPage : Page
    {
        public CryptocurrenciesPage()
        {
            InitializeComponent();

            DataContext = new CryptocurrenciesViewModel(new CoinCapService());
        }
    }
}
