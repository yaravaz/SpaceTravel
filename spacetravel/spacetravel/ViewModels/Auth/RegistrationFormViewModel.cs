using Microsoft.EntityFrameworkCore.Metadata;
using spacetravel.Command;
using spacetravel.Models;
using spacetravel.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using spacetravel.Utils;
using System.Windows;
using spacetravel.Views.Windows;
using spacetravel.Views;
using System.Windows.Controls;
using static spacetravel.Utils.Global;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace spacetravel.ViewModels.Auth
{
    class RegistrationFormViewModel: ViewModel
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
        private string _emailField = string.Empty;
        public string EmailField
        {
            get => _emailField;
            set => Set(ref _emailField, value);
        }

        private string _passwordField = string.Empty;
        public string PasswordField
        {
            get => _passwordField;
            set => Set(ref _passwordField, value);
        }

        private string _confPasswordField = string.Empty;
        public string ConfPasswordField
        {
            get => _confPasswordField;
            set => Set(ref _confPasswordField, value);
        }

        private string _errorText = string.Empty;
        public string ErrorText
        {
            get => _errorText;
            set => Set(ref _errorText, value);
        }
        private void OpenLogInPage(object param)
        {
            GetMVM().ContentControlAuth.Content = new LoginForm();
        }
        private int CheckUser(string login, string email, string password, string confpassword)
        {
            if(Regex.IsMatch(login, "^[a-zA-Z0-9_.]{4,20}$")){
                if(Regex.IsMatch(password, "^(?=.*[a-zA-Zа-яА-Я])(?=.*\\d).{4,20}$")){
                    if(Regex.IsMatch(email, "^[a-zA-Zа-яА-Я0-9-]+@[a-zA-Zа-яА-Я-]{2,}\\.[a-zA-Zа-яА-Я-.]{2,4}$")){
                        if (!(Db.Users.Any((u) => u.Login == login) || (Db.Admins.Any((a) => a.Login == login))))
                        {
                            if (password != confpassword) return 1;
                            var newUser = new User(login, password, email);
                            Db.Users.Add(newUser);
                            Global.CurrentUser = newUser;
                            Db.SaveChanges();
                            return 2;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        return 5;
                    }
                }
                else
                {
                    return 4;
                }
            }
            else
            {
                return 3;
            }
            
        }
        private void OnSingUp(object param)
        {
            if(LoginField.Trim() != string.Empty && PasswordField.Trim() != string.Empty && EmailField.Trim() != string.Empty && ConfPasswordField.Trim() != string.Empty)
            {
                switch(CheckUser(LoginField, EmailField, PasswordField, ConfPasswordField))
                {
                    case 0:
                        ErrorText = "user exists yet";
                        break;
                    case 1:
                        ErrorText = "passwords are not the same";
                        break;
                    case 2:
                        ErrorText = "";
                        MenuWindow menuWindow = new MenuWindow();
                        menuWindow.Show();
                        Application.Current.MainWindow.Close();
                        break;
                    case 3:
                        ErrorText = "the length of the login must be from 4 to 20";
                        break;
                    case 4:
                        ErrorText = "the password contain one letter and a number, the length is from 4 to 20";
                        break;
                    case 5:
                        ErrorText = "incorrect mail format";
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
        public BaseCommand OnSignUpCommand {  get; set; }
        public BaseCommand OnOpenLogInPageCommand { get; }
        public RegistrationFormViewModel()
        {
            LoadData();
            OnSignUpCommand = new BaseCommand(OnSingUp, (obj) => true);
            OnOpenLogInPageCommand = new BaseCommand(OpenLogInPage, (obj) => true);
        }
    }
}
