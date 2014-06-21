namespace Clutter {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

	public partial class Event {

		[DllImport("clutter-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr clutter_event_get_type();

		public static GLib.GType GType { 
			get {
				IntPtr raw_ret = clutter_event_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

		public static Event GetEvent (IntPtr raw)
		{
			if (raw == IntPtr.Zero)
				return null;

			Event evnt = new Event (raw);

			switch (evnt.Type ()) {
			case EventType.KeyPress:
			case EventType.KeyRelease:
				return new KeyEvent (raw);
			case EventType.ButtonPress:
			case EventType.ButtonRelease:
				return new ButtonEvent (raw);
			case EventType.Motion:
				return new MotionEvent (raw);
			case EventType.TouchBegin:
			case EventType.TouchCancel:
			case EventType.TouchEnd:
			case EventType.TouchUpdate:
				return new TouchEvent (raw);
			case EventType.StageState:
				return new StageStateEvent (raw);
			case EventType.Enter:
			case EventType.Leave:
				return new CrossingEvent (raw);
			case EventType.Scroll:
				return new ScrollEvent (raw);
			}
			return evnt;
		}
	}
}
