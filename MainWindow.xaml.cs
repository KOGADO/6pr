using System;
using System.IO;
using System.Windows;

namespace PracticalWork5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string daysSelectsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Calendar\\daysSelectsPath.json";

        public MainPage mainPage = new MainPage();
        public MainWindow()
        {
            InitializeComponent();

            Content = mainPage;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Files.Serialization(DayItems.days, daysSelectsPath);
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            if (Content is MainPage mainPage)
            {
                mainPage.CreateUserControlsBasedOnDays();
            }
        }
    }
}
