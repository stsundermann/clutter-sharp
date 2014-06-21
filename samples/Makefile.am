TARGETS = basic-actor.exe canvas.exe

DEBUGS = $(addsuffix .mdb, $(TARGETS))
assemblies = 					\
	$(top_builddir)/out/clutter-sharp.dll

references=$(addprefix -r:, $(assemblies))

noinst_SCRIPTS = $(TARGETS)
CLEANFILES = $(TARGETS) $(DEBUGS)

basic-actor.exe: $(srcdir)/BasicActor.cs $(assemblies)
	$(CSC) $(CSFLAGS) -out:basic-actor.exe $(references) $(GTK_SHARP_LIBS) $(srcdir)/BasicActor.cs

canvas.exe: $(srcdir)/Canvas.cs $(assemblies)
	$(CSC) $(CSFLAGS) -out:canvas.exe $(references) $(GTK_SHARP_LIBS) $(srcdir)/Canvas.cs

EXTRA_DIST = 				\
	BasicActor.cs \
    Canvas.cs
