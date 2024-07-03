using spacetravel.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace spacetravel.ViewModels
{
    public class MessageViewModel : ViewModel
    {
        private string _messageText;
        public string MessageText
        {
            get => _messageText;
            set => Set(ref _messageText, value);
        }

        private void CloseWinCommand(object p)
        {
            Application.Current.MainWindow.Close();
        }

        public BaseCommand OnCloseWinCommand { get; }

        public MessageViewModel()
        {
            OnCloseWinCommand = new BaseCommand(CloseWinCommand, (obj) => true);
        }
    }
}
