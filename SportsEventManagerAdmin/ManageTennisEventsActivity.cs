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

            eventsListView.ItemClick += EventsListView_ItemClick;
        }

        private void EventsListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var tennis = allTennisEvents[e.Position];

            var intent = new Intent();

            intent.SetClass(this, typeof(TennisEventDetailsActivity));

            intent.PutExtra("tennisEventId", tennis.Id);

            StartActivityForResult(intent, 100);

        }

        private async void GetTennisMatches()
        {
            string tennisEventsJson = await RestService.Get("tennis/get");

            allTennisEvents = JsonConvert.DeserializeObject<List<Tennis>>(tennisEventsJson);

            eventsListView.Adapter = new TennisEventsAdapter(this, allTennisEvents);

        }
    }
}