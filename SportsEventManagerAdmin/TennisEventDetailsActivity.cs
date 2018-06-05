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
    [Activity(Label = "Manage Tennis Events", Theme = "@style/AppTheme")]
    public class TennisEventDetailsActivity : Activity
    {
        public int tennisEventId;

        Tennis tennisEvent = new Tennis();

        private TextView homeName;
        private TextView awayName;

        private TextView homeScore;
        private TextView awayScore;

        private TextView homeGemScore;
        private TextView awayGemScore;

        private TextView homeSetScore;
        private TextView awaySetScore;

        private Button homeScoreAdd;
        private Button homeScoreSubstract;

        private Button awayScoreAdd;
        private Button awayScoreSubstract;

        private Button updateButton;

        private bool isTiebreaker;
        private int setCount;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.tennis_details_layout);

            tennisEventId = Intent.Extras.GetInt("tennisEventId");

            // Create your application here

            GetTennisMatch();
        }

        private async void GetTennisMatch()
        {
            string tennisEventJson = await RestService.Get("tennis/get/" + tennisEventId);

            tennisEvent = JsonConvert.DeserializeObject<Tennis>(tennisEventJson);

            FindViews();

            HandleEvents();

            homeName.Text = tennisEvent.Event.HostName;
            awayName.Text = tennisEvent.Event.GuestName;

            homeScore.Text = tennisEvent.HostScore.ToString();
            awayScore.Text = tennisEvent.GuestScore.ToString();

            homeGemScore.Text = tennisEvent.HostGameScore.ToString();
            awayGemScore.Text = tennisEvent.GuestGameScore.ToString();

            homeSetScore.Text = tennisEvent.HostSetScore.ToString();
            awaySetScore.Text = tennisEvent.GuestSetScore.ToString();

            if (Convert.ToInt32(homeGemScore.Text) == 6 && Convert.ToInt32(awayGemScore.Text) == 6)
            {
                isTiebreaker = true;
            } else
            {
                isTiebreaker = false;
            }
            setCount = tennisEvent.HostSetScore + tennisEvent.GuestSetScore;
        }

        private void FindViews()
        {
            homeName = FindViewById<TextView>(Resource.Id.tennisHomeTeamTextView);
            awayName = FindViewById<TextView>(Resource.Id.tennisAwayTeamTextView);
            homeScore = FindViewById<TextView>(Resource.Id.tennisHomeTeamScoreTextView);
            awayScore = FindViewById<TextView>(Resource.Id.tennisAwayTeamScoreTextView);
            homeGemScore = FindViewById<TextView>(Resource.Id.tennisHomeGemScoreTextView);
            awayGemScore = FindViewById<TextView>(Resource.Id.tennisAwayGemScoreTextView);
            homeSetScore = FindViewById<TextView>(Resource.Id.tennisHomeSetScoreTextView);
            awaySetScore = FindViewById<TextView>(Resource.Id.tennisAwaySetScoreTextView);

            homeScoreAdd = FindViewById<Button>(Resource.Id.tennisHomeTeamScoreAdd);
            homeScoreSubstract = FindViewById<Button>(Resource.Id.tennisHomeTeamScoreSubstract);

            awayScoreAdd = FindViewById<Button>(Resource.Id.tennisAwayTeamScoreAdd);
            awayScoreSubstract = FindViewById<Button>(Resource.Id.tennisAwayTeamScoreSubstract);

            updateButton = FindViewById<Button>(Resource.Id.tennisUpdateButton);
        }

        private void HandleEvents()
        {
            homeScoreAdd.Click += HomeScoreAdd_Click;
            homeScoreSubstract.Click += HomeScoreSubstract_Click;

            awayScoreAdd.Click += AwayScoreAdd_Click;
            awayScoreSubstract.Click += AwayScoreSubstract_Click;

            updateButton.Click += UpdateButton_Click;
        }

        private void AwayScoreSubstract_Click(object sender, EventArgs e)
        {
            int score = Convert.ToInt32(awayScore.Text);
            if (isTiebreaker)
            {
                if (score < 1)
                {
                    return;
                }
                score -= 1;
                awayScore.Text = score.ToString();
                return;
            }
            int check = checkScore(Convert.ToInt32(awayScore.Text), Convert.ToInt32(homeScore.Text));
            if (score < 15)
            {
                return;
            }
            switch (check)
            {
                case 1:
                case 2:
                    score -= 15;
                    awayScore.Text = score.ToString();
                    break;
                case 5:
                    score -= 10;
                    awayScore.Text = score.ToString();
                    break;
                case 3:
                case 4:
                    score -= 10;
                    awayScore.Text = score.ToString();
                    homeScore.Text = "40";
                    break;
                case 6:
                    score -= 20;
                    awayScore.Text = score.ToString();
                    break;
            }
        }

        private void AwayScoreAdd_Click(object sender, EventArgs e)
        {
            int score = Convert.ToInt32(awayScore.Text);
            if (isTiebreaker)
            {
                score += 1;
                awayScore.Text = score.ToString();
                return;
            }
            int check = checkScore(Convert.ToInt32(awayScore.Text), Convert.ToInt32(homeScore.Text));
            switch (check)
            {
                case 1:
                    score += 15;
                    awayScore.Text = score.ToString();
                    break;
                case 2:
                    score += 10;
                    awayScore.Text = score.ToString();
                    break;
                case 3:
                case 4:
                    score += 10;
                    awayScore.Text = score.ToString();
                    homeScore.Text = "40";
                    break;
                case 5:
                    score += 20;
                    awayScore.Text = score.ToString();
                    break;
            }
        }

        private void HomeScoreSubstract_Click(object sender, EventArgs e)
        {
            int score = Convert.ToInt32(homeScore.Text);
            if (isTiebreaker)
            {
                if(score < 1)
                {
                    return;
                }
                score -= 1;
                homeScore.Text = score.ToString();
                return;
            }
            int check = checkScore(Convert.ToInt32(homeScore.Text), Convert.ToInt32(awayScore.Text));
            if (score < 15)
            {
                return;
            }
            switch (check)
            {
                case 1:
                case 2:
                    score -= 15;
                    homeScore.Text = score.ToString();
                    break;
                case 5:
                    score -= 10;
                    homeScore.Text = score.ToString();
                    break;
                case 3:
                case 4:
                    score -= 10;
                    homeScore.Text = score.ToString();
                    awayScore.Text = "40";
                    break;
                case 6:
                    score -= 20;
                    homeScore.Text = score.ToString();
                    break;

            }
        }

        private void HomeScoreAdd_Click(object sender, EventArgs e)
        {
            int score = Convert.ToInt32(homeScore.Text);
            if (isTiebreaker)
            {
                score += 1;
                homeScore.Text = score.ToString();
                return;
            }
            int check = checkScore(Convert.ToInt32(homeScore.Text), Convert.ToInt32(awayScore.Text));
            switch (check)
            {
                case 1:
                    score += 15;
                    homeScore.Text = score.ToString();
                    break;
                case 2:
                    score += 10;
                    homeScore.Text = score.ToString();
                    break;
                case 3:
                case 4:
                    score += 10;
                    homeScore.Text = score.ToString();
                    awayScore.Text = "40";
                    break;
                case 5:
                    score += 20;
                    homeScore.Text = score.ToString();
                    break;
            }
        }

        private int checkScore(int scoringTeamScore, int opposingTeamScore)
        {
            if (scoringTeamScore < 30)
            {
                return 1;
            }
            if (scoringTeamScore == 30)
            {
                return 2;
            }
            if (scoringTeamScore > 50)
            {
                return 6;
            }
            if (scoringTeamScore > 30 && opposingTeamScore > 30)
            {
                if (scoringTeamScore < 50)
                {
                    return 3;
                }
                return 4;
            } 
            if (scoringTeamScore > 30)
            {
                return 5;
            }
            return -1;
           
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (setCount < 3 && Convert.ToInt32(homeSetScore.Text) < 2 && Convert.ToInt32(awaySetScore.Text) < 2)
            {
                int tempHomeScore = Convert.ToInt32(homeScore.Text);
                int tempAwayScore = Convert.ToInt32(awayScore.Text);

                if (isTiebreaker && tempHomeScore > 5 && tempAwayScore > 5 && Math.Abs(tempHomeScore - tempAwayScore) > 1)
                {
                    if (tempHomeScore > tempAwayScore)
                    {
                        int score = Convert.ToInt32(homeSetScore.Text);
                        score += 1;
                        homeSetScore.Text = score.ToString();
                    }
                    else
                    {
                        int score = Convert.ToInt32(awaySetScore.Text);
                        score += 1;
                        awaySetScore.Text = score.ToString();
                    }
                    homeGemScore.Text = "0";
                    awayGemScore.Text = "0";
                    homeScore.Text = "0";
                    awayScore.Text = "0";
                    isTiebreaker = false;
                    setCount += 1;
                }
                if ((tempHomeScore > 50 || tempAwayScore > 50) && Math.Abs(tempHomeScore - tempAwayScore) > 10)
                {
                    if (tempHomeScore > tempAwayScore)
                    {
                        int score = Convert.ToInt32(homeGemScore.Text);
                        score += 1;
                        homeGemScore.Text = score.ToString();
                    }
                    else
                    {
                        int score = Convert.ToInt32(awayGemScore.Text);
                        score += 1;
                        awayGemScore.Text = score.ToString();
                    }

                    homeScore.Text = "0";
                    awayScore.Text = "0";
                }
                if ((Convert.ToInt32(homeGemScore.Text) > 5 || Convert.ToInt32(awayGemScore.Text) > 5) && Math.Abs(Convert.ToInt32(homeGemScore.Text)-Convert.ToInt32(awayGemScore.Text)) > 1)
                {
                    if(Convert.ToInt32(homeGemScore.Text) > Convert.ToInt32(awayGemScore.Text))
                    {
                        int score = Convert.ToInt32(homeSetScore.Text);
                        score += 1;
                        homeSetScore.Text = score.ToString();
                    }
                    else
                    {
                        int score = Convert.ToInt32(awaySetScore.Text);
                        score += 1;
                        awaySetScore.Text = score.ToString();
                    }
                    homeScore.Text = "0";
                    homeGemScore.Text = "0";
                    awayScore.Text = "0";
                    awayGemScore.Text = "0";
                    setCount += 1;
                }

                if((Convert.ToInt32(homeGemScore.Text) == 6 && Convert.ToInt32(awayGemScore.Text) == 6) && Math.Abs(Convert.ToInt32(homeGemScore.Text) - Convert.ToInt32(awayGemScore.Text)) < 2)
                {
                    isTiebreaker = true; 
                }

                tennisEvent.HostScore = Convert.ToInt32(homeScore.Text);
                tennisEvent.GuestScore = Convert.ToInt32(awayScore.Text);
                tennisEvent.HostGameScore = Convert.ToInt32(homeGemScore.Text);
                tennisEvent.GuestGameScore = Convert.ToInt32(awayGemScore.Text);
                tennisEvent.HostSetScore = Convert.ToInt32(homeSetScore.Text);
                tennisEvent.GuestSetScore = Convert.ToInt32(awaySetScore.Text);

                Update(tennisEvent, tennisEventId);
            }
        }


        private async void Update(Tennis tennis, int id)
        {
            updateButton.Enabled = false;
            tennis.EventId = id;

            HttpResponseMessage tennisMessage = await RestService.Post(tennis, "tennis/update");

            updateButton.Enabled = true;
        }


    }
}