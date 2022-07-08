using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoApp.ViewModels.Base;
using CryptoApp.Infrastructures.Commands;
using CryptoApp.Models;


namespace CryptoApp.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _Title = "Program crypto manager";
        private string colorBackgroundTheme = "#ffffff", colorForegroundTheme = "#000000";
        private bool themePageDark = false;
       
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

        #region Commands

        #region MenuItemThemeClickCommand
        public ICommand MenuItemThemeClickCommand { get; }
        private bool CanMenuItemThemeClickCommandExecute(object p) => true;
        private void OnMenuItemThemeClickCommandExecute(object p) {
           
            bool.TryParse(p.ToString(), out bool pageThemeDark);
            ThemePageDark = pageThemeDark;
            ThemesApp ThemesApp = new ThemesApp();
            string[] colorsTheme = ThemesApp.ChangeColorTheme(pageThemeDark);
            ColorBackgroundTheme = colorsTheme[0];
            ColorForegroundTheme = colorsTheme[1];
        }
        #endregion



        #endregion

        public MainWindowViewModel()
        {
            #region Comands
            MenuItemThemeClickCommand = new LambdaCommand(OnMenuItemThemeClickCommandExecute, CanMenuItemThemeClickCommandExecute);
            #endregion
        }
    }
}
