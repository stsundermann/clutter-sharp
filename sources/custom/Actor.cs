//
// Fixes for Actor
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
using System.Runtime.InteropServices;

namespace Clutter {
		partial class Actor {
		[DllImport("clutter-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern void clutter_actor_get_abs_allocation_vertices(IntPtr raw, Clutter.Vertex[] verts);

		public Clutter.Vertex[] AbsAllocationVertices { 
			get {
				Clutter.Vertex[] verts = new Clutter.Vertex[4];
				clutter_actor_get_abs_allocation_vertices(Handle, verts);
				return verts;
			}
		}

		[DllImport("clutter-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern void clutter_actor_get_allocation_vertices(IntPtr raw, IntPtr ancestor, Clutter.Vertex[] verts);

		public Clutter.Vertex[] GetAllocationVertices(Clutter.Actor ancestor) {
			Clutter.Vertex[] verts = new Clutter.Vertex[4];
			clutter_actor_get_allocation_vertices(Handle, ancestor == null ? IntPtr.Zero : ancestor.Handle, verts);
			return verts;
		}

		[DllImport("clutter-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr clutter_actor_animatev(IntPtr raw, UIntPtr mode, uint duration, int n_properties, IntPtr[] properties, GLib.Value[] values);

		[Obsolete]
		public Clutter.Animation Animatev(ulong mode, uint duration, string[] properties, GLib.Value[] values) {
			int cnt_properties = properties == null ? 0 : properties.Length;
			IntPtr[] native_properties = new IntPtr [cnt_properties];
			for (int i = 0; i < cnt_properties; i++)
				native_properties [i] = GLib.Marshaller.StringToPtrGStrdup (properties[i]);
			int cnt_values = values == null ? 0 : values.Length;
			IntPtr raw_ret = clutter_actor_animatev(Handle, new UIntPtr (mode), duration, (properties == null ? 0 : properties.Length), native_properties, values);
			Clutter.Animation ret = GLib.Object.GetObject(raw_ret) as Clutter.Animation;
			for (int i = 0; i < native_properties.Length; i++) {
				properties [i] = GLib.Marshaller.Utf8PtrToString (native_properties[i]);
				GLib.Marshaller.Free (native_properties[i]);
			}
			return ret;
		}


		[DllImport("clutter-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr clutter_actor_animate_with_alphav(IntPtr raw, IntPtr alpha, int n_properties, IntPtr[] properties, GLib.Value[] values);

		[Obsolete]
		public Clutter.Animation AnimateWithAlphav(Clutter.Alpha alpha, string[] properties, GLib.Value[] values) {
			int cnt_properties = properties == null ? 0 : properties.Length;
			IntPtr[] native_properties = new IntPtr [cnt_properties];
			for (int i = 0; i < cnt_properties; i++)
				native_properties [i] = GLib.Marshaller.StringToPtrGStrdup (properties[i]);
			int cnt_values = values == null ? 0 : values.Length;
			IntPtr raw_ret = clutter_actor_animate_with_alphav(Handle, alpha == null ? IntPtr.Zero : alpha.Handle, (properties == null ? 0 : properties.Length), native_properties, values);
			Clutter.Animation ret = GLib.Object.GetObject(raw_ret) as Clutter.Animation;
			for (int i = 0; i < native_properties.Length; i++) {
				properties [i] = GLib.Marshaller.Utf8PtrToString (native_properties[i]);
				GLib.Marshaller.Free (native_properties[i]);
			}
			return ret;
		}

		[DllImport("clutter-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr clutter_actor_animate_with_timelinev(IntPtr raw, UIntPtr mode, IntPtr timeline, int n_properties, IntPtr[] properties, GLib.Value[] values);

		[Obsolete]
		public Clutter.Animation AnimateWithTimelinev(ulong mode, Clutter.Timeline timeline, string[] properties, GLib.Value[] values) {
			int cnt_properties = properties == null ? 0 : properties.Length;
			IntPtr[] native_properties = new IntPtr [cnt_properties];
			for (int i = 0; i < cnt_properties; i++)
				native_properties [i] = GLib.Marshaller.StringToPtrGStrdup (properties[i]);
			int cnt_values = values == null ? 0 : values.Length;
			IntPtr raw_ret = clutter_actor_animate_with_timelinev(Handle, new UIntPtr (mode), timeline == null ? IntPtr.Zero : timeline.Handle, (properties == null ? 0 : properties.Length), native_properties, values);
			Clutter.Animation ret = GLib.Object.GetObject(raw_ret) as Clutter.Animation;
			for (int i = 0; i < native_properties.Length; i++) {
				properties [i] = GLib.Marshaller.Utf8PtrToString (native_properties[i]);
				GLib.Marshaller.Free (native_properties[i]);
			}
			return ret;
		}

	}
}
