using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

public static class Logger
{
    static IVsOutputWindowPane pane;
    static object _syncRoot = new object();
    static string _name;

    public static void Initialize(string name)
    {
        _name = name;
    }

    [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "Microsoft.VisualStudio.Shell.Interop.IVsOutputWindowPane.OutputString(System.String)")]
    public static void Log(string message)
    {
        if (string.IsNullOrEmpty(message))
            return;

        try
        {
            if (EnsurePane())
            {
                pane.OutputString(DateTime.Now + ": " + message + Environment.NewLine);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Write(ex);
        }
    }

    public static void Log(Exception ex)
    {
        if (ex != null)
        {
            Log(ex.ToString());
        }
    }

    static bool EnsurePane()
    {
        if (pane == null)
        {
            Guid guid = Guid.NewGuid();
            var output = (IVsOutputWindow)Package.GetGlobalService(typeof(SVsOutputWindow));
            output.CreatePane(ref guid, _name, 1, 1);
            output.GetPane(ref guid, out pane);
        }

        return pane != null;
    }
}