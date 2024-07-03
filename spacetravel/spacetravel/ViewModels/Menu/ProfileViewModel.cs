using Microsoft.EntityFrameworkCore;
using spacetravel.Command;
using spacetravel.Models;
using spacetravel.Models.Data;
using spacetravel.Utils;
using spacetravel.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using spacetravel.Views.Controls;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace spacetravel.ViewModels.Menu
{
    class ProfileViewModel : ViewModel
    {
        private ObservableCollection<Booking> _bookings = new ObservableCollection<Booking>();
        public ObservableCollection<Booking> Bookings 
        {
            get => _bookings;
            set => Set(ref _bookings, value);
        }
        private ObservableCollection<Booking> _bookingsDeny = new ObservableCollection<Booking>();
        public ObservableCollection<Booking> BookingsDeny
        {
            get => _bookingsDeny;
            set => Set(ref _bookingsDeny, value);
        }
        private ObservableCollection<Booking> _bookingsShow = new ObservableCollection<Booking>();
        public ObservableCollection<Booking> BookingsShow
        {
            get => _bookingsShow;
            set => Set(ref _bookingsShow, value);
        }
        private ObservableCollection<Booking> _bookingsUser = new ObservableCollection<Booking>();
        public ObservableCollection<Booking> BookingsUser
        {
            get => _bookingsUser;
            set => Set(ref _bookingsUser, value);
        }
        private Action<Parameter> navigate;

        private static Models.Data.ApplicationContext _db = new();
        public static Models.Data.ApplicationContext Db
        {
            get => _db ??= new Models.Data.ApplicationContext();
            private set => _db = value;
        }

        private string _nameField = string.Empty;
        public string NameField
        {
            get => _nameField;
            set => Set(ref _nameField, value);
        }
        private string _surnameField = string.Empty;
        public string SurnameField
        {
            get => _surnameField;
            set => Set(ref _surnameField, value);
        }

        private string _emailField = string.Empty;
        public string EmailField
        {
            get => _emailField;
            set => Set(ref _emailField, value);
        }

        private string _errorText = string.Empty;
        public string ErrorText
        {
            get => _errorText;
            set => Set(ref _errorText, value);
        }
        private string _name;
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set => Set(ref _searchText, value);
        }
        private string _userName;
        public string UserName
        {
            get => _userName;
            set => Set(ref _userName, value);
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

        private string _currPerson = string.Empty;
        public string CurrPerson
        {
            get => _currPerson;
            set => Set(ref _currPerson, value);
        }
        private void OnEditCommand(object param)
        {
            if (NameField.Trim() != string.Empty && SurnameField.Trim() != string.Empty)
            {
                if (Regex.IsMatch(NameField, "^[a-zA-Zа-яА-Я]"))
                {
                    if (Regex.IsMatch(SurnameField, "^[a-zA-Zа-яА-Я]"))
                    {
                        if (User != null)
                        {
                            User.Fname = NameField.Trim();
                            User.Sname = SurnameField.Trim();
                            User.Email = EmailField.Trim() != string.Empty ? EmailField.Trim() : User.Email;
                            Global.CurrentUser = User;
                            Db.SaveChanges();
                        }
                        else
                        {
                            Admin.Fname = NameField.Trim();
                            Admin.Sname = SurnameField.Trim();
                            Admin.Email = EmailField.Trim() != string.Empty ? EmailField.Trim() : Admin.Email;
                            Global.CurrentAdmin = Admin;
                            Db.SaveChanges();
                        }
                        ErrorText = string.Empty;
                    }
                    else
                    {
                        ErrorText = "the surname can only consist of letters";
                    }
                }
                else
                {
                    ErrorText = "the name can only consist of letters";
                }
            }
            else
            {
                ErrorText = "empty fields";
            }
        }

        private void DeleteBookingCommand(object param)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Do you really want to cancel your reservation?", "confirmation", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (param is int id)
                {
                    Booking bookingToRemove = Db.Bookings.FirstOrDefault(b => b.BookingID == id);
                    Booking bookingToRemove2 = Bookings.FirstOrDefault(b => b.BookingID == id);

                    if (bookingToRemove != null)
                    {
                        bookingToRemove.IsActive = false;
                        Db.SaveChanges();
                        Bookings.Remove(bookingToRemove2);
                        BookingsShow.Remove(bookingToRemove2);
                        BookingsUser.Remove(bookingToRemove2);
                        BookingsDeny.Add(bookingToRemove2);
                    }
                }
            }
            else if (result == DialogResult.No)
            {
            }

        }

        private void ApproveCommand(object param)
        {
            string smtpServer = "smtp.mail.ru";
            int smtpPort = 587;
            string service = string.Empty;
            string smtpUsername = "yaravazvov877@mail.ru";
            string smtpPassword = "gTwVWEuSLQJwN78FKpmE";
            Booking currBooking = Db.Bookings.FirstOrDefault(b => b.BookingID == (int)param);
            string UserName = Db.Users.FirstOrDefault(u => u.UserID == currBooking.User).Login;
            string Email = Db.Users.FirstOrDefault(u => u.UserID == currBooking.User).Email;
            string BookingName = currBooking.Name;
            string BookingDate = currBooking.Date.Date.ToString();
            if(currBooking.Tour != null)
            {
                service = "tour";
            }
            else if(currBooking.Mission != null)
            {
                service = "mission";
            }

            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(smtpUsername);
                    mailMessage.To.Add(Email); 
                    mailMessage.Subject = "Thanks for booking!";
                    mailMessage.IsBodyHtml = true;

                    string body = "<html><body>";

                    body += "<style>";
                    body += "body { font-family: sans-serif;" +
                            "       background-color: dimgray;" +
                            "       color: white;}";
                    body += "h1 { text-align: center; }";
                    body += "p { width: 60%;" +
                        "        justify-content: left }";
                    body += "</style>";

                    body += $"<h1>Hello, {UserName}!</h1>";
                    body += $"<p>You have booked a {service} {BookingName}!</p>";
                    body += $"<p>We are waiting for you at 1030 15th Street, New York, Suite 220E, Washington, DC, 20005-1503 at 11:00 {BookingDate}</p>";
                    body += $"<p>you can call at 310-363-6000</p>";
                    body += "<p>We want to express our sincere gratitude for booking our services. Your trust and support are very important to us.</br></br>We appreciate your choice and guarantee that we will do everything possible to provide you with an excellent experience. Our team of specialists is working diligently to meet your needs.</br></br>We have already started preparing and will contact you shortly to confirm the details.</br></br>Once again, thank you for choosing our company. We value your trust and look forward to the opportunity to serve you.</br></br>Best regards,</br>SpaceToTravel</p>\r\n";
                    body += "</body></html>";

                    mailMessage.Body = body;

                    try
                    {
                        smtpClient.Send(mailMessage);
                        Console.WriteLine("The message was sent successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Oops: {ex.Message}");
                    }
                }
            }

            Booking bookingToRemove = Db.Bookings.FirstOrDefault(b => b.BookingID == currBooking.BookingID);
            Booking bookingToRemove2 = Bookings.FirstOrDefault(b => b.BookingID == currBooking.BookingID);

            if (bookingToRemove != null)
            {
                bookingToRemove.IsActive = false;
                Db.SaveChanges();
                Bookings.Remove(bookingToRemove2);
                BookingsShow.Remove(bookingToRemove2);
            }

            currBooking.IsApproved = true;
            BookingsShow.Remove(currBooking);
            Db.SaveChanges();

        }

        private void OnSearchCommand(object param)
        {
            BookingsShow.Clear();
            if(SearchText !=  string.Empty)
            {
                foreach(var booking in Bookings)
                {
                    string name = Db.Users.FirstOrDefault(u => u.UserID == booking.User).Login;
                    if (name.Contains(SearchText))
                    {
                        BookingsShow.Add(booking);
                    }
                }
            }
            else
            {
                foreach (var booking in Bookings)
                {
                    BookingsShow.Add(booking);
                }
            }
        }

        public void AddBookings(Booking booking)
        {
            Bookings.Add(booking);
            BookingsShow.Add(booking);
            BookingsUser.Add(booking);

            OnPropertyChanged("BookingsUser");
        }

        private void LoadData()
        {
            Db.Users.Load();
            Db.Admins.Load();
            Db.Bookings.Load();
            Db.Bookings.Include((m) => m.Mission).Load();
            Db.Bookings.Include((m) => m.Tour).Load();

            if (User != null)
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
            }
            try { Db.Attach(Bookings); } catch { }
        }
        public BaseCommand EditProfileCommand { get;}
        public BaseCommand OnDeleteBookingCommand { get;}
        public BaseCommand OnUpproveCommand { get;}
        public BaseCommand SearchCommand { get;}
        public ProfileViewModel()
        {
            LoadData();
            this.navigate = navigate;
            foreach (var booking in Db.Bookings)
            {
                if (booking.IsActive == true)
                {
                    if(((booking.Tour != null && booking.Tour.IsActive == true) || booking.Mission != null) && booking.IsApproved == false)
                    {
                        Bookings.Add(booking);
                        BookingsShow.Add(booking);
                        if(booking.User == Global.CurrentUser.UserID)
                        {
                            BookingsUser.Add(booking);
                        }
                    }
                        
                }
                else if(booking.IsActive == false && booking.IsApproved == false)
                {
                    BookingsDeny.Add(booking);
                }
            }

            if(User != null)
            {
                CurrPerson = "User";
                UserName = Global.CurrentUser.Login;
            }
            else
            {
                CurrPerson = "Admin";
            }
            EditProfileCommand = new BaseCommand(OnEditCommand, (obj) => true);
            OnDeleteBookingCommand = new BaseCommand(DeleteBookingCommand, (obj) => true);
            OnUpproveCommand = new BaseCommand(ApproveCommand, (obj) => true);
            SearchCommand = new BaseCommand(OnSearchCommand, (obj) => true);
        }
    }
}
