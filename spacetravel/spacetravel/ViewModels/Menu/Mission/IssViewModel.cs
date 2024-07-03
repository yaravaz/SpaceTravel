using Microsoft.EntityFrameworkCore;
using spacetravel.Command;
using spacetravel.Models;
using static spacetravel.Models.Mission;
using spacetravel.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using spacetravel.Utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;

namespace spacetravel.ViewModels.Menu.Mission
{
    class IssViewModel : ViewModel
    {
        private static Models.Data.ApplicationContext _db = new();
        public static Models.Data.ApplicationContext Db
        {
            get => _db ??= new Models.Data.ApplicationContext();
            private set => _db = value;
        }
        private ProfileViewModel _profileViewModel;

        private Models.Mission _currMission;
        public Models.Mission CurrMission
        {
            get => _currMission;
            set => Set(ref _currMission, value);
        }
        private Spaceship _currSpaceship;
        public Spaceship CurrSpaceship
        {
            get => _currSpaceship;
            set => Set(ref _currSpaceship, value);
        }

        private Action<Parameter> navigate;

        private string _descMissionField;
        public string DescMissionField
        {
            get => _descMissionField;
            set => Set(ref _descMissionField, value);
        }
        private string _durationField;
        public string DurationField
        {
            get => _durationField;
            set => Set(ref _durationField, value);
        }
        private string _altituteField;
        public string AltituteField
        {
            get => _altituteField;
            set => Set(ref _altituteField, value);
        }
        private string _priceField;
        public string PriceField
        {
            get => _priceField;
            set => Set(ref _priceField, value);
        }

        private string _descShipField;
        public string DescShipField
        {
            get => _descShipField;
            set => Set(ref _descShipField, value);
        }
        private string _capacityField;
        public string CapacityField
        {
            get => _capacityField;
            set => Set(ref _capacityField, value);
        }
        private string _diameterField;
        public string DiameterField
        {
            get => _diameterField;
            set => Set(ref _diameterField, value);
        }
        private string _heightField;
        public string HeightField
        {
            get => _heightField;
            set => Set(ref _heightField, value);
        }
        private string _payloadField;
        public string PayloadField
        {
            get => _payloadField;
            set => Set(ref _payloadField, value);
        }

        private DateTime _selectedDate = DateTime.Today;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set => Set(ref _selectedDate, value);
        }
        private string _weightField;
        public string WeightField
        {
            get => _weightField;
            set
            {
                Set(ref _weightField, value);
                UpdateTotalPrice();
            }
        }
        private string _totalPrice;
        public string TotalPrice
        {
            get => "$" + _totalPrice;
            set => Set(ref _totalPrice,  value);
        }

        private string _errorText;
        public string ErrorText
        {
            get => _errorText;
            set => Set(ref _errorText, value);

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


        public BaseCommand GoBack {  get; }
        public BaseCommand BookCommand {  get; }
        
        private void ReturnMainPage(object name)
        {
            Parameter param = new Parameter()
            {
                PageName = "Missions"
            };
            navigate?.Invoke(param);
        }

        private void UpdateTotalPrice()
        {
            if (WeightField == null || WeightField == string.Empty)
            {
                TotalPrice = CurrMission.Price.ToString();
            }
            else
            {
                TotalPrice = (CurrMission.Price + CurrMission.Price * (float.Parse(WeightField) / 200)).ToString();
            }
        }

        private void OnBookCommand(object p)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Do you really want to book a flight?", "confirmation", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                bool error = false;
                if (SelectedDate != null && WeightField != string.Empty)
                {
                    if(SelectedDate >= DateTime.Now.Date)
                    {
                        if(int.Parse(WeightField) > 40 && int.Parse(WeightField) < 120)
                        {
                            if (!Db.Bookings.Any(b => b.Date == SelectedDate && b.IsActive == true))
                            {
                                foreach (var booking in Db.Bookings.Where(b => b.Mission != null && b.IsActive == true))
                                {
                                    if ((booking.Date < SelectedDate && SelectedDate < booking.Date.AddDays(booking.Mission.Duration) && booking.User == Global.CurrentUser.UserID) ||
                                        (booking.Date > SelectedDate && SelectedDate.AddDays(booking.Mission.Duration) > booking.Date && booking.User == Global.CurrentUser.UserID))
                                    {
                                        error = true;
                                    }
                                }
                                if (!error)
                                {
                                    var newBooking = new Booking
                                    {
                                        Mission = CurrMission,
                                        Name = CurrMission.Name,
                                        User = Global.CurrentUser.UserID,
                                        Tour = null,
                                        Date = (DateTime)SelectedDate,
                                        Price = float.Parse(TotalPrice[1..]),
                                        IsActive = true,
                                        IsApproved = false
                                    };

                                    Db.Bookings.Add(newBooking);
                                    Db.SaveChanges();


                                    _profileViewModel.AddBookings(newBooking);

                                    ErrorText = "";
                                    WeightField = string.Empty;
                                    SelectedDate = DateTime.Now;
                                    System.Windows.MessageBox.Show("success");
                                }
                                else
                                {
                                    ErrorText = "the flight is still in progress";
                                }
                            }
                            else
                            {
                                if (Db.Bookings.Any(b => b.Date == SelectedDate && b.IsActive == true && b.User == Global.CurrentUser.UserID))
                                {
                                    ErrorText = "there is already a reservation for this date";
                                }
                                else if (Db.Bookings.Count(b => b.Date == SelectedDate && b.IsActive == true && b.Name == CurrMission.Name) >= CurrMission.Spaceship.Capacity)
                                {
                                    ErrorText = "the spaceship is full";
                                }
                                else
                                {
                                    var newBooking = new Booking
                                    {
                                        Mission = CurrMission,
                                        Name = CurrMission.Name,
                                        User = Global.CurrentUser.UserID,
                                        Tour = null,
                                        Date = (DateTime)SelectedDate,
                                        Price = float.Parse(TotalPrice[1..]),
                                        IsActive = true,
                                        IsApproved = false
                                    };

                                    Db.Bookings.Add(newBooking);
                                    Db.SaveChanges();
                                    Db.Bookings.Load();

                                    _profileViewModel.AddBookings(newBooking);

                                    ErrorText = "";
                                    WeightField = string.Empty;
                                    SelectedDate = DateTime.Now;
                                    System.Windows.MessageBox.Show("success");
                                }
                            }
                        }
                        else
                        {
                            ErrorText = "you don't fit the weight(40-120)";
                        }
                    }
                    else
                    {
                        ErrorText = "we can't travel to the past yet";
                    }

                }
                else
                {
                    ErrorText = "empty fields";
                }
            }
            else if (result == DialogResult.No)
            {
            }
            
        }

        private void LoadData()
        {
            
            Db.Missions.Load();
            Db.Spaceships.Load();
            Db.Bookings.Load();

            try { Db.Missions.Attach(CurrMission); } catch { }
            try { Db.Spaceships.Attach(CurrSpaceship); } catch { }
        }

        public IssViewModel(Action<Parameter> nav)
        {
            LoadData();

            CurrMission = Db.Missions.FirstOrDefault(m => m.Name == "ISS");
            CurrSpaceship = Db.Spaceships.Find(CurrMission.Spaceship.SpaceshipID);

            DescMissionField = CurrMission.Description;
            DurationField = CurrMission.Duration.ToString() + " days";
            AltituteField = CurrMission.Altitude.ToString() + " km";
            PriceField = "$"+CurrMission.Price.ToString();

            DescShipField = CurrSpaceship.Description;
            CapacityField = CurrSpaceship.Capacity.ToString() + " passengers";
            DiameterField = CurrSpaceship.Diameter.ToString() + " m";
            HeightField = CurrSpaceship.Height.ToString() + " m";
            PayloadField = CurrSpaceship.PayloadCapacity + " kg";

            TotalPrice = CurrMission.Price.ToString();

            if (User != null)
            {
                CurrVisibility = "Visible";
            }
            else
            {
                CurrVisibility = "Hidden";
            }

            _profileViewModel = new ProfileViewModel();
            GoBack = new BaseCommand(ReturnMainPage, (obj) => true);
            BookCommand = new BaseCommand(OnBookCommand, (obj) => true);
            navigate = nav;
        }
    }
}
