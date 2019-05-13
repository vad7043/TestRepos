using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary3.Components;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClassLibrary3
{
    public class Functions
    {
        public  AuthResult Authorization(string login, string api, string adress)
        {
            var data = new NameValueCollection()
            {
                { "USER_LOGIN",login },
                { "USER_HASH",api },
            };
            using (var webClient = new CookieWebClient())
            {
                AuthResult ar = new AuthResult();
                ar.Response = new AuthResultResponse();
                var response = webClient.UploadValues(adress, data);
                string stringResponse = Encoding.UTF8.GetString(response);
                dynamic resultDynamic = JObject.Parse(stringResponse);
                ar.Response.auth = resultDynamic.response.auth;
                ar.Cookie = webClient.CookieContainer.GetCookies(new Uri(adress));
                return ar;
            }
        }
        public string AddTask(AmoApiAddTask task, string adress, CookieCollection cookie)
        {
            var data1 = JsonConvert.SerializeObject(new AmoModel()
            {
                add = new[]
                   {
                         task
                    }
            });
            var a = getJson(adress, data1, cookie);
            return a;
        }
        public static string getJson(string urlPath, string inputJson, CookieCollection cookie)
        {
            var data = Encoding.UTF8.GetBytes(inputJson);
            var request = (HttpWebRequest)WebRequest.Create(urlPath);

            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(cookie);

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
                stream.Close();
            }

            string _stringResponse = "";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    _stringResponse = reader.ReadToEnd();
                }
                response.Close();
            }
            return _stringResponse;
        }
    }
}
