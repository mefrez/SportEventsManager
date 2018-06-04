using System;
using System.Collections.Generic;
using System.Linq;
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
    [Activity(Label = "Manage Tennis Events", Theme = "@style/AppTheme")]
    public class ManageTennisEventsActivity : AppCompatActivity
    {
        private ListView eventsListView;

        private List<Tennis> allTennisEvents = new List<Tennis>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.manage_tennis_events_layout);

            eventsListView = FindViewById<ListView>(Resource.Id.tenniseventslistView);

            GetTennisMatches();

            // Create your application here
        }

        private async void GetTennisMatches()
        {
            string tennisEventsJson = await RestService.Get("tennis/get");

            allTennisEvents = JsonConvert.DeserializeObject<List<Tennis>>(tennisEventsJson);

            eventsListView.Adapter = new TennisEventsAdapter(this, allTennisEvents);

        }
    }
}