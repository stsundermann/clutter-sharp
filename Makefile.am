SUBDIRS = sources sources/glue doc

pkgconfigdir = $(libdir)/pkgconfig
pkgconfig_DATA = clutter-sharp-1.0.pc

EXTRA_DIST = clutter-sharp-1.0.pc.in
DISTCLEANFILES = clutter-sharp-1.0.pc

regenerate:
	bindinate --regenerate=true --gir=Clutter-1.0
