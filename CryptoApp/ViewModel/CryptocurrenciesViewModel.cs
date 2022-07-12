using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CryptoApp.Models;
using CryptoApp.Services;
using CryptoApp.Services.Commands;
using CryptoApp.ViewModel.Base;

namespace CryptoApp.ViewModel
{
    internal class CryptocurrenciesViewModel : ViewModelBase
    {
        #region Props

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;

                OnPropertyChanged(nameof(SearchText));
                OnPropertyChanged(nameof(Cryptocurrencies));
            }
        }

        private ObservableCollection<CryptocurrencyModel> _cryptocurrencies;
        public ObservableCollection<CryptocurrencyModel> Cryptocurrencies
        {
            get
            {
                if (SearchText == null) return _cryptocurrencies ?? new ObservableCollection<CryptocurrencyModel>();

                return new ObservableCollection<CryptocurrencyModel>(_cryptocurrencies?.Where(x => x.Name?.Contains(SearchText) ?? false)
                    ?? new ObservableCollection<CryptocurrencyModel>());
            }
            set { _cryptocurrencies = value; }
        }

        #endregion

        public LambdaCommand NavigateDetailsCommand
        {
            get
            {
                return new LambdaCommand(obj =>
                {
                    System.Console.WriteLine();
                });
            }
        }

        public CryptocurrenciesViewModel(ICoinCapService coinCap)
        {
            var res = Task.Run(async () => await coinCap.GetCryptocurrency(10)).Result;
            Cryptocurrencies = new ObservableCollection<CryptocurrencyModel>(res);
        }
    }
}
