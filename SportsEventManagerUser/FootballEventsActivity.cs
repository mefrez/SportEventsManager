using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using SportsEventManagerUser.Adapters;
using SportsEventManagerUser.Models;
using SportsEventManagerUser.Services;

namespace SportsEventManagerUser
{
    [Activity(Label = "Football Events Activity")]
    public class FootballEventsActivity : Activity
    {
        private ListView eventsListView;

        private List<Football> allFootballEvents = new List<Football>();

        private Button refreshButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.events_layout);

            eventsListView = FindViewById<ListView>(Resource.Id.eventslistView);

            GetFootballMatches();

            refreshButton = FindViewById<Button>(Resource.Id.refreshButton);

            refreshButton.Click += RefreshButton_Click;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
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