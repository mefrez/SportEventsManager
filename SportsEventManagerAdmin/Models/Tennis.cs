﻿using System;
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
    public class Tennis
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }

        public int HostScore { get; set; }
        public int GuestScore { get; set; }

        public int HostSetScore { get; set; }
        public int GuestSetScore { get; set; }

        public int HostGameScore { get; set; }
        public int GuestGameScore { get; set; }
    }
}