using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AKQA.Website.Common
{
    public static class RequestHelper
    {
        private static readonly HttpClient Client = new HttpClient();
        public static T GetRestResponse<T>(string url)
        {
            string _token = GetHttpResponseMessage<string>(Helper.GetTokenUrl(), null);
            return GetHttpResponseMessage<T>(url, _token);
        }

        private static T GetHttpResponseMessage<T>(string url, string token)
        {
            var response = default(T);
            using (HttpRequestMessage request = new HttpRequestMessage())
            {

                var uriBuilder = new UriBuilder(url);

                request.RequestUri = uriBuilder.Uri;
                request.Method = HttpMethod.Get;
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constant.AwsHeaderAuthScheme, apiToken.Authorization);
                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                using (var result = Client.SendAsync(request).Result)
                {
                    if (result.IsSuccessStatusCode)
                    {
                        response = ProcessResponse<T>(result);
                    }
                }
            }

            return response;
        }

        private static T ProcessResponse<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                //Logger.Debug("Process response result : {0}", result);
                var objectResponse = Helper.ToObject<T>(result);
                return objectResponse;
            }
            else
            {
                //error handling 
                throw new Exception("Error fetching Rest Response. Please check log file.");
            }

        }
    }
}
