using Microsoft.EntityFrameworkCore;
using spacetravel.Command;
using spacetravel.Models;
using spacetravel.Models.Data;
using spacetravel.Utils;
using spacetravel.Views.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spacetravel.ViewModels.Menu
{
    class ToursViewModel : ViewModel 
    {
        public ObservableCollection<Tour> Tours { get; } = new ObservableCollection<Tour>();
        private ObservableCollection<Tour> _toursForShow = new ObservableCollection<Tour>();
        public ObservableCollection<Tour> ToursForShow
        {
            get => _toursForShow;
            set => Set(ref _toursForShow, value);
        }
        private Action<Parameter> navigate;

        private static Models.Data.ApplicationContext _db = new();
        public static Models.Data.ApplicationContext Db
        {
            get => _db ??= new Models.Data.ApplicationContext();
            private set => _db = value;
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        private User _user = Global.CurrentUser.Login != "user" ? Db.Users.Find(Global.CurrentUser.UserID) : null;
        public User User
        {
            get => _user;
            set => Set(ref _user, value);
        }
        private Admin _admin = Global.CurrentAdmin.Login != "firstadmin" ? Db.Admins.Find(Global.CurrentAdmin.AdminID) : null;
        public Admin Admin
        {
            get => _admin;
            set => Set(ref _admin, value);
        }
        private string _currVisibility = string.Empty;
        public string CurrVisibility
        {
            get => _currVisibility;
            set => Set(ref _currVisibility, value);
        }

        private string _searchText = string.Empty;
        public string SearchText
        {
            get => _searchText;
            set => Set(ref _searchText, value);
        }

        private string _selectedType = string.Empty;
        public string SelectedType
        {
            get => _selectedType;
            set => Set(ref _selectedType, value);
        }

        private DateTime _dateFieldFrom = DateTime.Today;
        public DateTime DateFieldFrom
        {
            get => _dateFieldFrom;
            set => Set(ref _dateFieldFrom, value);
        }

        private DateTime _dateFieldTo = DateTime.Today;
        public DateTime DateFieldTo
        {
            get => _dateFieldTo;
            set => Set(ref _dateFieldTo, value);
        }
        private string _errorText;
        public string ErrorText
        {
            get => _errorText;
            set => Set(ref _errorText, value);

        }

        private void DeleteTourCommand(object param)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Do you really want to delete tour?", "confirmation", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (param is int id)
                {
                    Tour tourToRemove = Db.Tours.FirstOrDefault(b => b.TourID == id);
                    Tour tourToRemove2 = Tours.FirstOrDefault(b => b.TourID == id);

                    if (tourToRemove != null)
                    {
                        tourToRemove.IsActive = false;
                        Db.SaveChanges();
                        Tours.Remove(tourToRemove2);
                        ToursForShow.Remove(tourToRemove2);
                    }
                }
            }
            else if (result == DialogResult.No)
            {
            }

        }
        public void UpdateTours()
        {
            Tours.Clear();
            ToursForShow.Clear();
            foreach (var tour in Db.Tours)
            {
                if (tour.IsActive == true)
                {
                    Tours.Add(tour);
                    ToursForShow.Add(tour);
                }
            }
            OnPropertyChanged(nameof(Tours));
        }
        private void EditTourCommand(object param)
        {
            Parameter parameter = new Parameter
            {
                PageName = "AddTourPage",
                TourID = (int)param
            };
            navigate?.Invoke(parameter);
        }

        private void OnGoToPageAddCommand(object param)
        { 
            Parameter parameter = new Parameter
            {
                PageName = "AddTourPage"
            };
            navigate?.Invoke(parameter);
        }
        private void OnGoToPageTourCommand(object param)
        {
            string pageName = "TourInfoPage";
            int tourID = (int)param;

            Parameter parameter = new Parameter
            {
                PageName = pageName,
                TourID = tourID
            };
            navigate?.Invoke(parameter);
        }
        private void OnSearchCommand(object param)
        {
            if (DateFieldFrom <= DateFieldTo)
            {
                ToursForShow.Clear();
                if (SearchText != string.Empty)
                {
                    if (SelectedType != string.Empty && SelectedType != "All")
                    {
                        foreach (var tour in Tours.Where(t => t.Name.Contains(SearchText) && t.Date >= DateFieldFrom && t.Date <= DateFieldTo))
                        {
                            if (tour.Type == SelectedType)
                            {
                                ToursForShow.Add(tour);
                                ErrorText = string.Empty;
                            }
                        }
                    }
                    else
                    {
                        foreach (var tour in Tours.Where(t => t.Name.Contains(SearchText) && t.Date >= DateFieldFrom && t.Date <= DateFieldTo))
                        {
                            ToursForShow.Add(tour);
                            ErrorText = string.Empty;

                        }
                    }
                }
                else
                {
                    if (SelectedType != string.Empty && SelectedType != "All")
                    {
                        foreach (var tour in Tours.Where(t => t.Date >= DateFieldFrom && t.Date <= DateFieldTo))
                        {
                            if (tour.Type == SelectedType)
                            {
                                ToursForShow.Add(tour);
                                ErrorText = string.Empty;

                            }
                        }
                    }
                    else
                    {
                        foreach (var tour in Tours.Where(t => t.Date >= DateFieldFrom && t.Date <= DateFieldTo))
                        {
                            ToursForShow.Add(tour);
                            ErrorText = string.Empty;

                        }
                    }
                }
            }
            else
            {
                ErrorText = "incorrect date ranges";
            }

        }

        private void LoadData()
        {
            Db.Users.Load();
            Db.Admins.Load();
            Db.Tours.Load();

            /*if (User != null)
            {
                NameField = User.Fname;
                SurnameField = User.Sname;
                EmailField = User.Email;
            }
            else if (Admin != null)
            {
                NameField = Admin.Fname;
                SurnameField = Admin.Sname;
                EmailField = Admin.Email;
            }*/
        }
        public BaseCommand OnDeleteTourCommand { get; }
        public BaseCommand OnEditTourCommand { get; }
        public BaseCommand GoToPageAddCommand { get; } 
        public BaseCommand ReadTourCommand { get; }
        public BaseCommand SearchCommand { get; }
        public ToursViewModel(Action<Parameter> navigate)
        {
            LoadData();

            using (var context = new Models.Data.ApplicationContext())
            {
                foreach (var tour in context.Tours)
                {
                    if(tour.IsActive == true)
                    {
                        Tours.Add(tour);
                        ToursForShow.Add(tour);
                    }
                    
                }
            }
            if (User != null)
            {
                CurrVisibility = "Hidden";
            }
            else
            {
                CurrVisibility = "Visible";
            }

            OnDeleteTourCommand = new BaseCommand(DeleteTourCommand, (obj) => true);
            OnEditTourCommand = new BaseCommand(EditTourCommand, (obj) => true);
            GoToPageAddCommand = new BaseCommand(OnGoToPageAddCommand, (obj) => true);
            ReadTourCommand = new BaseCommand(OnGoToPageTourCommand, (obj) => true);
            SearchCommand = new BaseCommand(OnSearchCommand, (obj) => true);
            this.navigate = navigate;
        }

    }
}
