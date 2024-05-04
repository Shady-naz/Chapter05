using System.Diagnostics; // StopWatch
using System.Runtime.CompilerServices;
using static System.Diagnostics.Process;

namespace Packt.Shared;

public static class Recorder
{
    private static Stopwatch timer = new();

    private static long physicalBytesBefore = 0;
    private static long virtualBytesBefore = 0;

    public static void Start ()
    {
        // force some garbage collections to release memory that is
        // no longer referenced but has not been released yet
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        physicalBytesBefore = GetCurrentProcess().WorkingSet64;
        virtualBytesBefore = GetCurrentProcess().VirtualMemorySize64;

        timer.Restart ();
    }

    public static void Stop()
    {
        timer.Stop();
        long phsicalBytesAfter = GetCurrentProcess().WorkingSet64;
        long virtualBytesAfter = GetCurrentProcess() .VirtualMemorySize64;

        WriteLine("{0:N0} physical bytes was used.",
            phsicalBytesAfter - physicalBytesBefore);
        WriteLine("{0:N0} virtual bytes was used.",
            virtualBytesAfter - virtualBytesBefore);
        WriteLine("{0} time span elapsed.", timer.Elapsed);
        WriteLine("{0:N0} total milliseconds elapsed.",
            timer.ElapsedMilliseconds);
    }
}
