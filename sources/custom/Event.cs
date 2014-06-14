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
	}
}
