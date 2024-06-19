using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для SelectPage.xaml
    /// </summary>
    public partial class SelectPage : Page
    {
        DayItems dayItems = new DayItems()
        {
            Items = new List<Item>()
            {
                new Item()
                {
                    Name = "Чампан",
                    IconPath = "..\\..\\Resources\\chapman.png",
                },
                new Item()
                {
                    Name = "Джек",
                    IconPath = "..\\..\\Resources\\jack.png",
                },
                new Item()
                {
                    Name = "Камел",
                    IconPath = "..\\..\\Resources\\kame.png",
                },
                new Item()
                {
                    Name = "ЛМ",
                    IconPath = "..\\..\\Resources\\lm.png",
                },
                new Item()
                {
                    Name = "Мальборо",
                    IconPath = "..\\..\\Resources\\malboro.png",
                },
                new Item()
                {
                    Name = "Парламент",
                    IconPath = "..\\..\\Resources\\parlament.png",
                },
                new Item()
                {
                    Name = "Русские",
                    IconPath = "..\\..\\Resources\\russian.png",
                },
                new Item()
                {
                    Name = "Винстон",
                    IconPath = "..\\..\\Resources\\winston.png",
                },
            }
        };

        bool flagAlreadyExist = true;
        int existIndex = 0;

        public SelectPage(DateTime SelectedDate)
        {
            InitializeComponent();
            DateTextBlock.Text = SelectedDate.ToLongDateString();
            dayItems.Day = SelectedDate;

            foreach (var day in DayItems.days)
            {
                if (day.Day == SelectedDate)
                {
                    dayItems = day;
                    flagAlreadyExist = false;
                    existIndex = DayItems.days.IndexOf(day);
                    break;
                }
            }

            GenerateItems();
        }

        private void GenerateItems()
        {
            ItemsStackPanel.Children.Clear();

            TextBlock textblock = new TextBlock()
            {
                Text = "От чего ты хочешь умереть сегодня",
                TextAlignment = TextAlignment.Center,
                FontSize = 18,
            };

            ItemsStackPanel.Children.Add(textblock);

            foreach (Item item in dayItems.Items)
            {
                StackPanel childrenStackPanel = new StackPanel()
                {
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(5),
                };

                CheckBox checkBox = new CheckBox()
                {
                    IsChecked = item.IsSelected,
                    Margin = new Thickness(30, 5, 5, 5),
                    Tag = item,
                };

                checkBox.Checked += CheckBox_Checked;
                checkBox.Unchecked += CheckBox_Unchecked;

                BitmapImage bitmapImage = new BitmapImage(new Uri(item.IconPath, UriKind.Relative));

                Image image = new Image()
                {
                    Source = bitmapImage,
                    Margin = new Thickness(5),
                    Stretch = Stretch.Fill,
                    MaxWidth = 100,
                    MaxHeight = 100,
                    Width = bitmapImage.PixelWidth,
                    Height = bitmapImage.PixelHeight,
                };

                TextBlock textBlock = new TextBlock()
                {
                    Text = item.Name,
                    FontSize = 16,
                };

                childrenStackPanel.Children.Add(checkBox);
                childrenStackPanel.Children.Add(image);
                childrenStackPanel.Children.Add(textBlock);
                ItemsStackPanel.Children.Add(childrenStackPanel);
            };
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).Content = (Application.Current.MainWindow as MainWindow).mainPage;
        }

        private void SaveAndExit_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;

            foreach (var item in dayItems.Items)
            {
                if (item.IsSelected)
                {
                    flag = true;
                }
            }

            if (flag)
            {
                if (DayItems.days == null)
                {
                    DayItems.days = new List<DayItems>();
                }

                if (flagAlreadyExist)
                {
                    DayItems.days.Add(dayItems);
                }
                else
                {
                    DayItems.days[existIndex] = dayItems;
                }    
            }

            (Application.Current.MainWindow as MainWindow).Content = (Application.Current.MainWindow as MainWindow).mainPage;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            dayItems.Items[dayItems.Items.IndexOf((sender as CheckBox).Tag as Item)].IsSelected = (sender as CheckBox).IsChecked ?? false;
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            dayItems.Items[dayItems.Items.IndexOf((sender as CheckBox).Tag as Item)].IsSelected = (sender as CheckBox).IsChecked ?? false;
        }
    }
}
