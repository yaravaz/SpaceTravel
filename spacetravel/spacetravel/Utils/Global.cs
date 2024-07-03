using spacetravel.Models;
using spacetravel.ViewModels.Auth;
using spacetravel.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spacetravel.Utils
{
    public static class Global
    {
        private static MainWindowViewModel mvm = new MainWindowViewModel();
        private static User _currentUser;
        private static Admin _currentAdmin;

        public static MainWindowViewModel GetMVM()
        {
            if(mvm == null)
            {
                return mvm = new MainWindowViewModel();
            }
            return mvm;
        }
        public static User CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    return new User("user", "user1234", "help@gmail.com");
                }
                else { return _currentUser; }
            }
            set => _currentUser = value;
        }
        public static Admin CurrentAdmin
        {
            get
            {
                if (_currentAdmin == null)
                {
                    return new Admin("firstadmin", "admin1234", "help@gmail.com");
                }
                else { return _currentAdmin; }
            }
            set => _currentAdmin = value;
        }
        static ApplicationContext db = new();

    }
}
