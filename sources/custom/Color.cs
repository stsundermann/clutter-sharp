//
// Fixes for Color
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

	public partial struct Color {

		public static Color New (float r, float g, float b, float a) {
			return New ((byte)(r * 0xff), (byte)(g * 0xff), (byte)(b * 0xff), (byte)(a * 0xff));
		}

		[DllImport("clutter-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr clutter_color_alloc();

		public static Color Alloc()
		{
			Color result = Color.New (clutter_color_alloc());
			return result;
		}
	}
}
