using CryptoApp.Model;
using CryptoApp.ViewModel.Base;
using CryptoApp.Services;
using System.Threading.Tasks;
using CryptoApp.Services.Commands;
using System.Windows;
using CryptoApp.View.Pages;

namespace CryptoApp.ViewModel
{
    internal class DetailsViewModel : ViewModelBase
    {
        public DetailCryptocurrencyModel DetailCryptocurrency { get; set; }
        public DetailsViewModel(CryptocurrencyModel elem, ICoinCapService coinCapService)
        {
            DetailCryptocurrency = Task.Run(async () => await coinCapService.GetCryptoCurrencyDetails(elem)).Result;
        }
        public LambdaCommand NavigateCryptocurrencyPageCommand
        {
            get
            {
                return new LambdaCommand(obj =>
                {
                    var сvm = new CryptocurrenciesPage();
                    Application.Current.MainWindow.Content = сvm;
                });
            }
        }
    }
}
