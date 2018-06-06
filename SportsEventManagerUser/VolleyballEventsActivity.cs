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
    [Activity(Label = "VolleyballEventsActivity")]
    public class VolleyballEventsActivity : Activity
    {
        private ListView eventsListView;

        private List<Volleyball> allVolleyballEvents = new List<Volleyball>();

        private Button refreshButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.events_layout);

            eventsListView = FindViewById<ListView>(Resource.Id.eventslistView);

            GetVolleyballMatches();

            refreshButton = FindViewById<Button>(Resource.Id.refreshButton);

            refreshButton.Click += RefreshButton_Click;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            GetVolleyballMatches();
        }

        private async void GetVolleyballMatches()
        {
            string volleyballEventsJson = await RestService.Get("volleyball/get");

            allVolleyballEvents = JsonConvert.DeserializeObject<List<Volleyball>>(volleyballEventsJson);

            eventsListView.Adapter = new VolleyballEventsAdapter(this, allVolleyballEvents);

        }
    }
}