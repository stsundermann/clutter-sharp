using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Collections;

using Cairo;
using Clutter;
using Gdk;
using System.Linq;

namespace ClutterTest
{
	class MainClass
	{
		static int currentGravity = 0;
		static List<ContentGravity> gravities = Enum.GetValues (typeof(ContentGravity)).Cast<ContentGravity>().ToList();

		static void Main (String[] args)
		{
			if (Application.Init () != InitError.Success)
				return;

			var stage = new Stage ();
			var image = (Image) Image.New ();
			var action = new TapAction ();
			var text = new Text ();
			var pixbuf = new Pixbuf("redhand.png");

			stage.Name = "Stage";
			stage.Title = "Content Box";
			stage.UserResizable = true;
			stage.Destroyed += (sender, e) => Application.MainQuit ();
			stage.MarginTop = 12;
			stage.MarginBottom = 12;
			stage.MarginLeft = 12;
			stage.MarginRight = 12;
			stage.Show ();

			image.SetData (pixbuf.Pixels, 
				pixbuf.HasAlpha ? Cogl.PixelFormat.Rgba8888 : Cogl.PixelFormat.Rgb888,
				(uint)pixbuf.Width, (uint)pixbuf.Height, (uint)pixbuf.Rowstride);

			stage.SetContentScalingFilters (ScalingFilter.Trilinear, ScalingFilter.Linear);
			stage.ContentGravity = gravities.Last<ContentGravity>();
			stage.Content = image;

			text.TextProp = "Content gravity: " + gravities.Last<ContentGravity>();
			text.AddConstraint (new AlignConstraint (stage, AlignAxis.Both, 0.5f));
			stage.AddChild (text);

			action.Tapped += (object o, TappedArgs arg) => {
				var actor = arg.Actor;

				actor.SaveEasingState ();
				actor.ContentGravity = gravities [currentGravity];
				actor.RestoreEasingState ();

				text.TextProp = "Content gravity: " + gravities [currentGravity];

				currentGravity++;
				if (currentGravity >= gravities.Count)
					currentGravity = 0;
			};
			stage.AddAction (action);

			Application.Main ();
		}
	}
}
