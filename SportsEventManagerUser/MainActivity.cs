using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Content;

namespace SportsEventManagerUser
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{

        private Button footballButton;
        private Button volleyballButton;
        private Button tennisButton;

        protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.activity_main);

            FindViews();

            HandleEvents();
			
		}

        private void FindViews()
        {
            footballButton = FindViewById<Button>(Resource.Id.footballButton);
            volleyballButton = FindViewById<Button>(Resource.Id.volleyballButton);
            tennisButton = FindViewById<Button>(Resource.Id.tennisButton);
        }

        private void HandleEvents()
        {
            footballButton.Click += FootballButton_Click;
            volleyballButton.Click += VolleyballButton_Click;
            tennisButton.Click += TennisButton_Click;
        }

        private void FootballButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(FootballEventsActivity));
            StartActivity(intent);
        }

        private void VolleyballButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(VolleyballEventsActivity));
            StartActivity(intent);
        }

        private void TennisButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(TennisEventsActivity));
            StartActivity(intent);
        }
    }
}

