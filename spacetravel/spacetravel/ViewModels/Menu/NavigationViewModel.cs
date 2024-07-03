using spacetravel.Command;
using spacetravel.Models;
using spacetravel.Utils;
using spacetravel.ViewModels.Menu.Mission;
using spacetravel.Views.Controls;
using spacetravel.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace spacetravel.ViewModels.Menu
{
    internal class NavigationViewModel : ViewModel
    {
        public static Home HomePage = new Home();
        public static Missions MissionsPage = new Missions();
        public static Tours ToursPage = new Tours();
        public static Profile ProfilePage = new Profile();

        private object _currentPageMenu;
        public object CurrentPageMenu
        {
            get => _currentPageMenu;
            set => Set(ref _currentPageMenu, value);
        }

        private void Home(object obj) => CurrentPageMenu = HomePage;
        private void Missions(object obj) => CurrentPageMenu = new MissionsViewModel(ChangePage); //CurrentPageMenu = MissionsPage;
        private void Tours(object obj) => CurrentPageMenu = new ToursViewModel(ChangePage);
        private void Profile(object obj) => CurrentPageMenu = new Profile();

        private void CloseApp(object param)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("do you really want to close the window?", "confirmation", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                System.Windows.Application.Current.Shutdown();
            }
            else if (result == DialogResult.No)
            {
            }
            
        }
        private void SignOut(object param)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Do you really want to log out of your account?", "confirmation", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Global.CurrentUser = new User("user", "user1234", "help@gmail.com");
                Global.CurrentAdmin = new Admin("firstadmin", "admin1234", "help@gmail.com");
                List<MenuWindow> windowsToClose = System.Windows.Application.Current.Windows.OfType<MenuWindow>().ToList();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                foreach (Window window in windowsToClose)
                {
                    window.Close();
                }
                /*System.Windows.Application.Current.MainWindow.Close();*/

            }
            else if (result == DialogResult.No)
            {
            }

        }

        private void ChangePage(Parameter p)
        {
            int tourID = p.TourID;
            switch (p.PageName)
            {
                case "Missions":
                    CurrentPageMenu = new MissionsViewModel(ChangePage);
                    break;
                case "IISPage":
                    CurrentPageMenu = new IssViewModel(ChangePage);
                    break;
                case "OrbitPage":
                    CurrentPageMenu = new OrbitViewModel(ChangePage);
                    break;
                case "MoonPage":
                    CurrentPageMenu = new MoonViewModel(ChangePage);
                    break;
                case "MarsPage":
                    CurrentPageMenu = new MarsViewModel(ChangePage);
                    break;
                case "AddTourPage":
                    CurrentPageMenu = new AddTourPageViewModel(ChangePage, tourID);
                    break;
                case "ToursPage":
                    CurrentPageMenu = new ToursViewModel(ChangePage);
                    break;
                case "TourInfoPage":
                    CurrentPageMenu = new TourInfoViewModel(ChangePage, tourID);
                    break;
            }
        }

        public BaseCommand OnCloseAppCommand { get; set; }
        public BaseCommand OnSignOutCommand { get; set; }
        public BaseCommand HomeCommand { get; set; }
        public BaseCommand MissionsCommand { get; set; }
        public BaseCommand ToursCommand { get; set; }
        public BaseCommand ProfileCommand { get; set; }
        public NavigationViewModel()
        {
            HomeCommand = new BaseCommand(Home, (obj) => true);
            MissionsCommand = new BaseCommand(Missions, (obj) => true);
            ToursCommand = new BaseCommand(Tours, (obj) => true);
            ProfileCommand = new BaseCommand(Profile, (obj) => true);
            OnCloseAppCommand = new BaseCommand(CloseApp, (obj) => true);
            OnSignOutCommand = new BaseCommand(SignOut, (obj) => true);
  
            CurrentPageMenu = HomePage;
        }
    }
}
