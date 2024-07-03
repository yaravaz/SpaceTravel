using Microsoft.EntityFrameworkCore;
using spacetravel.Command;
using spacetravel.Models;
using spacetravel.Models.Data;
using spacetravel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace spacetravel.ViewModels.Menu
{
    internal class TourInfoViewModel : ViewModel
    {
        private static Models.Data.ApplicationContext _db = new();
        public static Models.Data.ApplicationContext Db
        {
            get => _db ??= new Models.Data.ApplicationContext();
            private set => _db = value;
        }

        private Action<Parameter> navigate;

        private string _nameField = string.Empty;
        public string NameField
        {
            get => _nameField;
            set => Set(ref _nameField, value);
        }

        private string _addressField = string.Empty;
        public string AddressField
        {
            get => _addressField;
            set => Set(ref _addressField, value);
        }
        private string _descriptionField = string.Empty;
        public string DescriptionField
        {
            get => _descriptionField;
            set => Set(ref _descriptionField, value);
        }

        private string _priceField = string.Empty;
        public string PriceField
        {
            get => _priceField;
            set => Set(ref _priceField, value);
        }
        private string _typeField = string.Empty;
        public string TypeField
        {
            get => _typeField;
            set => Set(ref _typeField, value);
        }
        private string _currImage = string.Empty;
        public string CurrImage
        {
            get => _currImage;
            set => Set(ref _currImage, value);
        }
        private string _errorText;
        public string ErrorText
        {
            get => _errorText;
            set => Set(ref _errorText, value);

        }
        private Tour _currTour;
        public Tour CurrTour
        {
            get => _currTour;
            set => Set(ref _currTour, value);
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

        private DateTime _dateField = DateTime.Today;
        public DateTime DateField
        {
            get => _dateField;
            set => Set(ref _dateField, value);
        }
        private ProfileViewModel _profileViewModel;


        private void OnBookTourCommand(object param)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Do you really want to book a tour?", "confirmation", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                if (DateField >= DateTime.Now.Date)
                {
                    if (!Db.Bookings.Any(b => b.Tour.TourID == (int)param && b.IsActive == true && b.User == Global.CurrentUser.UserID))
                    {
                        if (!Db.Bookings.Any(b => b.Mission != null && b.Date <= DateField && b.Date.AddDays(b.Mission.Duration) >= DateField))
                        {
                            var newBooking = new Booking
                            {
                                Mission = null,
                                Name = CurrTour.Name,
                                User = Global.CurrentUser.UserID,
                                Tour = CurrTour,
                                Date = DateField,
                                Price = CurrTour.Price,
                                IsActive = true,
                                IsApproved = false
                            };

                            Db.Bookings.Add(newBooking);
                            Db.SaveChanges();
                            Db.Bookings.Load();

                            _profileViewModel.AddBookings(newBooking);
                            System.Windows.MessageBox.Show("success");
                        }
                        else
                        {
                            ErrorText = "you have already booked a mission";
                        }
                    }
                    else
                    {
                        ErrorText = "there is already a reservation for this date";
                    }
                }
                else
                {
                    ErrorText = "The tour has already passed";
                }
            }
            else if (result == DialogResult.No)
            {
            }
            else if (result == DialogResult.Cancel)
            {
            }
            
        }

        public BaseCommand BookTourCommand { get; }
        public BaseCommand GoBack { get; }
        private void ReturnMainPage(object name)
        {
            Parameter param = new Parameter()
            {
                PageName = "ToursPage"
            };
            navigate?.Invoke(param);
        }

        private void LoadData()
        {
            Db.Tours.Load();
        }

        public TourInfoViewModel(Action<Parameter> navigate, int tourID)
        {
            LoadData();
            BookTourCommand = new BaseCommand(OnBookTourCommand, (obj) => true);
            GoBack = new BaseCommand(ReturnMainPage, (obj) => true);
            this.navigate = navigate;
            _profileViewModel = new ProfileViewModel();

            if (User != null)
            {
                CurrVisibility = "Visible";
            }
            else
            {
                CurrVisibility = "Hidden";
            }

            CurrTour = Db.Tours.FirstOrDefault((tour) => tour.TourID == tourID);
            TypeField = CurrTour.Type;
            NameField = CurrTour.Name;
            AddressField = CurrTour.Address;
            DescriptionField = CurrTour.Description;
            PriceField = "$" + CurrTour.Price.ToString();
            DateField = CurrTour.Date;
            CurrImage = CurrTour.Image;
        }
    }
}
