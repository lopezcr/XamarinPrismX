using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XamarinPrismX.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private string _errorTextEmail;
        private bool _hasErrorEmail;
        private string _email;
        private DelegateCommand _MainCommand;

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
        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
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

            var result = await NavigationService.NavigateAsync("/NavigationPage/MainPage");
        }

    }
}
