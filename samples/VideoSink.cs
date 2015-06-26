using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Collections;

using Cairo;
using Gst;
using Clutter;
using Clutter.Gstreamer;
using GLib;

namespace ClutterTest
{
	class MainClass
	{
		static void OnSizeChanged (object sender, Clutter.SizeChangedArgs args)
		{
			var texture = (Texture)sender;
			var stage = texture.Stage;

			if (stage == null)
				return;

			float stageWidth, stageHeight, newHeight, newWidth, newX, newY;
			stage.GetSize (out stageWidth, out stageHeight);
			newHeight = (args.Height * stageHeight) / args.Width;

			if (newHeight <= stageHeight) {
				newWidth = stageWidth;

				newX = 0;
				newY = (stageHeight - newHeight) / 2;
			} else {
				newWidth = (args.Width * stageHeight) / args.Height;
				newHeight = stageHeight;

				newX = (stageWidth - newWidth) / 2;
				newY = 0;
			}

			texture.SetPosition (newX, newY);
			texture.SetSize (newWidth, newHeight);
		}

		static void Main (String[] args)
		{
			if (Clutter.Application.Init () != InitError.Success)
				return;

			Gst.Application.Init ();

			var stage = new Stage ();
			stage.Destroyed += (sender, e) => Clutter.Application.MainQuit();

			var timeline = new Timeline (1000);
			timeline.Loop = true;

			var texture = new Texture ();
			texture.SizeChanged += OnSizeChanged;

			var pipeline = new Pipeline ();

			var src = ElementFactory.Make ("videotestsrc");
			var warp = ElementFactory.Make ("warptv");
			var colorspace = ElementFactory.Make ("videoconvert");
			var sink = ElementFactory.Make ("cluttersink");
			sink ["texture"] = texture;

			pipeline.Add (src);
			pipeline.Add (warp);
			pipeline.Add (colorspace);
			pipeline.Add (sink);
			Element.Link (src, warp, colorspace, sink);
			pipeline.SetState (Gst.State.Playing);

			timeline.Start ();
			stage.AddChild (texture);
			stage.Show ();

			Clutter.Application.Main ();
		}
	}
}
