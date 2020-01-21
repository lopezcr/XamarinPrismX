using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinPrismX.Model;

namespace XamarinPrismX.Services
{
    public class ApiService : IApiService
    {

        public async Task<Response<LoginResponse>> GetLoginAsync(string urlBase, string servicePrefix, string controller, LoginRequest request)
        {
            try
            {

                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                var url = $"{urlBase}/{servicePrefix}{controller}";
                var requestString = JsonConvert.SerializeObject(request);
                var content = new StringContent(requestString, Encoding.UTF8, "application/json");
                //builder.Query = string.Format("email={0}&password={1}", request.Email, request.Password);

                var response = await client.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response<LoginResponse>
                    {
                        IsSuccess = false,
                        Message = JsonConvert.DeserializeObject<string>(result)
                    };
                }

                var token = JsonConvert.DeserializeObject<LoginResponse>(result);
                return new Response<LoginResponse>
                {
                    IsSuccess = true,
                    Result = token
                };
            }
            catch (Exception ex)
            {
                string msgError;
                switch (ex.Message)
                {
                    case "No such host is known":
                        msgError = "No se encontro el servidor";
                        break;
                    default:
                        msgError = "No se pudo conectar al servidor";
                        break;
                }
                return new Response<LoginResponse>
                {
                    IsSuccess = false,
                    Message = msgError
                };
            }
        }

    }
}
