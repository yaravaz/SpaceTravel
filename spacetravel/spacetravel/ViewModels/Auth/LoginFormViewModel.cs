using Microsoft.EntityFrameworkCore;
using spacetravel.Command;
using spacetravel.Models;
using spacetravel.Models.Data;
using spacetravel.Utils;
using spacetravel.Views;
using spacetravel.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static spacetravel.Utils.Global;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace spacetravel.ViewModels.Auth
{
    class LoginFormViewModel : ViewModel
    {
        private static ApplicationContext _db = new();
        public static ApplicationContext Db
        {
            get => _db ??= new ApplicationContext();
            private set => _db = value;
        }

        private string _loginField = string.Empty;
        public string LoginField
        {
            get => _loginField;
            set => Set(ref _loginField, value);
        }

        private string _passwordField = string.Empty;
        public string PasswordField
        {
            get => _passwordField;
            set => Set(ref _passwordField, value);
        }
        private string _errorText = string.Empty;
        public string ErrorText
        {
            get => _errorText;
            set => Set(ref _errorText, value);
        }

        private void OpenSignUpPage(object param)
        {
            GetMVM().ContentControlAuth = new RegistrationForm();
        }

        private int CheckUser(string login, string password)
        {
            if (Db.Users.Any(u => u.Login == login) || Db.Admins.Any(a => a.Login == login))
            {
                var user = Db.Users.FirstOrDefault(u => u.Login == login);
                var admin = Db.Admins.FirstOrDefault(a => a.Login == login);

                if (user != null && user.Password == password){              
                    Global.CurrentUser = user;
                    return 2;
                }
                else if(admin != null && admin.Password == password)
                {
                    Global.CurrentAdmin = admin;
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }

        private void LogIn(object param)
        {
            if (LoginField.Trim() != string.Empty && PasswordField.Trim() != string.Empty)
            {
                switch (CheckUser(LoginField, PasswordField))
                {
                    case 0:
                        ErrorText = "user not exists";
                        break;
                    case 1:
                        ErrorText = "incorrect data";
                        break;
                    case 2:
                        ErrorText = "";
                        MenuWindow menuWindow = new MenuWindow();
                        menuWindow.Show();
                        Application.Current.MainWindow.Close();
                        break;
                }
            }
            else
            {
                ErrorText = "empty fields";
            }
        }
        private async void LoadData()
        {
            await Db.Users.LoadAsync();
            await Db.Admins.LoadAsync();
        }
        public BaseCommand OnLogInCommand { get; set; }
        public BaseCommand OnOpenSignUpPageCommand { get; }
        public LoginFormViewModel()
        {
            LoadData();
            OnLogInCommand = new BaseCommand(LogIn, (obj) => true);
            OnOpenSignUpPageCommand = new BaseCommand(OpenSignUpPage, (obj) => true);
        }

    }
}
