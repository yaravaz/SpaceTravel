using spacetravel.Command;
using spacetravel.Utils;
using spacetravel.ViewModels.Menu.MissionsPrev;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace spacetravel.ViewModels.Menu
{
    internal class MissionsViewModel : ViewModel
    {
        private object _previewVM;
        public object PreviewVM
        {
            get => _previewVM;
            set => Set(ref _previewVM, value);
        }



        public BaseCommand ShowPreviewCommand { get; }

        private void PreviewPage(object obj)
        {
            Parameter param = new Parameter()
            {
                PageName = (string)obj
            };
            switch (param.PageName)
            {
                case "Def":
                    PreviewVM = new DefViewModel();
                    break;
                case "Iis":
                    PreviewVM = new IssViewModel();
                    break;
                case "Orbit":
                    PreviewVM = new OrbitViewModel();
                    break;
                case "Moon":
                    PreviewVM = new MoonViewModel();
                    break;
                case "Mars":
                    PreviewVM = new MarsViewModel();
                    break;
                default:
                    break;
            }
        }
        private void OnChangePageCommand(object p)
        {
            Parameter param = new Parameter()
            {
                PageName = p.ToString()
            };
            navigate?.Invoke(param);
        }
        private Action<Parameter> navigate;
        public BaseCommand ChangePageCommand { get; }
        public MissionsViewModel(Action<Parameter> navigate)
        {
            this.navigate = navigate;   
            PreviewVM = new DefViewModel();
            ShowPreviewCommand = new BaseCommand(PreviewPage, (obj) => true);
            ChangePageCommand = new(OnChangePageCommand, (obj) => true);
        }
    }
}
