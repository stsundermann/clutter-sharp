TARGETS = basic-actor.exe canvas.exe pan-action.exe rounded-rectangle.exe scroll-actor.exe image-content.exe constraints.exe gtk-window-test.exe video-sink.exe

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

pan-action.exe: $(srcdir)/PanAction.cs $(assemblies)
	$(CSC) $(CSFLAGS) -out:pan-action.exe $(references) $(GTK_SHARP_LIBS) $(COGLSHARP_LIBS) $(srcdir)/PanAction.cs

rounded-rectangle.exe: $(srcdir)/RoundedRectangle.cs $(assemblies)
	$(CSC) $(CSFLAGS) -out:rounded-rectangle.exe $(references) $(GTK_SHARP_LIBS) $(srcdir)/RoundedRectangle.cs

scroll-actor.exe: $(srcdir)/ScrollActor.cs $(assemblies)
	$(CSC) $(CSFLAGS) -out:scroll-actor.exe $(references) $(GTK_SHARP_LIBS) $(srcdir)/ScrollActor.cs

image-content.exe: $(srcdir)/ImageContent.cs $(assemblies)
	$(CSC) $(CSFLAGS) -out:image-content.exe $(references) $(GTK_SHARP_LIBS) $(COGLSHARP_LIBS) $(srcdir)/ImageContent.cs

constraints.exe: $(srcdir)/Constraints.cs $(assemblies)
	$(CSC) $(CSFLAGS) -out:constraints.exe $(references) $(GTK_SHARP_LIBS) $(srcdir)/Constraints.cs

gtk-window-test.exe: $(srcdir)/GtkWindowTest.cs $(assemblies)
	$(CSC) $(CSFLAGS) -out:gtk-window-test.exe $(references) $(GTK_SHARP_LIBS) $(srcdir)/GtkWindowTest.cs

video-sink.exe: $(srcdir)/VideoSink.cs $(assemblies)
	$(CSC) $(CSFLAGS) -out:video.sink.exe $(references) $(GTK_SHARP_LIBS) $(GSTREAMERSHARP_LIBS) $(srcdir)/VideoSink.cs

EXTRA_DIST = 				\
	BasicActor.cs \
    Canvas.cs \
    PanAction.cs \
    RoundedRectangle.cs \
    ScrollActor.cs \
    ImageContent.cs \
    Constraints.cs \
    GtkWindowTest.cs \
    VideoSink.cs \
    redhand.png
