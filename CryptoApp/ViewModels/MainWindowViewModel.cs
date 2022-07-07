using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoApp.ViewModels.Base;

namespace CryptoApp.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _Title = "Program crypto manager";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

    }
}
