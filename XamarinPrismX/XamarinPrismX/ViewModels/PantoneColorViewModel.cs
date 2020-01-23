using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinPrismX.Model;

namespace XamarinPrismX.ViewModels
{
    public class PantoneColorViewModel : PantoneColor
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectColorCommand;

        public DelegateCommand SelectColorCommand => _selectColorCommand ?? (_selectColorCommand = new DelegateCommand(ShowColor));
        public PantoneColorViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private async void ShowColor()
        {
            var parameters = new NavigationParameters();
            parameters.Add("color", this);

            //await _navigationService.NavigateAsync("PantoneColorDetalle");            
            await _navigationService.NavigateAsync("PantoneColorDetalle", parameters);            
        }

        public bool itemParSelectorTemplate {
            get {
                return (id % 2)==0 ? true : false;
            } 
        }
    }
}
