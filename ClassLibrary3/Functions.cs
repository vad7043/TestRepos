using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        public bool AutorizationFunc(string User_login, string User_Hash, string User_url)
        {
            using (var webClient = new WebClient())
            {
                var pars = new NameValueCollection();
                pars.Add("USER_LOGIN", User_login);
                pars.Add("USER_HASH", User_Hash);
                var response = webClient.UploadValues(User_url, pars);
                string str = Encoding.UTF8.GetString(response);
                dynamic resultDynamic = JObject.Parse(str);
                return resultDynamic.response.auth;
            }
        }
        public string AddTask(string User_login, string User_Hash, string User_url)
        {
            using (var webClient = new CookieWebClient())
            {
                var pars = new NameValueCollection();
                pars.Add("USER_LOGIN", User_login);
                pars.Add("USER_HASH", User_Hash);
                var response = webClient.UploadValues(User_url, pars);
                string str = Encoding.UTF8.GetString(response);
                dynamic resultDynamic = JObject.Parse(str);

                var newAmoTask = new AmoApiAddTask
                {
                    element_id = 185241,
                    element_type = 2,
                    complete_till_at = (long)(DateTime.UtcNow.Subtract(new DateTime(2019, 1, 1))).TotalSeconds,
                    task_type = 1,
                    text = "qwe",
                    created_at = (long)(DateTime.UtcNow.Subtract(new DateTime(2019, 1, 1))).TotalSeconds,
                    updated_at = (long)(DateTime.UtcNow.Subtract(new DateTime(2019, 1, 1))).TotalSeconds,
                    responsible_user_id = 3455599,
                    created_by = 3455599,
                };
                var data1 = JsonConvert.SerializeObject(new AmoModel()
                {
                    add = new[]
                    {
                         newAmoTask
                    }
                });
                var response1 = webClient.UploadString("https://vad7043.amocrm.ru/private/api/v2/json/tasks", data1);
                return response1;
            }
        }
    }
}
