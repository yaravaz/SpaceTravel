using spacetravel.Models.Data;
using spacetravel.Views.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace spacetravel.Utils
{
    internal class IDToNameConverter : IValueConverter
    {
        private static ApplicationContext _db = new();
        public static ApplicationContext Db
        {
            get => _db ??= new ApplicationContext();
            private set => _db = value;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int userID = (int)value;

            return Db.Users.FirstOrDefault(u => u.UserID == userID).Login;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
