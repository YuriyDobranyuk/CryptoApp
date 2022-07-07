using System;
using System.Windows;
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
        private string colorBackgroundTheme, colorForegroundTheme;
        private bool themePageDark = false;
        //readonly MyMathModel _model = new MyMathModel();

        /*public MainWindowViewModel()
        {
            //таким нехитрым способом мы пробрасываем изменившиеся свойства модели во View
            //_model.PropertyChanged += (s, e) => { RaisePropertyChanged(e.PropertyName); };
            AddCommand = new DelegateCommand<string>(str => {
                //проверка на валидность ввода - обязанность VM
                int ival;
                if (int.TryParse(str, out ival)) _model.AddValue(ival);
            });
            RemoveCommand = new DelegateCommand<int?>(i => {
                if (i.HasValue) _model.RemoveValue(i.Value);
            });
        }*/

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
       
        public string ColorBackgroundTheme
        {
            get => colorBackgroundTheme;
            set => Set(ref colorBackgroundTheme, value);
        }

        public string ColorForegroundTheme
        {
            get => colorForegroundTheme;
            set => Set(ref colorForegroundTheme, value);
        }
        public bool ThemePageDark
        {
            get => themePageDark;
            set => Set(ref themePageDark, value);
        }



    }
}
