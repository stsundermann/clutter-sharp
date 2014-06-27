using System;
using System.Runtime.InteropServices;

using Cairo;
using Clutter;

namespace ClutterTest
{
	class MainClass
	{
		static String[] menuItemsName = {
			"Option 1",
			"Option 2",
			"Option 3",
			"Option 4",
			"Option 5",
			"Option 6",
			"Option 7",
			"Option 8",
			"Option 9",
			"Option 10",
			"Option 11"
		};

		static int selectedItem;

		static void SelectItemAtIndex (Actor scroll, int index)
		{
			Clutter.Point point;
			var menu = scroll.FirstChild;
			Text item;

			var oldSelected = selectedItem;

			item = (Text)menu.GetChildAtIndex (oldSelected);
			item.Color = Clutter.Color.New (255, 255, 255, 255);

			if (index < 0)
				index = menu.NChildren - 1;
			else if (index >= menu.NChildren)
				index = 0;

			item = (Text)menu.GetChildAtIndex (index);
			item.GetPosition (out point.X, out point.Y);

			scroll.SaveEasingState ();
			((ScrollActor)scroll).ScrollToPoint (point);
			scroll.RestoreEasingState ();

			item.Color = Clutter.Color.New (127, 127, 127, 255);

			selectedItem = index;
		}

		static void SelectNextItem (Actor scroll)
		{
			SelectItemAtIndex (scroll, selectedItem + 1);
		}

		static void SelectPrevItem (Actor scroll)
		{
			SelectItemAtIndex (scroll, selectedItem - 1);
		}

		static Actor CreateMenuItem (String name)
		{
			var text = new Text();

			text.FontName = "Sans Bold 24";
			text.TextProp = name;
			text.Color = Clutter.Color.New (255, 255, 255, 255);
			text.MarginLeft = 12f;
			text.MarginRight = 12f;

			return text;
		}
			
		static Actor CreateMenuActor (Actor scroll)
		{
			var menu = new Actor ();
			var layoutManager = new BoxLayout ();

			layoutManager.Orientation = Orientation.Vertical;
			layoutManager.Spacing = 12;

			menu.LayoutManager = layoutManager;
			menu.BackgroundColor = Clutter.Color.New (0, 0, 0, 255);

			foreach (var s in menuItemsName)
				menu.AddChild (CreateMenuItem (s));

			return menu;
		}

		static Actor CreateScrollActor (Stage stage)
		{
			var scroll = new ScrollActor ();
			scroll.Name = "scroll";

			scroll.SetPosition (0f, 18f);
			scroll.AddConstraint (new AlignConstraint (stage, AlignAxis.XAxis, 0.5f));
			scroll.AddConstraint (new BindConstraint (stage, BindCoordinate.Height, -36f));

			scroll.ScrollMode = ScrollMode.Vertically;
			scroll.AddChild (CreateMenuActor (scroll));

			SelectItemAtIndex (scroll, 0);

			return scroll;
		}

		static void OnKeyPress (object sender, KeyPressedArgs args)
		{
			Actor scroll;
			uint keySymbol;
			var stage = (Stage)sender;

			scroll = stage.FirstChild;

			keySymbol = args.Event.KeySymbol;

			if (keySymbol == Constants.KEY_Up)
				SelectPrevItem (scroll);
			else if (keySymbol == Constants.KEY_Down)
				SelectNextItem (scroll);

			args.RetVal = false;
		}

		static void Main (String[] args)
		{
			Stage stage;

			if (Application.Init () != InitError.Success)
				return;

			stage = new Stage ();
			stage.Title = "Scroll Actor";
			stage.UserResizable = true;
			stage.BackgroundColor = Clutter.Color.New (255, 255, 255, 255);
			stage.SetSize (500, 500);

			stage.Destroyed += (sender, e) => Application.MainQuit ();
			stage.KeyPressed += OnKeyPress;

			stage.AddChild (CreateScrollActor (stage));

			stage.Show ();

			Application.Main ();
		}
	}
}
