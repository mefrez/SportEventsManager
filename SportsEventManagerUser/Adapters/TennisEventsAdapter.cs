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
using SportsEventManagerUser.Models;

namespace SportsEventManagerUser.Adapters
{
    public class TennisEventsAdapter : BaseAdapter<Tennis>
    {
        List<Tennis> items;
        Activity context;

        public TennisEventsAdapter(Activity context, List<Tennis> items)
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
            TennisEventsAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as TennisEventsAdapterViewHolder;

            if (holder == null)
            {
                holder = new TennisEventsAdapterViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                //replace with your item and your holder items
                //comment back in
                view = inflater.Inflate(Android.Resource.Layout.SimpleExpandableListItem1, parent, false);
                holder.Title = view.FindViewById<TextView>(Android.Resource.Id.Text1);
                view.Tag = holder;
            }


            //fill in your items
            holder.Title.Text = item.Event.HostName + " " + item.HostScore + " : " + item.GuestScore + " " + item.Event.GuestName;

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

        public override Tennis this[int position]
        {
            get
            {
                return items[position];
            }
        }
    }

    class TennisEventsAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        public TextView Title { get; set; }
    }
}