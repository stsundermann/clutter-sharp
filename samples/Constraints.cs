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
			stage.Name = "stage";
			stage.Title = "Snap Constraint";
			stage.BackgroundColor = Clutter.Color.New (0xee, 0xee, 0xee, 0xff);
			stage.UserResizable = true;
			stage.Destroyed += (sender, e) => Application.MainQuit ();

			var layerA = new Actor ();
			layerA.BackgroundColor = Clutter.Color.New (0xcc, 0x00, 0x00, 0xff);
			layerA.Name = "layerA";
			layerA.SetSize (100f, 25f);
			stage.AddChild (layerA);

			layerA.AddConstraint (new AlignConstraint (stage, AlignAxis.Both, 0.5f));

			var layerB = new Actor ();
			layerB.BackgroundColor = Clutter.Color.New (0xc4, 0xa0, 0x00, 0xff);
			layerB.Name = "layerB";
			stage.AddChild (layerB);

			layerB.AddConstraint (new BindConstraint (layerA, BindCoordinate.X, 0f));
			layerB.AddConstraint (new BindConstraint (layerA, BindCoordinate.Width, 0f));

			layerB.AddConstraint (new SnapConstraint (layerA, SnapEdge.Top, SnapEdge.Bottom, 10f));
			layerB.AddConstraint (new SnapConstraint (stage, SnapEdge.Bottom, SnapEdge.Bottom, -10f));

			var layerC = new Actor ();
			layerC.BackgroundColor = Clutter.Color.New (0x8a, 0xe2, 0x34, 0xff);
			layerC.Name = "layerC";
			stage.AddChild (layerC);

			layerC.AddConstraint (new BindConstraint (layerA, BindCoordinate.X, 0f));
			layerC.AddConstraint(new BindConstraint (layerA, BindCoordinate.Width, 0f));

			layerC.AddConstraint (new SnapConstraint (layerA, SnapEdge.Bottom, SnapEdge.Top, -10f));
			layerC.AddConstraint (new SnapConstraint (stage, SnapEdge.Top, SnapEdge.Top, 10f));

			stage.Show ();

			Application.Main ();
		}
	}
}
