namespace CryptoApp.Model
{
    class ThemesApp
    {
        const string COLOR_BLACK = "#000000";
        const string COLOR_WHITE = "#ffffff";
        
        public string[] ChangeColorTheme(bool ThemePageDark)
        {
            string colorBG = COLOR_WHITE, colorFR = COLOR_BLACK; 
            if (ThemePageDark)
            {
                colorBG = COLOR_BLACK;
                colorFR = COLOR_WHITE;
            }
            string[] colorsTheme = {colorBG, colorFR};
            return colorsTheme;
        }
    }
}
