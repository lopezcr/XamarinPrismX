using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinPrismX.Model;

namespace XamarinPrismX.Services
{
    public interface IApiService
    {
        Task<Response<LoginResponse>> GetLoginAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            LoginRequest request
         );

        Task<Response<PantoneResponse>> GetPantone(
            string urlBase,
            string servicePrefix,
            string controller            
         );


    }



}
