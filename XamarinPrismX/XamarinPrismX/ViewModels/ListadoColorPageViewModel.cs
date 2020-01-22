using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using XamarinPrismX.Services;

namespace XamarinPrismX.ViewModels
{
    public class ListadoColorPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        public ListadoColorPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            loadData();
        }

        public async void loadData()
        {
            try {
                var url = App.Current.Resources["UrlAPI"].ToString();
                var response = await _apiService.GetPantone(url, "api", "/unknown");
                if (!response.IsSuccess)
                {
                    //IsRunning = false;
                    //CustomDialog.ShowAlert(_dialogService, "Error", response.Message.ToString());
                    
                    return;
                }

                var _data = response.Result;
            }             
            catch(Exception ex)
            {
                //IsRunning = false;
                var msg = ex.Message;
                //IsVisible = true;
                //Aqui creo que enviaria el mensaje de error.|
            }
        }


    }
}
