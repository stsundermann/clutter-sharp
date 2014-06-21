TARGETS = basic-actor.exe

DEBUGS = $(addsuffix .mdb, $(TARGETS))
assemblies = 					\
	$(top_builddir)/out/clutter-sharp.dll

references=$(addprefix -r:, $(assemblies))

noinst_SCRIPTS = $(TARGETS)
CLEANFILES = $(TARGETS) $(DEBUGS)

basic-actor.exe: $(srcdir)/BasicActor.cs $(assemblies)
	$(CSC) $(CSFLAGS) -out:basic-actor.exe $(references) $(GTK_SHARP_LIBS) $(CLUTTERSHARP_LIBS) $(srcdir)/BasicActor.cs

EXTRA_DIST = 				\
	BasicActor.cs
