using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace AnPan.Web
{
    public static class ApiHelper<T>
    {
        public static string ApiUrl = ConfigurationManager.AppSettings["ApiUrl"].ToString();

        //static ApiHelper()
        //{
        //    ApiUrl = ConfigurationManager.AppSettings["ApiUrl"].ToString();
        //}

        public static String Get(string postUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = client.GetStringAsync(ApiUrl+postUrl).Result.Replace("\\", "").TrimStart('"').TrimEnd('"');
                return content;
            }
        }

        public static List<T> GetModel(string postURL)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = client.GetStringAsync(ApiUrl+postURL).Result.Replace("\\", "").TrimStart('"').TrimEnd('"');
                return JsonConvert.DeserializeObject<List<T>>(content);
            }
        }

        public static T GetEntity(string postURL)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = client.GetStringAsync(ApiUrl + postURL).Result.Replace("\\", "").TrimStart('"').TrimEnd('"');
                return JsonConvert.DeserializeObject<T>(content);
            }
        }

        public static String Post(string action, string postString)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpContent content = new StringContent(postString);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = client.PostAsync(ApiUrl+action, content).Result;
                if (response != null)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var resultValue = response.Content.ReadAsStringAsync().Result;
                        string strResponse = HttpUtility.UrlDecode(resultValue.ToString()).Replace("\\", "").TrimStart('"').TrimEnd('"');
                        return strResponse;
                    }
                }
                return String.Empty;
            }
        }
    }
}