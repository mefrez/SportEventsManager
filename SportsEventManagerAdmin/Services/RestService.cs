using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using static Android.Provider.SyncStateContract;
using SportsEventManagerAdmin.Models;

namespace SportsEventManagerAdminApp.Services
{
    public static class RestService
    {
        private const string _url = "https://sporteventsmanager.azurewebsites.net/api/";

        public static async Task<HttpResponseMessage> Post(object item, string apiRoute)
        {

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var json = JsonConvert.SerializeObject(item);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage getResponse = await httpClient.PostAsync(_url + apiRoute, content);

                    return getResponse;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

        }

        public static async Task<string> Get(string apiRoute)
        {

            string responseJsonString = null;

            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage getResponse = await httpClient.GetAsync(_url + apiRoute);

                    responseJsonString = await getResponse.Content.ReadAsStringAsync();

                    return responseJsonString;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

        }
    }
}