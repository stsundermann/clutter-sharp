using System;
using System.Runtime.InteropServices;

using Clutter;

namespace ClutterTest
{
	class MainClass
	{
		static bool toggled = true;

		private static void animateColor (object o, ButtonPressedArgs args)
		{
			Actor actor = (Actor) o;

			Color endColor;

			if (toggled)
				endColor = Color.New (0, 0, 255, 255);
			else
				endColor = Color.New (0, 255, 0, 255);

			actor.SaveEasingState ();
			actor.EasingDuration = 500;
			actor.EasingMode = AnimationMode.Linear;
			actor.BackgroundColor = endColor;
			actor.RestoreEasingState ();

			toggled = !toggled;

			args.RetVal = false;
		}

		private static void onCrossing (object o, GLib.SignalArgs args)
		{
			Actor actor = (Actor)o;

			bool isEnter = ((Event)args.Args[0]).Type () == EventType.Enter;
			float zpos;

			if (isEnter)
				zpos = -250.0f;
			else
				zpos = 0.0f;
				
			actor.SaveEasingState ();
			actor.EasingDuration = 500;
			actor.EasingMode = AnimationMode.EaseOutBounce;
			actor.ZPosition = zpos;
			actor.RestoreEasingState ();

			args.RetVal = false;
		}

		private static void onTransitionStopped (object o, TransitionStoppedArgs args)
		{
			Actor actor = (Actor)o;

			actor.SaveEasingState ();
			actor.SetRotationAngle (RotateAxis.YAxis, 0.0f);
			actor.RestoreEasingState ();

			actor.TransitionStopped -= onTransitionStopped;
		}

		private static void animateRotation (object o, ButtonPressedArgs args)
		{
			Actor actor = (Actor)o;

			actor.SaveEasingState ();
			actor.EasingDuration = 1000;
			actor.SetRotationAngle (RotateAxis.YAxis, 360.0f);
			actor.RestoreEasingState ();

			actor.TransitionStopped += onTransitionStopped;

			args.RetVal = false;

		}



		public static void Main (string[] args)
		{
			Application.Init ();

			Stage stage;
			Actor vase;
			Actor[] flowers = new Actor[3];


			stage = new Stage ();

			stage.Destroyed += (sender, evnt) => Application.MainQuit ();


			stage.Title = "Three Flowers in a Vase";
			stage.UserResizable = true;

			vase = new Actor ();
			vase.LayoutManager = new BoxLayout ();
			vase.BackgroundColor = Color.New (150, 150, 255, 255);
			vase.AddConstraint (new AlignConstraint (stage, AlignAxis.Both, 0.5f));
			stage.AddChild (vase);

			flowers[0] = new Actor ();
			flowers[0].Name = "flower.1";
			flowers[0].SetSize (128, 128);
			flowers[0].MarginLeft = 12;
			flowers[0].BackgroundColor = Color.New (255, 0, 0, 255);
			flowers[0].Reactive = true;
			vase.AddChild (flowers[0]);
			flowers[0].ButtonPressed += animateColor;

			flowers[1] = new Actor ();
			flowers[1].Name = "flower.2";
			flowers[1].SetSize (128, 128);
			flowers[1].MarginTop = 12;
			flowers[1].MarginRight = 6;
			flowers[1].MarginLeft = 6;
			flowers[1].MarginBottom = 12;
			flowers[1].BackgroundColor = Color.New (255, 255, 0, 255);
			flowers[1].Reactive = true;
			vase.AddChild (flowers[1]);
			flowers[1].Entered += onCrossing;
			flowers[1].LeaveEvent += onCrossing;

			flowers[2] = new Actor ();
			flowers[2].Name = "flower.3";
			flowers[2].SetSize (128, 128);
			flowers[2].MarginRight = 12;
			flowers[2].BackgroundColor = Color.New (0, 255, 0, 255);
			flowers[2].Reactive = true;
			vase.AddChild (flowers[2]);
			flowers[2].ButtonPressed += animateRotation;

			stage.Show ();
			Application.Main ();

		}
	}
}
