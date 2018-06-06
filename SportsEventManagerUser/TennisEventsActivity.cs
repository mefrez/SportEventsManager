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
    [Activity(Label = "TennisEventsActivity")]
    public class TennisEventsActivity : Activity
    {
        private ListView eventsListView;

        private List<Tennis> allTennisEvents = new List<Tennis>();

        private Button refreshButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.events_layout);

            eventsListView = FindViewById<ListView>(Resource.Id.eventslistView);

            GetTennisMatches();

            refreshButton = FindViewById<Button>(Resource.Id.refreshButton);
            refreshButton.Click += RefreshButton_Click;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            GetTennisMatches();
        }

        private async void GetTennisMatches()
        {
            string tennisEventsJson = await RestService.Get("tennis/get");

            allTennisEvents = JsonConvert.DeserializeObject<List<Tennis>>(tennisEventsJson);

            eventsListView.Adapter = new TennisEventsAdapter(this, allTennisEvents);

        }
    }
}