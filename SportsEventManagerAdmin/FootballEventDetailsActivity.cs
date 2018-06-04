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

        private Button homeTeamScoreAdd;
        private Button homeTeamScoreSubstract;

        private Button awayTeamScoreAdd;
        private Button awayTeamScoreSubstract;

        private Button updateButton;


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

            HandleEvents();

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

            homeTeamScoreAdd = FindViewById<Button>(Resource.Id.homeTeamScoreAdd);
            homeTeamScoreSubstract = FindViewById<Button>(Resource.Id.homeTeamScoreSubstract);

            awayTeamScoreAdd = FindViewById<Button>(Resource.Id.awayTeamScoreAdd);
            awayTeamScoreSubstract = FindViewById<Button>(Resource.Id.awayTeamScoreSubstract);

            updateButton = FindViewById<Button>(Resource.Id.updateButton);

        }

        private void HandleEvents()
        {
            homeTeamScoreAdd.Click += HomeTeamScoreAdd_Click;
            homeTeamScoreSubstract.Click += HomeTeamScoreSubstract_Click;
            awayTeamScoreAdd.Click += AwayTeamScoreAdd_Click;
            awayTeamScoreSubstract.Click += AwayTeamScoreSubstract_Click;
            updateButton.Click += UpdateButton_Click;
        }

        private void AwayTeamScoreSubstract_Click(object sender, EventArgs e)
        {
            int score = Convert.ToInt32(awayTeamScore.Text);

            if (score >= 1)
            {
                score--;
            }

            awayTeamScore.Text = score.ToString();
        }

        private void AwayTeamScoreAdd_Click(object sender, EventArgs e)
        {
            int score = Convert.ToInt32(awayTeamScore.Text);

            score++;

            awayTeamScore.Text = score.ToString();

        }

        private void HomeTeamScoreSubstract_Click(object sender, EventArgs e)
        {
            int score = Convert.ToInt32(homeTeamScore.Text);

            if (score >= 1)
            {
                score--;
            }
            homeTeamScore.Text = score.ToString();
        }

        private void HomeTeamScoreAdd_Click(object sender, EventArgs e)
        {
            int score = Convert.ToInt32(homeTeamScore.Text);

            score++;

            homeTeamScore.Text = score.ToString();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            footballEvent.HostScore = Convert.ToInt32(homeTeamScore.Text);
            footballEvent.GuestScore = Convert.ToInt32(awayTeamScore.Text);

            Update(footballEvent, footballEventId);
        }

        private async void Update(Football football, int id)
        {
            updateButton.Enabled = false;
            football.EventId = id;

            HttpResponseMessage footballMessage = await RestService.Post(football, "football/update");

            updateButton.Enabled = true;
        }
    }
}