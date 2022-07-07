using CryptoApp.ViewModels;
using System.Windows;

namespace CryptoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItemThemeClick(object sender, RoutedEventArgs e)
        {
            string tag = (string)((FrameworkElement)sender).Tag;
            bool pageThemeDark = false;
            if (tag == "dark")
            {
                pageThemeDark = true;
            }
            MainWindowViewModel MainWindowViewModel = new MainWindowViewModel();
            MainWindowViewModel.ThemePageDark = pageThemeDark;
            MainWindowViewModel.ChangeColorTheme();
        }

    }
}
