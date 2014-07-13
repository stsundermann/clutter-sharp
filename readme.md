clutter-sharp
=========

clutter-sharp is a .NET/mono binding for Clutter generated from gobject-introspection data using the [bindinator]. clutter-sharp wraps the API exposed by Clutter 1.18 and is compatible with newer clutter versions. It was developed under GSoC 2014 for the mono organization.

License
----
clutter-sharp is licensed under the MIT License
```
The MIT License (MIT)

Copyright (c) 2014 Stephan Sundermann

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```

Prerequisites
----
These libraries are needed for clutter-sharp to compile:
* [cogl-sharp] 1.18 or higher
* [clutter] 1.18 or higher
* [clutter-gtk] 1.4 or higher
* [clutter-gst] 2.0 or higher
* [cogl] 1.18 or higher
* [gtk-sharp] 2.99.3 or higher

Building & Installing
----
Simply type ./autogen.sh && make install

Getting started
----
There are a bunch of samples for clutter(-gst/-gtk) in the samples folder which are ported from clutter-sharp.

Documentation
----
Since this is a gobject-introspection binding the recommended documentation is to use the native [clutter](https://developer.gnome.org/clutter/stable/) documentation. There is also a monodoc documentation in the doc folder.

Authors
----
Stephan Sundermann

[bindinator]:https://github.com/andreiagaita/bindinator/
[clutter]:https://github.com/GNOME/clutter/
[clutter-gst]:https://github.com/GNOME/clutter-gst/
[clutter-gtk]:https://github.com/GNOME/clutter-gtk/
[cogl]:https://github.com/GNOME/cogl/
[cogl-sharp]:https://github.com/xdarkice/cogl-sharp
[gtk-sharp]:https://github.com/mono/gtk-sharp
[clutter-docs]:https://developer.gnome.org/clutter/stable/
