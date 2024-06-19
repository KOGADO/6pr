using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork5
{
    public class DayItems
    {
        public static List<DayItems> days = Files.Deserialization<DayItems>(MainWindow.daysSelectsPath);
        public DateTime Day { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        public string Name { get; set; }
        public string IconPath { get; set; }
        public bool IsSelected { get; set; }
    }
}
