using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Collections;

using Cairo;
using Clutter;
using Gdk;
using System.Linq;
using Gtk;
using Clutter.GTK;
using GLib;

namespace ClutterTest
{
	class MainClass
	{
		static void AddListstoreRows (ListStore store, params String[] names)
		{
			var theme = new IconTheme ();

			foreach (var s in names) {
				var pixbuf = theme.LoadIcon (s, 48, (IconLookupFlags)0);
				store.InsertWithValues (-1, new object[] {s, pixbuf});
			}
		}

		static void AddToolbarItems(Toolbar toolbar, params String[] names)
		{
			foreach (var s in names) {
				var item = new ToolButton (s);
				toolbar.Insert (item, -1);
			}
		}

		static void OnEntered (object sender, EnteredArgs args)
		{
			var actor = (Clutter.Actor)sender;

			actor.SaveEasingState ();
			actor.EasingMode = AnimationMode.Linear;

			actor.Opacity = 255;
			actor.Y = 0;

			actor.RestoreEasingState ();

			args.RetVal = false;
		}

		static void OnLeft (object sender, LeaveEventArgs args)
		{
			var actor = (Clutter.Actor)sender;

			actor.SaveEasingState ();
			actor.EasingMode = AnimationMode.Linear;

			actor.Opacity = 128;
			actor.Y = actor.Height * -0.5f;

			actor.RestoreEasingState ();

			args.RetVal = false;
		}

		static void Main (String[] args)
		{
			if (Clutter.GTK.Application.Init () != InitError.Success)
				return;

			var window = new Clutter.GTK.Window ();
			window.Destroyed += (sender, e) => Gtk.Application.Quit();
			window.SetDefaultSize (400, 300);

			var store = new ListStore (typeof(string), typeof(Pixbuf));
			AddListstoreRows (store, "devhelp", "empathy", "evince", "seahorse", "totem");

			var iconview = new IconView (store);
			iconview.TextColumn = 0;
			iconview.PixbufColumn = 1;

			var sw = new ScrolledWindow ();
			window.Add (sw);
			sw.Add (iconview);
			sw.ShowAll ();

			var stage = window.Stage;

			var toolbar = new Toolbar ();
			AddToolbarItems (toolbar, Stock.Add, Stock.Bold, Stock.Italic, Stock.Cancel, Stock.Cdrom, Stock.Convert);

			toolbar.ShowAll ();
			var actor = new Clutter.GTK.Actor (toolbar);
			actor.AddConstraint (new BindConstraint (stage, BindCoordinate.Width, 0f));
			actor.Entered += OnEntered;
			actor.LeaveEvent += OnLeft;

			actor.Y = actor.Height * -0.5f;
			actor.Opacity = 128;
			actor.Reactive = true;
			stage.AddChild (actor);

			window.ShowAll ();
			Gtk.Application.Run ();
		}
	}
}
