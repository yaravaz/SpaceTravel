using spacetravel.Command;
using spacetravel.Models.Data;
using spacetravel.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace spacetravel.ViewModels.Auth
{
    public class MainWindowViewModel : ViewModel
    { 
        private ContentControl _contentControlAuth;
        public ContentControl ContentControlAuth
        {
            get => _contentControlAuth;
            set => Set(ref _contentControlAuth, value);
        }
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

        public BaseCommand OnCloseAppCommand { get; }

        public MainWindowViewModel()
        {

            ContentControlAuth = new LoginForm();
            OnCloseAppCommand = new BaseCommand(CloseApp, (obj) => true);
            
        }
    }
}
