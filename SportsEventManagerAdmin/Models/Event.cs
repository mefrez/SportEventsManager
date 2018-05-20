using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SportsEventManagerAdmin.Models
{
    public class Event
    {
        public int Id { get; set; }

        public DateTime? Started { get; set; }

        public DateTime? Ended { get; set; }

        public string TournamentName { get; set; }
        public string HostName { get; set; }
        public string GuestName { get; set; }
    }
}