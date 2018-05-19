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
        private Button manageEventsButton;

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
            manageEventsButton = FindViewById<Button>(Resource.Id.manageEventsButton);
        }

        private void HandleEvents()
        {
            addEventButton.Click += AddEventButton_Click;
            manageEventsButton.Click += ManageEventsButton_Click;
        }

        private void ManageEventsButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ManageEventsActivity));
            StartActivity(intent);
        }

        private void AddEventButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AddEventActivity));
            StartActivity(intent);
        }
    }
}

