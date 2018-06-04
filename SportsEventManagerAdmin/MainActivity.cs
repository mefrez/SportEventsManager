using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System;
using Android.Content;

namespace SportsEventManagerAdmin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button addEventButton;
        private Button manageFootballEventsButton;
        private Button manageVolleyballEventsButton;
        private Button manageTennisEventsButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            FindViews();

            HandleEvents();
        }

        private void FindViews()
        {
            addEventButton = FindViewById<Button>(Resource.Id.addEventButton);
            manageFootballEventsButton = FindViewById<Button>(Resource.Id.manageFootballEventsButton);
            manageVolleyballEventsButton = FindViewById<Button>(Resource.Id.manageVolleyballEventsButton);
            manageTennisEventsButton = FindViewById<Button>(Resource.Id.manageTennisEventsButton);
        }

        private void HandleEvents()
        {
            addEventButton.Click += AddEventButton_Click;
            manageFootballEventsButton.Click += ManageFootballEventsButton_Click;
            manageVolleyballEventsButton.Click += ManageVolleyballEventsButton_Click;
            manageTennisEventsButton.Click += ManageTennisEventsButton_Click;
        }

        private void ManageFootballEventsButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ManageEventsActivity));
            StartActivity(intent);
        }

        private void ManageTennisEventsButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ManageTennisEventsActivity));
            StartActivity(intent);
        }

        private void ManageVolleyballEventsButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ManageVolleyballEventsActivity));
            StartActivity(intent);
        }

        private void AddEventButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AddEventActivity));
            StartActivity(intent);
        }
    }
}

