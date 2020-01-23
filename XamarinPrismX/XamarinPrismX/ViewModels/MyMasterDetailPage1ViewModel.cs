using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using XamarinPrismX.Model;

namespace XamarinPrismX.ViewModels
{
    public class MyMasterDetailPage1ViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public ObservableCollection<MenuItemViewModel> Menus { get; set; }
        public MyMasterDetailPage1ViewModel(INavigationService navigationService):base(navigationService)
        {
            _navigationService = navigationService;
            LoadMenus();

        }


        private void LoadMenus()
        {
            var menus = new List<Menu>
            {
                new Menu
                {
                    Icon = "menu.png",
                    PageName = "MainPage",
                    Title = "Menú",
                    Index = 0
                },
                new Menu
                {
                    Icon = "encuesta.png",
                    PageName = "MainPage",
                    Title = "Encuesta",
                    Index = 1
                },
                new Menu
                {
                    Icon = "eventos.png",
                    PageName = "MainPage",
                    Title = "Eventos",
                    Index = 2
                },
                new Menu
                {
                    Icon = "noticias.png",
                    PageName = "NoticiasPage",
                    Title = "Noticias",
                    Index = 3
                },
                new Menu
                {
                    Icon = "noticias.png",
                    PageName = "ViewB",
                    Title = "View B",
                    Index = 3
                }
            };

            Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel(_navigationService)
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title,
                    Index = m.Index
                }).ToList());
        }


    }
}
