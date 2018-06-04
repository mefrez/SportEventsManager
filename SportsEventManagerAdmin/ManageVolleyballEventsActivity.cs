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
    [Activity(Label = "Manage Volleyball Events", Theme = "@style/AppTheme")]
    public class ManageVolleyballEventsActivity : AppCompatActivity
    {
        private ListView volleyballEventslistView;

        private List<Volleyball> allVolleyballEvents = new List<Volleyball>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.manage_volleyball_events_layout);

            volleyballEventslistView = FindViewById<ListView>(Resource.Id.volleyballEventslistView);

            GetVolleyballMatches();

            // Create your application here

            volleyballEventslistView.ItemClick += EventsListView_ItemClick;
        }

        private void EventsListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var volleyball = allVolleyballEvents[e.Position];

            var intent = new Intent();

            intent.SetClass(this, typeof(VolleyballEventDetailsActivity));

            intent.PutExtra("volleyballEventId", volleyball.Id);

            StartActivityForResult(intent, 100);

        }

        private async void GetVolleyballMatches()
        {
            string volleyballEventsJson = await RestService.Get("volleyball/get");

            allVolleyballEvents = JsonConvert.DeserializeObject<List<Volleyball>>(volleyballEventsJson);

            volleyballEventslistView.Adapter = new VolleyballEventsAdapter(this, allVolleyballEvents);

        }
    }
}