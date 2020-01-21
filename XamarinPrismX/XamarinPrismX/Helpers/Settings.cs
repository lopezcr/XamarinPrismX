using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinPrismX.Helpers
{
    class Settings
    {
        private const string _user = "USER";
        private const string _isLogin = "Login";
        private const string _news = "news";

        //private const string _token = "TOKEN";
        private static readonly string _stringDefault = string.Empty;
        private static readonly bool _boolDefault = false;


        private static ISettings AppSettings => CrossSettings.Current;

        public static string User
        {
            get => AppSettings.GetValueOrDefault(_user, _stringDefault);
            set => AppSettings.AddOrUpdateValue(_user, value);
        }

        public static bool IsLogin
        {
            get => AppSettings.GetValueOrDefault(_isLogin, _boolDefault);
            set => AppSettings.AddOrUpdateValue(_isLogin, value);
        }

        public static string News
        {
            get => AppSettings.GetValueOrDefault(_news, _stringDefault);
            set => AppSettings.AddOrUpdateValue(_news, value);
        }

        //public static string Token
        //{
        //    get => AppSettings.GetValueOrDefault(_token, _stringDefault);
        //    set => AppSettings.AddOrUpdateValue(_token, value);
        //}
    }
}
