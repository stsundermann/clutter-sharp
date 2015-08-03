//
// Fixes for Texture
//
// Author:
//   Stephan Sundermann <stephansundermann@gmail.com>
//
// Copyright (c) 2015 Stephan Sundermann
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
		static extern unsafe bool clutter_texture_set_from_rgb_data(IntPtr raw, IntPtr data, bool has_alpha, int width, int height, int rowstride, int bpp, int flags, out IntPtr error);

		[Obsolete]
		public unsafe bool SetFromRgbData(IntPtr data, bool has_alpha, int width, int height, int rowstride, int bpp, Clutter.TextureFlags flags) {
			IntPtr error = IntPtr.Zero;
			bool raw_ret = clutter_texture_set_from_rgb_data(Handle, data, has_alpha, width, height, rowstride, bpp, (int) flags, out error);
			bool ret = raw_ret;
			if (error != IntPtr.Zero) throw new GLib.GException (error);
			return ret;
		}

	}		
}
