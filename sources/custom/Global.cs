// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter.GTK {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

	public partial class Global {

		[DllImport("clutter-gtk-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern int gtk_clutter_init(ref int argc, ref IntPtr[] argv);

		public static Clutter.InitError Init(string[] argv) {
			int cnt_argv = argv == null ? 0 : argv.Length;
			IntPtr[] native_argv = new IntPtr [cnt_argv];
			for (int i = 0; i < cnt_argv; i++)
				native_argv [i] = GLib.Marshaller.StringToPtrGStrdup(argv[i]);
			int raw_ret = gtk_clutter_init(ref cnt_argv, ref native_argv);
			Clutter.InitError ret = (Clutter.InitError) raw_ret;
			return ret;
		}

		public static Clutter.InitError Init() {
			return Init(new string[] { "" });
		}
	}
}
