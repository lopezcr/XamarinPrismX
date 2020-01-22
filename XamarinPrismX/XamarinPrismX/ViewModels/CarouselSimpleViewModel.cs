using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using XamarinPrismX.Services;

namespace XamarinPrismX.ViewModels
{
    public class CarouselSimpleViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private List<PantoneColorViewModel> _listaColores;
        public List<PantoneColorViewModel> ListaColores
        {
            get => _listaColores;
            set => SetProperty(ref _listaColores, value);
        }

        public CarouselSimpleViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            loadData();
        }

        public async void loadData()
        {                        
            try
            {
                var url = App.Current.Resources["UrlAPI"].ToString();
                var response = await _apiService.GetPantone(url, "api", "/unknown");
                if (!response.IsSuccess)
                {
                    return;
                }

                ListaColores = new List<PantoneColorViewModel>(
                    response.Result.data.Select(x => new PantoneColorViewModel(_navigationService)
                    {
                        color = x.color,
                        id = x.id,
                        Image = x.Image,
                        name = x.name
                    })
                    ).ToList();
                
            }
            catch (Exception ex)
            {              
                var msg = ex.Message;
                //Aqui creo que enviaria el mensaje de error.|
            }
        }

    }
}
