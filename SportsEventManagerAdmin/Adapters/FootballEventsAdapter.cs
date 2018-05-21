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
using SportsEventManagerAdmin.Models;

namespace SportsEventManagerAdmin.Adapters
{
    public class FootballEventsAdapter : BaseAdapter<Football>
    {
        List<Football> items;
        Activity context;

        public FootballEventsAdapter(Activity context, List<Football> items)
        {
            this.context = context;
            this.items = items;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            var view = convertView;
            FootballEventsAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as FootballEventsAdapterViewHolder;

            if (holder == null)
            {
                holder = new FootballEventsAdapterViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                //replace with your item and your holder items
                //comment back in
                view = inflater.Inflate(Android.Resource.Layout.SimpleExpandableListItem1, parent, false);
                holder.Title = view.FindViewById<TextView>(Android.Resource.Id.Text1);
                view.Tag = holder;
            }


            //fill in your items
            holder.Title.Text = item.Event.HostName + " vs. " + item.Event.GuestName;

            return view;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override Football this[int position]
        {
            get
            {
                return items[position];
            }
        }
    }

    class FootballEventsAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        public TextView Title { get; set; }
    }
}