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
using SportsEventManagerAdmin.Models;
using SportsEventManagerAdminApp.Services;

namespace SportsEventManagerAdmin
{
    [Activity(Label = "Manage Football Events", Theme = "@style/AppTheme")]
    public class FootballEventDetailsActivity : AppCompatActivity
    {
        public int footballEventId;

        Football footballEvent = new Football();

        private TextView homeTeamName;
        private TextView awayTeamName;

        private TextView homeTeamScore;
        private TextView awayTeamScore;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.football_details_layout);

            footballEventId = Intent.Extras.GetInt("footballEventId");

            // Create your application here

            GetFootballMatch();

        }

        private async void GetFootballMatch()
        {
            string footballEventJson = await RestService.Get("football/get/"+ footballEventId);

            footballEvent = JsonConvert.DeserializeObject<Football>(footballEventJson);

            FindViews();

            homeTeamName.Text = footballEvent.Event.HostName;
            awayTeamName.Text = footballEvent.Event.GuestName;

            homeTeamScore.Text = footballEvent.HostScore.ToString();
            awayTeamScore.Text = footballEvent.GuestScore.ToString();
        }

        private void FindViews()
        {
            homeTeamName = FindViewById<TextView>(Resource.Id.homeTeamTextView);
            awayTeamName = FindViewById<TextView>(Resource.Id.awayTeamTextView);

            homeTeamScore = FindViewById<TextView>(Resource.Id.homeTeamScoreTextView);
            awayTeamScore = FindViewById<TextView>(Resource.Id.awayTeamScoreTextView);

        }
    }
}