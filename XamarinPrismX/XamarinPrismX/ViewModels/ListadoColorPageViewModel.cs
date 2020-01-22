using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using XamarinPrismX.Model;
using XamarinPrismX.Services;

namespace XamarinPrismX.ViewModels
{
    public class ListadoColorPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private List<PantoneColorViewModel> _listaColores;

        private bool _isRunning;
 
        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public List<PantoneColorViewModel> ListaColores
        {
            get => _listaColores;
            set => SetProperty(ref _listaColores, value);
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
            //ListaColores = new List<PantoneColorViewModel>();
            try
            {
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

                ListaColores = new List<PantoneColorViewModel>(
                    response.Result.data.Select(x=> new PantoneColorViewModel(_navigationService) {
                        color = x.color,
                        id = x.id,
                        Image = x.Image,
                        name = x.name
                    })
                    ).ToList();
                

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
