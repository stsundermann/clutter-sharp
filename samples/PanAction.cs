using System;
using Cairo;
using System.Runtime.InteropServices;

using Clutter;
using Gdk;

namespace ClutterTest
{
	class MainClass
	{
		private static Actor CreateContentActor ()
		{

			var content = new Actor ();
			content.SetSize (720, 720);

			var pixbuf = new Pixbuf ("redhand.png");
			Clutter.Image image = (Image)Clutter.Image.New ();

			image.SetData (pixbuf.Pixels, pixbuf.HasAlpha ? Cogl.PixelFormat.Rgba8888 : Cogl.PixelFormat.Rgb888, (uint)pixbuf.Width, (uint)pixbuf.Height, (uint)pixbuf.Rowstride);

			content.SetContentScalingFilters (ScalingFilter.Trilinear, ScalingFilter.Linear);
			content.ContentGravity = ContentGravity.ResizeAspect;
			content.Content = image;

			return content;
		}


		private static void OnPan (object sender, PanArgs args)
		{
			float deltaX, deltaY;
			Clutter.Event evnt = null;

			if (args.IsInterpolated)
				((PanAction)sender).GetInterpolatedDelta (out deltaX, out deltaY);
			else {
				((GestureAction)sender).GetMotionDelta (0, out deltaX, out deltaY);
				evnt = ((GestureAction)sender).GetLastEvent (0);
			}

			Console.WriteLine (String.Format ("[{0}] panning dx:{1:0.##} dy:{2:0.##}", 
				evnt == null ? "INTERPOLATED" : evnt.Type() == Clutter.EventType.Motion ? "MOTION" :
				evnt.Type () == Clutter.EventType.TouchUpdate ? "TOUCH UPDATE" :
				"?", deltaX, deltaY));

			args.RetVal = true;
		}

		private static Actor CreateScrollActor (Stage stage)
		{
			Actor scroll;
			PanAction panAction;

			scroll = new Actor ();
			scroll.Name = "scroll";

			scroll.AddConstraint (new AlignConstraint (stage, AlignAxis.XAxis, 0));
			scroll.AddConstraint (new BindConstraint (stage, BindCoordinate.Size, 0));

			scroll.AddChild (CreateContentActor ());

			panAction = new PanAction ();
			panAction.Interpolate = true;
			panAction.Pan += OnPan;
			scroll.AddAction (panAction);

			scroll.Reactive = true;

			return scroll;
		}

		private static void OnKeyPress (object sender, KeyPressedArgs args)
		{
			var scroll = ((Actor)sender).FirstChild;

			var keySymbol = args.Event.KeySymbol;

			if (keySymbol == Constants.KEY_space) {
				scroll.SaveEasingState ();
				scroll.EasingDuration = 1000;
				scroll.SetChildTransform ();
				scroll.RestoreEasingState ();
			}

			args.RetVal = Constants.EVENT_STOP;
		}

		public static void Main (string[] args)
		{
			Actor scroll, info;
			Stage stage;

			Application.Init ();

			stage = new Stage ();
			stage.Title = "Pan Action";
			stage.UserResizable = true;

			scroll = CreateScrollActor (stage);
			stage.AddChild (scroll);

			info = new Text (null, "Press <space> to reset the image position.");
			stage.AddChild (info);
			info.SetPosition (12, 12);

			stage.Destroyed += (sender, e) => Application.MainQuit ();
			stage.KeyPressed += OnKeyPress;

			stage.Show ();

			Clutter.Application.Main ();
		}
	}
}
