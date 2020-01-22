using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinPrismX.Helpers;

namespace XamarinPrismX.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _navigateCommand;
        private DelegateCommand _cerrarSessionCommand;
        private DelegateCommand _listadoColorCommand;
        public DelegateCommand NavigateCommand => _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));
        public DelegateCommand CerrarSesionCommand => _cerrarSessionCommand ?? (_cerrarSessionCommand = new DelegateCommand(ExecuteCerrarSesion));
        public DelegateCommand ListadoColoresCommand => _listadoColorCommand ?? (_listadoColorCommand = new DelegateCommand(listadoColorExecute));
        
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

    }
}
