using System.Windows.Controls;
using CryptoApp.Model;
using CryptoApp.Services;
using CryptoApp.ViewModel;

namespace CryptoApp.View.Pages
{
    /// <summary>
    /// Interaction logic for DetailsPage.xaml
    /// </summary>
    public partial class DetailsPage : Page
    {
        public DetailsPage(CryptocurrencyModel elem)
        {
            InitializeComponent();

            DataContext = new DetailsViewModel(elem, new CoinCapService());
        }
    }
}
