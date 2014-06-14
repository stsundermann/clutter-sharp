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
		static extern void clutter_actor_get_abs_allocation_vertices(IntPtr raw, out IntPtr[] verts);

		/*public Clutter.Vertex[] AbsAllocationVertices { 
			get {
				Clutter.Vertex[] verts = new Clutter.Vertex[4];
				IntPtr[] native_verts = new IntPtr[4];
				clutter_actor_get_abs_allocation_vertices(Handle, out native_verts);
				for (int i = 0; i < native_verts.Length; i++) {
					verts [i] = new Clutter.Vertex (native_verts [i]);
				}
				return verts;
			}
		}

		[DllImport("clutter-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern void clutter_actor_get_allocation_vertices(IntPtr raw, IntPtr ancestor, out IntPtr[] verts);

		public Clutter.Vertex[] GetAllocationVertices(Clutter.Actor ancestor) {
			Clutter.Vertex[] verts = new Clutter.Vertex[4];
			IntPtr[] native_verts = new IntPtr[4];
			clutter_actor_get_allocation_vertices(Handle, ancestor == null ? IntPtr.Zero : ancestor.Handle, out native_verts);
			for (int i = 0; i < native_verts.Length; i++) {
				verts [i] = new Clutter.Vertex (native_verts [i]);
			}
			return verts;
		}*/
	}
}