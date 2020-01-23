using Prism.Commands;
using Prism.Navigation;
using XamarinPrismX.Helpers;

namespace XamarinPrismX.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _navigateCommand;
        private DelegateCommand _cerrarSessionCommand;
        private DelegateCommand _listadoColorCommand;
        private DelegateCommand _masterDetailCommand;
        public DelegateCommand NavigateCommand => _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));
        public DelegateCommand CerrarSesionCommand => _cerrarSessionCommand ?? (_cerrarSessionCommand = new DelegateCommand(ExecuteCerrarSesion));
        public DelegateCommand ListadoColoresCommand => _listadoColorCommand ?? (_listadoColorCommand = new DelegateCommand(listadoColorExecute));
        public DelegateCommand MasterDetailContentPAgeCommand => _masterDetailCommand ?? (_masterDetailCommand = new DelegateCommand(MasterDetailExecute));
        
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            this._navigationService= navigationService;
        }

        async void ExecuteNavigateCommand()
        {
            await _navigationService.NavigateAsync("ViewB");
            //await _navigationService.GoBackAsync();
        }
        
        async void ExecuteCerrarSesion()
        {
            Settings.IsLogin = false;
            Settings.User = string.Empty;
            await _navigationService.NavigateAsync("/Login");
        }

        async void listadoColorExecute()
        {
            await _navigationService.NavigateAsync("ListadoColorPage");
        }

        async void MasterDetailExecute()
        {
            await NavigationService.NavigateAsync($"MyMasterDetailPage1/NavigationPage/ContentPageVMD");
        }

    }
}
