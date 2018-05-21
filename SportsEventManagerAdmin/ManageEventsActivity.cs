using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using SportsEventManagerAdmin.Adapters;
using SportsEventManagerAdmin.Models;
using SportsEventManagerAdminApp.Services;

namespace SportsEventManagerAdmin
{
    [Activity(Label = "Manage Events", Theme = "@style/AppTheme")]
    public class ManageEventsActivity : AppCompatActivity
    {
        private ListView eventsListView;

        private List<Football> allFootballEvents = new List<Football>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.manage_events_layout);

            eventsListView = FindViewById<ListView>(Resource.Id.eventslistView);

            GetFootballMatches();          
        }

        private async void GetFootballMatches()
        {
            string footballEventsJson = await RestService.Get("football/get");

            allFootballEvents = JsonConvert.DeserializeObject<List<Football>>(footballEventsJson);

            eventsListView.Adapter = new FootballEventsAdapter(this, allFootballEvents);

        }
    }
}