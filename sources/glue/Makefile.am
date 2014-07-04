lib_LTLIBRARIES = libcluttersharpglue-1.18.0.la

libcluttersharpglue_1_18_0_la_SOURCES =

nodist_libcluttersharpglue_1_18_0_la_SOURCES = generated.c

libcluttersharpglue_1_18_0_la_LDFLAGS = -module -avoid-version -no-undefined

libcluttersharpglue_1_18_0_la_LIBADD = $(CLUTTER_LIBS) $(CLUTTERGST_LIBS) $(CLUTTERGTK_LIBS)

INCLUDES = $(CLUTTER_CFLAGS) $(CLUTTERGST_CFLAGS) $(CLUTTERGTK_CFLAGS) -I$(top_srcdir)

libcluttersharpglue.dll: $(libcluttersharpglue_1_18_0_la_OBJECTS) libcluttersharpglue.rc libcluttersharpglue.def
	./build-dll libcluttersharpglue $(VERSION)

CLEANFILES = lib*.a lib*.dll

EXTRA_DIST =
