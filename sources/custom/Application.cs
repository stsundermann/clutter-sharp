//
// Fixes for Application
//
// Author:
//   Stephan Sundermann <stephansundermann@gmail.com>
//
// Copyright (c) 2014 Stephan Sundermann
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Clutter {

	public partial class Application {

		[DllImport("clutter-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern int clutter_init(ref int argc, IntPtr argv);

		[DllImport("clutter-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern int clutter_init(IntPtr argc, IntPtr argv);

		public static Clutter.InitError Init(string[] argv) {
			IntPtr native_argv = GLib.Marshaller.StringArrayToNullTermStrvPointer (argv);
			int argc = argv.Length;
			int raw_ret = clutter_init(ref argc, native_argv);
			Clutter.InitError ret = (Clutter.InitError) raw_ret;
			return ret;
		}

		public static Clutter.InitError Init () {
			return (Clutter.InitError) clutter_init (IntPtr.Zero, IntPtr.Zero);
		}
	}
}

namespace Clutter.Gstreamer {

	public partial class Application {

		[DllImport("clutter-gst-2.0", CallingConvention = CallingConvention.Cdecl)]
		static extern int clutter_gst_init(ref int argc, IntPtr argv);

		[DllImport("clutter-gst-2.0", CallingConvention = CallingConvention.Cdecl)]
		static extern int clutter_gst_init(IntPtr argc, IntPtr argv);

		public static Clutter.InitError Init(string[] argv) {
			IntPtr native_argv = GLib.Marshaller.StringArrayToNullTermStrvPointer (argv);
			int argc = argv.Length;
			int raw_ret = clutter_gst_init(ref argc, native_argv);
			Clutter.InitError ret = (Clutter.InitError) raw_ret;
			return ret;
		}

		public static Clutter.InitError Init () {
			return (Clutter.InitError) clutter_gst_init (IntPtr.Zero, IntPtr.Zero);
		}
	}
}

namespace Clutter.GTK {

	public partial class Application {

		[DllImport("clutter-gtk-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern int gtk_clutter_init(ref int argc, IntPtr argv);

		[DllImport("clutter-gtk-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern int gtk_clutter_init(IntPtr argc, IntPtr argv);

		public static Clutter.InitError Init(string[] argv) {
			IntPtr native_argv = GLib.Marshaller.StringArrayToNullTermStrvPointer (argv);
			int argc = argv.Length;
			int raw_ret = gtk_clutter_init(ref argc, native_argv);
			Clutter.InitError ret = (Clutter.InitError) raw_ret;
			return ret;
		}

		public static Clutter.InitError Init () {
			return (Clutter.InitError) gtk_clutter_init (IntPtr.Zero, IntPtr.Zero);
		}
	}
}