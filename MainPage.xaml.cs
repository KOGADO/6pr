using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PracticalWork5
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {

        public MainPage()
        {
            InitializeComponent();
            MyDatePicker.SelectedDate = DateTime.Today;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            DateTime newDate = MyDatePicker.SelectedDate.Value.AddMonths(-1);
            MyDatePicker.SelectedDate = newDate;
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            DateTime newDate = MyDatePicker.SelectedDate.Value.AddMonths(1);
            MyDatePicker.SelectedDate = newDate;
        }

        private void MyDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            CreateUserControlsBasedOnDays();
        }

        public void CreateUserControlsBasedOnDays()
        {
            int daysInMonth = DateTime.DaysInMonth(MyDatePicker.SelectedDate.Value.Year, MyDatePicker.SelectedDate.Value.Month);

            MyWrapPanel.Children.Clear();

            for (int i = 1; i <= daysInMonth; i++)
            {
                var userControl = new CalendarItemUserControl();

                userControl.DayTextBlock.Text = i.ToString();

                DateTime dateTime = new DateTime(year: MyDatePicker.SelectedDate.Value.Year, MyDatePicker.SelectedDate.Value.Month, i);
                userControl.SelectedDate = dateTime;

                if (DayItems.days != null)
                {
                    foreach (var dayItems in DayItems.days)
                    {
                        if (dayItems.Day == dateTime)
                        {
                            foreach (var item in dayItems.Items)
                            {
                                if (item.IsSelected)
                                {
                                    BitmapImage bitmapImage = new BitmapImage(new Uri(item.IconPath, UriKind.Relative));
                                    userControl.ItemImage.Source = bitmapImage;
                                    userControl.ItemImage.Height = bitmapImage.PixelHeight;
                                    userControl.ItemImage.Width = bitmapImage.PixelWidth;
                                    break;
                                }
                            }
                        }
                    }
                }

                MyWrapPanel.Children.Add(userControl);
            }
        }
    }
}
