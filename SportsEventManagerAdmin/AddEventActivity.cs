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
using Android.Text;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using SportsEventManagerAdmin.Models;
using SportsEventManagerAdminApp.Services;

namespace SportsEventManagerAdmin
{
    [Activity(Label = "Add Event", Theme = "@style/AppTheme")]
    public class AddEventActivity : AppCompatActivity
    {
        private EditText awayTeamName;
        private EditText homeTeamName;
        private EditText tournamentName;

        private RadioButton sportType1;
        private RadioButton sportType2;
        private RadioButton sportType3;

        private Button addButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.add_event_layout);

            FindViews();
            HandleEvents();

            awayTeamName.AfterTextChanged += EnableButton;
            homeTeamName.AfterTextChanged += EnableButton;
            tournamentName.AfterTextChanged += EnableButton;

        }

        private void EnableButton(object sender, AfterTextChangedEventArgs e)
        {
            addButton.Enabled = true;
        }

        private void FindViews()
        {
            awayTeamName = FindViewById<EditText>(Resource.Id.AwayTeamName);
            homeTeamName = FindViewById<EditText>(Resource.Id.HomeTeamName);
            tournamentName = FindViewById<EditText>(Resource.Id.TournamentName);

            sportType1 = FindViewById<RadioButton>(Resource.Id.sportType1);
            sportType2 = FindViewById<RadioButton>(Resource.Id.sportType2);
            sportType3 = FindViewById<RadioButton>(Resource.Id.sportType3);

            addButton = FindViewById<Button>(Resource.Id.addButton);
        }

        private void HandleEvents()
        {
            addButton.Click += AddButton_Click;
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            if(awayTeamName.Text.Length > 0 && homeTeamName.Text.Length > 0 && tournamentName.Text.Length > 0)
            {
                Event ev = new Event();

                ev.HostName = homeTeamName.Text;
                ev.GuestName = awayTeamName.Text;
                ev.TournamentName = tournamentName.Text;

                HttpResponseMessage message = await RestService.Post(ev, "event/create");

                string msg = await message.Content.ReadAsStringAsync();

                if (sportType1.Checked == true)
                {

                }
                else if(sportType2.Checked == true)
                {

                }
                else if(sportType3.Checked == true)
                {

                }

                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);

            }
            else
            {
                Android.Support.V7.App.AlertDialog.Builder alertDialog = new Android.Support.V7.App.AlertDialog.Builder(this);
                alertDialog.SetTitle("Info");
                alertDialog.SetMessage("Fields cannot be empty!");
                alertDialog.SetNeutralButton("OK", delegate
                {
                    alertDialog.Dispose();
                });
                alertDialog.Show();
            }
        }
    }
}