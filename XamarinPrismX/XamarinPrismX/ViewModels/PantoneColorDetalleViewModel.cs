using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using XamarinPrismX.Model;

namespace XamarinPrismX.ViewModels
{    
    public class PantoneColorDetalleViewModel : ViewModelBase
    {
        private PantoneColor _colorPantone;

        public PantoneColor ColorPantone
        {
            get => _colorPantone;
            set => SetProperty(ref _colorPantone, value);
        }

        public PantoneColorDetalleViewModel(INavigationService navigationService):base(navigationService)
        {

        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("color"))
            {
                ColorPantone = parameters.GetValue<PantoneColor>("color");
            }
        }

    }
}
