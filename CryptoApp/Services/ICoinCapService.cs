using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoApp.Models;

namespace CryptoApp.Services
{
    public interface ICoinCapService
    {
        Task<List<CryptocurrencyModel>> GetCryptocurrency(int count);
    }
}
