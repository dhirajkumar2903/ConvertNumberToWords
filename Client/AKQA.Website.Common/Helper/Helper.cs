using System;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

namespace AKQA.Website.Common
{
    public static class Helper
    {
        public static T ToObject<T>(string t)
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(T));
            // convert string to stream
            byte[] byteArray = Encoding.UTF8.GetBytes(t);
            using (var stream = new MemoryStream(byteArray))
                return (T)jsonSerializer.ReadObject(stream);
        }
        public static string ServiceUrl(string _serviceName)
        {
            StringBuilder _serviceUrl = new StringBuilder();
            _serviceUrl = _serviceUrl.Append(GetConfigValue(Constants.ServiceBaseUrl)).Append(GetConfigValue(_serviceName));
            return _serviceUrl.ToString();
        }

        public static string GetConfigValue(string _configKey)
        {
            return string.IsNullOrEmpty(ConfigurationManager.AppSettings[_configKey]) ? string.Empty : ConfigurationManager.AppSettings[_configKey];
        }

        public static string GetTokenUrl()
        {
            return HttpUtility.UrlDecode(string.Format(ServiceUrl(Constants.TokenServiceUrl), GetConfigValue(Constants.TokenUserName), GetConfigValue(Constants.TokenPassword)));
        }
    }
}
