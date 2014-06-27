using System;
using System.Runtime.InteropServices;

using Cairo;
using Clutter;

namespace ClutterTest
{
	class MainClass
	{
		static void DrawContent (object sender, DrawnArgs args)
		{
			var cr = args.Cr;

			double x, y;
			x = y = 1.0;
			double width = args.Width - 2.0;
			double height = args.Height - 2.0;
			double aspect = 1.0;
			double cornerRadius = args.Height / 20.0;

			double radius = cornerRadius / aspect;
			double degrees = Math.PI / 180.0;

			cr.Save ();
			cr.Operator = Operator.Clear;
			cr.Paint ();
			cr.Restore ();

			cr.NewSubPath ();
			cr.Arc (x + width - radius, y + radius, radius, -90 * degrees, 0 * degrees);
			cr.Arc (x + width - radius, y + height - radius, radius, 0 * degrees, 90 * degrees);
			cr.Arc (x + radius, y + height - radius, radius, 90 * degrees, 180 * degrees);
			cr.Arc (x + radius, y + radius, radius, 180 * degrees, 270 * degrees);
			cr.ClosePath ();

			cr.SetSourceRGB (0.5, 0.5, 1);
			cr.Fill ();

			args.RetVal = true;
		}

		static void Main (String[] args)
		{
			Actor actor;
			Stage stage;
			Canvas canvas;
			Transition transition;

			if (Application.Init () != InitError.Success)
				return;

			stage = new Stage ();
			stage.Title = "Rectangle with rounded corners";
			stage.BackgroundColor = Clutter.Color.New (255, 255, 255, 255);
			stage.SetSize (500, 500);
			stage.Show ();

			canvas = (Canvas) Canvas.New();
			canvas.SetSize (300, 300);

			actor = new Actor ();
			actor.Content = canvas;
			actor.ContentGravity = ContentGravity.Center;
			actor.SetContentScalingFilters (ScalingFilter.Trilinear, ScalingFilter.Linear);
			actor.SetPivotPoint (0.5f, 0.5f);
			actor.AddConstraint (new BindConstraint (stage, BindCoordinate.Size, 0f));
			stage.AddChild (actor);

			transition = new PropertyTransition ("rotation-angle-y");
			transition.FromValue = new GLib.Value (0.0);
			transition.ToValue = new GLib.Value (360.0);
			((Timeline)transition).Duration = 2000;
			((Timeline)transition).RepeatCount = -1;
			actor.AddTransition ("rotateActor", transition);

			stage.Destroyed += (sender, e) => Application.MainQuit ();
			canvas.Drawn += DrawContent;

			canvas.Invalidate ();
			Application.Main ();
		}
	}
}
