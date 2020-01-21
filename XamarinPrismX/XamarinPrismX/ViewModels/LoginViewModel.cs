using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using XamarinPrismX.Helpers;
using XamarinPrismX.Model;
using XamarinPrismX.Services;
 

namespace XamarinPrismX.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private string _errorTextEmail;
        private bool _hasErrorEmail;
        private string _email;
        private DelegateCommand _MainCommand;
        private readonly IApiService _apiService;
        private string _password;
        private bool _isRunning;
        private bool _isEnable;

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string ErrorTextEmail
        {
            get => _errorTextEmail;
            set => SetProperty(ref _errorTextEmail, value);
        }

        public bool HasErrorEmail
        {
            get => _hasErrorEmail;
            set => SetProperty(ref _hasErrorEmail, value);
        }


        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnable
        {
            get => _isEnable;
            set => SetProperty(ref _isEnable, value);
        }




        public DelegateCommand LoginCommand => _MainCommand ?? (_MainCommand = new DelegateCommand(ExecuteLoginCommand));
        public LoginViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
        }

        async void ExecuteLoginCommand()
        {
            if (string.IsNullOrEmpty(Email))
            {
                ErrorTextEmail = "Es requerido";
                HasErrorEmail = true;
                return;
            }
            else
            {
                HasErrorEmail = false;
            }


            IsRunning = true;
            IsEnable = false;

            var request = new LoginRequest
            {
                 email = Email,
                 password = Password
            };

            var url = App.Current.Resources["UrlAPI"].ToString();
            var response = await _apiService.GetLoginAsync(url, "api", "/login", request);


            IsRunning = false;
            IsEnable = true;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message.ToString(), "Ok");
                //CustomDialog.ShowAlert(_dialogService, "Error", response.Message.ToString());
                return;
            }

            LoginResponse user = response.Result;
            Settings.User = JsonConvert.SerializeObject(user.Token);//en realidad en el ejemplo original era user.Cliente con varias propieades, como nombre, edad, etc, etc. Info del cliente, mi ejemplo es sencillo
            Settings.IsLogin = true;
            Application.Current.Properties["IsLoggedIn"] = Boolean.TrueString; //using Xamarin.Forms;


            var result = await NavigationService.NavigateAsync("/NavigationPage/MainPage");
        }

    }
}
