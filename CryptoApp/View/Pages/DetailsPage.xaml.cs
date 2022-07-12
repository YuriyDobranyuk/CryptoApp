using System.Windows.Controls;
using CryptoApp.ViewModel;

namespace CryptoApp.View.Pages
{
    /// <summary>
    /// Interaction logic for DetailsPage.xaml
    /// </summary>
    public partial class DetailsPage : Page
    {
        public DetailsPage()
        {
            InitializeComponent();

            DataContext = new DetailsViewModel();
        }
    }
}
