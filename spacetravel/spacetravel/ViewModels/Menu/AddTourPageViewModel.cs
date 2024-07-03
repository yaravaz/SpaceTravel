using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using spacetravel.Command;
using spacetravel.Models;
using spacetravel.Models.Data;
using spacetravel.Utils;
using spacetravel.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace spacetravel.ViewModels.Menu
{
    internal class AddTourPageViewModel : ViewModel
    {
        private static ApplicationContext _db = new();
        public static ApplicationContext Db
        {
            get => _db ??= new ApplicationContext();
            private set => _db = value;
        }

        public bool edit = false; 

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
        private string _currImage = string.Empty;
        public string CurrImage
        {
            get => _currImage;
            set => Set(ref _currImage, value);
        }
        private string _selectedType = string.Empty;
        public string SelectedType
        {
            get => _selectedType;
            set => Set(ref _selectedType, value);
        }

        private DateTime _dateField = DateTime.Today;
        public DateTime DateField
        {
            get => _dateField;
            set => Set(ref _dateField, value);
        }
        private string _errorText;
        public string ErrorText
        {
            get => _errorText;
            set => Set(ref _errorText, value);
        }
        private string _btnTitle;
        public string BtnTitle
        {
            get => _btnTitle;
            set => Set(ref _btnTitle, value);
        }
        private Tour? _currTour = null;
        public Tour? CurrTour
        {
            get => _currTour;
            set => Set(ref _currTour, value);
        }

        public DateTime DateToday = DateTime.Today;

        private Action<Parameter> navigate;

        public BaseCommand GoBack { get; }
        public BaseCommand AddImageCommand { get; }
        public BaseCommand AddTourCommand { get; }

        private void ReturnMainPage(object name)
        {
            Parameter param = new Parameter()
            {
                PageName = "ToursPage"
            };
            navigate?.Invoke(param);
        }

        private void OnAddImageCommand(object param)
        {
            string imagePath = null;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.png; *.gif; *.bmp)|*.jpg; *.png; *.gif; *.bmp|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                imagePath = openFileDialog.FileName;
                CurrImage = imagePath;
            }
        }
        private void OnAddTourCommand(object param)
        {
            try
            {
                if (NameField.Trim() != string.Empty && DescriptionField.Trim() != string.Empty && AddressField.Trim() != string.Empty
                && PriceField.Trim() != string.Empty && DateField != null && SelectedType != string.Empty)
                {
                    if (NameField.Length < 50)
                    {
                        if (DescriptionField.Length < 1000)
                        {
                            if (AddressField.Length < 50)
                            {
                                if (DateField >= DateTime.Now.Date)
                                {
                                    if (Double.TryParse(PriceField, out double number) && Regex.IsMatch(PriceField, "^\\d+\\,\\d{2}$"))
                                    {
                                        if(float.Parse(PriceField) < 9999999)
                                        {
                                            if (edit)
                                            {
                                                Tour tourToEdit = Db.Tours.FirstOrDefault(t => t.TourID == CurrTour.TourID);
                                                tourToEdit.Name = NameField.Trim();
                                                tourToEdit.Description = DescriptionField.Trim();
                                                tourToEdit.Address = AddressField.Trim();
                                                tourToEdit.Price = float.Parse(PriceField.Trim());
                                                tourToEdit.Date = DateField;
                                                tourToEdit.Image = CurrImage;
                                                tourToEdit.Type = SelectedType;
                                                Db.SaveChanges();
                                                NameField = string.Empty;
                                                DescriptionField = string.Empty;
                                                PriceField = string.Empty;
                                                AddressField = string.Empty;
                                                DateField = DateTime.Today;
                                                ErrorText = string.Empty;
                                                MessageBox.Show("success");
                                            }
                                            else
                                            {
                                                Db.Tours.Add(new Tour
                                                {
                                                    Name = NameField,
                                                    Description = DescriptionField,
                                                    Address = AddressField,
                                                    Price = float.Parse(PriceField),
                                                    Date = DateField,
                                                    Image = CurrImage,
                                                    Type = SelectedType,
                                                    IsActive = true
                                                });
                                                Db.SaveChanges();
                                                NameField = string.Empty;
                                                DescriptionField = string.Empty;
                                                PriceField = string.Empty;
                                                AddressField = string.Empty;
                                                SelectedType = string.Empty;
                                                CurrImage = string.Empty;
                                                SelectedType = string.Empty;
                                                DateField = DateTime.Today;
                                                ErrorText = string.Empty;
                                                MessageBox.Show("success");
                                            }
                                        }
                                        else
                                        {
                                            ErrorText = "It's not worth it.";

                                        }
                                    }
                                    else
                                    {
                                        ErrorText = "the price must be a number, the fractional part(2) with the comma";
                                    }
                                }
                                else
                                {
                                    ErrorText = "we can't travel back in time yet";
                                }
                            }
                            else
                            {
                                ErrorText = "the address id too long";
                            }
                        }
                        else
                        {
                            ErrorText = "the description is too long";
                        }
                    }
                    else
                    {
                        ErrorText = "the name is too long";
                    }
                }
                else
                {
                    ErrorText = "empty fields";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public AddTourPageViewModel(Action<Parameter> nav, int? tourID)
        {
            Db.Bookings.Load();
            Db.Bookings.Include((m) => m.Mission).Load();
            Db.Bookings.Include((m) => m.Tour).Load();
            GoBack = new BaseCommand(ReturnMainPage, (obj) => true);
            AddImageCommand = new BaseCommand(OnAddImageCommand, (obj) => true);
            AddTourCommand = new BaseCommand(OnAddTourCommand, (obj) => true);
            BtnTitle = "Add";
            if(tourID != 0)
            {
                edit = true;
                CurrTour = Db.Tours.FirstOrDefault((tour)=> tour.TourID == tourID);
                NameField = CurrTour.Name;
                CurrImage = CurrTour.Image;
                AddressField= CurrTour.Address;
                DescriptionField = CurrTour.Description;
                PriceField = CurrTour.Price.ToString();
                DateField = CurrTour.Date;
                SelectedType = CurrTour.Type;
                BtnTitle = "Edit";
            }
            navigate = nav;
        }
    }
}
