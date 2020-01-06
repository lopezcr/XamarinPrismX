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
        public ViewBViewModel(INavigationService navigationService):base(navigationService)
        {
            Title = "Mi vista A :)";
        }
    }
}
