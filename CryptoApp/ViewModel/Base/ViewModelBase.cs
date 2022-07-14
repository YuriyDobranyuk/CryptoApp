using System.ComponentModel;
using System.Windows.Input;
using CryptoApp.Services.Commands;
using CryptoApp.Model;

namespace CryptoApp.ViewModel.Base
{
    internal abstract class ViewModelBase : INotifyPropertyChanged
    {
        private string titleApp = "Program crypto manager";
        private string viewNamePage = "CryptocurrenciesPage";
        private string colorBackgroundTheme = "#ffffff", colorForegroundTheme = "#000000";
        private bool themePageDark = false;

        public string TitleApp
        {
            get => titleApp;
            set => Set(ref titleApp, value);
        }
        public string ViewNamePage
        {
            get => viewNamePage;
            set => Set(ref viewNamePage, value);
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        protected virtual bool Set<T>(ref T field, T value, string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }

        #region Commands

        #region MenuItemThemeClickCommand
        public ICommand MenuItemThemeClickCommand { get; }
        private bool CanMenuItemThemeClickCommandExecute(object p) => true;
        private void OnMenuItemThemeClickCommandExecute(object p)
        {

            bool.TryParse(p.ToString(), out bool pageThemeDark);
            ThemePageDark = pageThemeDark;
            ThemesApp ThemesApp = new ThemesApp();
            string[] colorsTheme = ThemesApp.ChangeColorTheme(pageThemeDark);
            ColorBackgroundTheme = colorsTheme[0];
            ColorForegroundTheme = colorsTheme[1];
        }
        #endregion

        #endregion

        public ViewModelBase()
        {
            #region Comands
            MenuItemThemeClickCommand = new LambdaCommand(OnMenuItemThemeClickCommandExecute, CanMenuItemThemeClickCommandExecute);
            #endregion
        }

    }

}
