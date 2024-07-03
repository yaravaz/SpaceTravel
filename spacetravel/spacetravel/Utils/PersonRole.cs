using spacetravel.ViewModels.Menu;
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
    public class UserRoleToUserControlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string userRole = (string)value;

            switch (userRole)
            {
                case "Admin":
                    return new AdminProfile();

                case "User":
                    return new UserProfile();

                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
