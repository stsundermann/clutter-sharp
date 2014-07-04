SUBDIRS = sources sources/glue doc samples

pkgconfigdir = $(libdir)/pkgconfig
pkgconfig_DATA = clutter-sharp-1.0.pc

EXTRA_DIST = clutter-sharp-1.0.pc.in
DISTCLEANFILES = clutter-sharp-1.0.pc

regenerate:
	bindinate --regenerate=true --merge-with=GtkClutter-1.0,ClutterGst-2.0 --gir=Clutter-1.0
