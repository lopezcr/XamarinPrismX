using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XamarinPrismX.ViewModels
{
    public class PrincipalViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand => _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));
        public PrincipalViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService; //hay que agregar este
        }

        async void ExecuteNavigateCommand()
        {
            var p = new NavigationParameters();
            p.Add("title", "Sere un titulo que va por parametro");
            await _navigationService.NavigateAsync("VistaC", p);         
        }


    }
}
