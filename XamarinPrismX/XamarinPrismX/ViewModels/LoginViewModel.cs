﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var request = new LoginRequest
            {
                 email = Email,
                 password = Password
            };

            var url = App.Current.Resources["UrlAPI"].ToString();
            var response = await _apiService.GetLoginAsync(url, "api", "/login", request);
                       

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message.ToString(), "Ok");
                //CustomDialog.ShowAlert(_dialogService, "Error", response.Message.ToString());
                return;
            }


            var result = await NavigationService.NavigateAsync("/NavigationPage/MainPage");
        }

    }
}
