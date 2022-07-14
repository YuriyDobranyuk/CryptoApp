using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoApp.Model;

namespace CryptoApp.Services
{
    public interface ICoinCapService
    {
        Task<List<CryptocurrencyModel>> GetCryptocurrency(int count);
        Task<DetailCryptocurrencyModel> GetCryptoCurrencyDetails(CryptocurrencyModel cryptocurrency);
    }
}
