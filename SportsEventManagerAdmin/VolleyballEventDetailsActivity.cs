using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using SportsEventManagerAdmin.Models;
using SportsEventManagerAdminApp.Services;

namespace SportsEventManagerAdmin
{
    [Activity(Label = "Manage Volleyball Events", Theme = "@style/AppTheme")]
    public class VolleyballEventDetailsActivity : Activity
    {
        public int volleyballEventId;

        Volleyball volleyballEvent = new Volleyball();

        private TextView homeTeamName;
        private TextView awayTeamName;

        private TextView homeTeamScore;
        private TextView awayTeamScore;

        private TextView homeTeamSetScore;
        private TextView awayTeamSetScore;

        private Button homeTeamScoreAdd;
        private Button homeTeamScoreSubstract;

        private Button awayTeamScoreAdd;
        private Button awayTeamScoreSubstract;

        private Button updateButton;

        private int setCount;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.volleyball_details_layout);

            volleyballEventId = Intent.Extras.GetInt("volleyballEventId");

            // Create your application here

            GetVolleyballMatch();
        }

        private async void GetVolleyballMatch()
        {
            string volleyballEventJson = await RestService.Get("volleyball/get/" + volleyballEventId);

            volleyballEvent = JsonConvert.DeserializeObject<Volleyball>(volleyballEventJson);

            FindViews();

            HandleEvents();

            homeTeamSetScore.Text = volleyballEvent.HostSetScore.ToString();
            awayTeamSetScore.Text = volleyballEvent.GuestSetScore.ToString();

            homeTeamName.Text = volleyballEvent.Event.HostName;
            awayTeamName.Text = volleyballEvent.Event.GuestName;

            homeTeamSetScore.Text = volleyballEvent.HostSetScore.ToString();
            awayTeamSetScore.Text = volleyballEvent.GuestSetScore.ToString();

            setCount = volleyballEvent.HostSetScore + volleyballEvent.GuestSetScore;

            homeTeamScore.Text = volleyballEvent.HostScore.ToString();
            awayTeamScore.Text = volleyballEvent.GuestScore.ToString();

            
        }

        private void FindViews()
        {
            homeTeamName = FindViewById<TextView>(Resource.Id.volleyballHomeTeamTextView);
            awayTeamName = FindViewById<TextView>(Resource.Id.volleyballAwayTeamTextView);

            homeTeamScore = FindViewById<TextView>(Resource.Id.volleyballHomeTeamScoreTextView);
            awayTeamScore = FindViewById<TextView>(Resource.Id.volleyballAwayTeamScoreTextView);

            homeTeamSetScore = FindViewById<TextView>(Resource.Id.volleyballHomeSetScoreTextView);
            awayTeamSetScore = FindViewById<TextView>(Resource.Id.volleyballAwaySetScoreTextView);

            homeTeamScoreAdd = FindViewById<Button>(Resource.Id.volleyballHomeTeamScoreAdd);
            homeTeamScoreSubstract = FindViewById<Button>(Resource.Id.volleyballHomeTeamScoreSubstract);

            awayTeamScoreAdd = FindViewById<Button>(Resource.Id.volleyballAwayTeamScoreAdd);
            awayTeamScoreSubstract = FindViewById<Button>(Resource.Id.volleyballAwayTeamScoreSubstract);

            updateButton = FindViewById<Button>(Resource.Id.volleyballUpdateButton);
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
            int tempHomeScore = Convert.ToInt32(homeTeamScore.Text);
            int tempAwayScore = Convert.ToInt32(awayTeamScore.Text);

            if ((tempHomeScore >= 25 || tempAwayScore >= 25) && Math.Abs(tempHomeScore - tempAwayScore) > 1 && setCount <= 3)
            {
                if (tempHomeScore > tempAwayScore)
                {
                    int score = Convert.ToInt32(homeTeamSetScore.Text);
                    score += 1;
                    homeTeamSetScore.Text = score.ToString();
                } else
                {
                    int score = Convert.ToInt32(awayTeamSetScore.Text);
                    score += 1;
                    awayTeamSetScore.Text = score.ToString();
                }
                tempHomeScore = 0;
                tempAwayScore = 0;
                setCount++;
            }
            if ((tempHomeScore >= 15 || tempAwayScore >= 15) && Math.Abs(tempHomeScore - tempAwayScore) > 1 && setCount == 4)
            {
                if (tempHomeScore > tempAwayScore)
                {
                    int score = Convert.ToInt32(homeTeamSetScore.Text);
                    score += 1;
                    homeTeamSetScore.Text = score.ToString();
                }
                else
                {
                    int score = Convert.ToInt32(awayTeamSetScore.Text);
                    score += 1;
                    awayTeamSetScore.Text = score.ToString();
                }
                tempHomeScore = 0;
                tempAwayScore = 0;
                setCount++;
            }
            

            homeTeamScore.Text = tempHomeScore.ToString();
            awayTeamScore.Text = tempAwayScore.ToString();

            volleyballEvent.HostScore = tempHomeScore;
            volleyballEvent.GuestScore = tempAwayScore;
            volleyballEvent.HostSetScore = Convert.ToInt32(homeTeamSetScore.Text);
            volleyballEvent.GuestSetScore = Convert.ToInt32(awayTeamSetScore.Text);

            Update(volleyballEvent, volleyballEventId);
        }

        private async void Update(Volleyball volleyball, int id)
        {
            updateButton.Enabled = false;
            volleyball.EventId = id;

            HttpResponseMessage footballMessage = await RestService.Post(volleyball, "volleyball/update");

            updateButton.Enabled = true;
        }
    }
}