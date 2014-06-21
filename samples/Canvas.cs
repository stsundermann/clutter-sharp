using System;
using Cairo;
using System.Runtime.InteropServices;

using Clutter;

namespace ClutterTest
{
	class MainClass
	{
		static uint idleResizeId = 0;

		private static void DrawClock (object sender, DrawnArgs args)
		{
			Cairo.Context cr= args.Cr;
			int width = args.Width;
			int height = args.Height;

			DateTime now = DateTime.Now;
			double hours, minutes, seconds;
			Clutter.Color color;

			seconds = now.Second * Math.PI / 30;
			minutes = now.Minute * Math.PI / 30;
			hours = now.Hour * Math.PI / 6;

			cr.Save ();
			cr.Operator = Operator.Clear;
			cr.Paint ();
			cr.Restore ();
			cr.Operator = Operator.Over;
			cr.Scale (width, height);
			cr.LineCap = LineCap.Round;
			cr.LineWidth = 0.1;

			Global.CairoSetSourceColor (cr, Clutter.Color.New (0,0,0,255));
			cr.Translate (0.5, 0.5);
			cr.Arc (0, 0, 0.4, 0, Math.PI * 2);
			cr.Stroke ();

			color = Clutter.Color.New (255, 255, 255, 128);
			Global.CairoSetSourceColor (cr, color);
			cr.MoveTo (0, 0);
			cr.Arc (Math.Sin (seconds) * 0.4, -Math.Cos (seconds) * 0.4, 0.05, 0, Math.PI * 2);
			cr.Fill ();

			color = Clutter.Color.New (78, 154, 6, 196);
			Global.CairoSetSourceColor (cr, color);
			cr.MoveTo (0, 0);
			cr.LineTo (Math.Sin (minutes) * 0.4, -Math.Cos (minutes) * 0.4);
			cr.Stroke ();

			cr.MoveTo (0, 0);
			cr.LineTo (Math.Sin (hours) * 0.2, -Math.Cos (hours) * 0.2);
			cr.Stroke ();

			args.RetVal = true;
		}
			

		private static void OnActorResize (object sender, AllocationChangedArgs args)
		{
			Actor actor = (Actor)sender;

			if (idleResizeId == 0) {
				idleResizeId = Threads.AddTimeoutFull (50, 1000, delegate {
					float width, height;

					actor.GetSize (out width, out height);
					((Canvas)actor.Content).SetSize ((int)Math.Ceiling (width), (int)Math.Ceiling (height));
					idleResizeId = 0;

					return false;
				});
			}
		}


		public static void Main (string[] args)
		{
			Actor actor;
			Stage stage;
			Canvas canvas;

			Application.Init ();

			stage = new Stage ();
			stage.Title = "2d clock";
			stage.UserResizable = true;
			stage.BackgroundColor = Clutter.Color.New (114, 159, 207, 255);
			stage.SetSize (300, 300);
			stage.Show ();

			canvas = (Canvas) Canvas.New ();
			canvas.SetSize (300, 300);

			actor = new Actor ();
			actor.Content = canvas;
			actor.SetContentScalingFilters (ScalingFilter.Trilinear, ScalingFilter.Linear);
			stage.AddChild (actor);

			actor.AddConstraint (new BindConstraint (stage, BindCoordinate.Size, 0));


			actor.AllocationChanged += OnActorResize;

			stage.Destroyed += (o, e) => Application.MainQuit ();

			canvas.Drawn += DrawClock;

			canvas.Invalidate ();

			Threads.AddTimeoutFull (10, 1000, delegate {
				canvas.Invalidate ();
				return true;
			});
			
			Clutter.Application.Main ();

		}
	}
}
