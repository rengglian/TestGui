using Prism.Mvvm;
using Prism.Regions;

namespace TestGui.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        private string _title = "Chiller Test GUI";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }        
    }
}
