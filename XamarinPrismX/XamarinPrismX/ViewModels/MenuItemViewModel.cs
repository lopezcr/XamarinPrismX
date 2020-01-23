using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinPrismX.Model;


namespace XamarinPrismX.ViewModels
{
    public class MenuItemViewModel : Menu
    {

        private readonly INavigationService _navigationService;
        private DelegateCommand _selectMenuCommand;

        public MenuItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectMenuCommand => _selectMenuCommand ?? (_selectMenuCommand = new DelegateCommand(SelectMenu));

        private async void SelectMenu()
        {
            //Aqui hay que corregir algo para navegar mejor y regresar, pero hay va :)
            await _navigationService.NavigateAsync($"NavigationPage/{PageName}");
        }
    }
}
