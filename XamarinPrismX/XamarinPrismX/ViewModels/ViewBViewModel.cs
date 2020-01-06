using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XamarinPrismX.ViewModels
{
    public class ViewBViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _navigateCommand;
        private DelegateCommand _navigateCommand2;
        public DelegateCommand NavigateCommand => _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));
        public DelegateCommand NavigateCommand2 => _navigateCommand2 ?? (_navigateCommand2 = new DelegateCommand(ExecuteNavigateCommand2));

        public ViewBViewModel(INavigationService navigationService):base(navigationService)
        {
            _navigationService = navigationService;
            Title = "Mi vista A :)";
        }



        async void ExecuteNavigateCommand()
        {
            await _navigationService.NavigateAsync("MainPage");

            //Puede seri asi tambien
            //Nota importante este es un ejemplo simple, en el comentario de abajo hay otro ejemploe
            // await _navigationService.NavigateAsync("MainPage"); //creo que es para cuando en app.xaml esta asi var result = await NavigationService.NavigateAsync("NavigationPage/Vista1x");
        }

        async void ExecuteNavigateCommand2()
        {
            //en lugar de mainpage puede ser cualquier otra vista, pero como no he crado otra vista, lo deje en mainpage
            await _navigationService.NavigateAsync("MainPage");
        }

    }
}
