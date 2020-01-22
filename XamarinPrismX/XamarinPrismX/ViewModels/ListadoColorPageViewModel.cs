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

        private bool _isRunning;
 
        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

 
        public ListadoColorPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            loadData();
        }

        public async void loadData()
        {
            IsRunning = true;          

            try {
                var url = App.Current.Resources["UrlAPI"].ToString();
                var response = await _apiService.GetPantone(url, "api", "/unknown");
                if (!response.IsSuccess)
                {
                    IsRunning = false;
                   
                    //CustomDialog.ShowAlert(_dialogService, "Error", response.Message.ToString());
                    return;
                }

                //Aqui cargo todo bien :)
                IsRunning = false;                
                var _data = response.Result;
            }             
            catch(Exception ex)
            {
                IsRunning = false;              
                var msg = ex.Message;
                
                //Aqui creo que enviaria el mensaje de error.|
            }
        }


    }
}
