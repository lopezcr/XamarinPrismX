﻿using Prism;
using Prism.Ioc;
using XamarinPrismX.ViewModels;
using XamarinPrismX.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinPrismX.Services;
using XamarinPrismX.Helpers;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinPrismX
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            if (Settings.IsLogin == true)
            {
                //var result = await NavigationService.NavigateAsync("/NavigationPage/MainPage");
            }
            else
            {
                //await NavigationService.NavigateAsync("/Login");
            }

            var result = await NavigationService.NavigateAsync("/NavigationPage/MainPage");
            //await NavigationService.NavigateAsync("NavigationPage/Login");
            //await NavigationService.NavigateAsync("NavigationPage/Expanding");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewB, ViewBViewModel>();
            containerRegistry.RegisterForNavigation<Principal, PrincipalViewModel>();
            containerRegistry.RegisterForNavigation<VistaC, VistaCViewModel>();
            containerRegistry.RegisterForNavigation<Login, LoginViewModel>();

            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<ListadoColorPage, ListadoColorPageViewModel>();
            containerRegistry.RegisterForNavigation<PantoneColorDetalle, PantoneColorDetalleViewModel>();
            containerRegistry.RegisterForNavigation<CarouselSimple, CarouselSimpleViewModel>();
            containerRegistry.RegisterForNavigation<CarouselDiferenteTemplate, CarouselDiferenteTemplateViewModel>();
            containerRegistry.RegisterForNavigation<MyMasterDetailPage1, MyMasterDetailPage1ViewModel>();
            containerRegistry.RegisterForNavigation<ContentPageVMD, ContentPageVMDViewModel>();            
            containerRegistry.RegisterForNavigation<CollectionViewGrouping, CollectionViewGroupingViewModel>();
            containerRegistry.RegisterForNavigation<Expanding, ExpandingViewModel>();
        }
    }
}
