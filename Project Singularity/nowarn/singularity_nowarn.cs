using System;
using System.Diagnostics;
using System.IO;

class Launcher
{
    static void Main()
    {
        string exeDir = AppDomain.CurrentDomain.BaseDirectory;
        string batPath = Path.Combine(exeDir, "setup.bat");

        Process.Start(new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = $"/c \"{batPath}\"",
            WorkingDirectory = exeDir,
            UseShellExecute = false,
            CreateNoWindow = true,
            WindowStyle = ProcessWindowStyle.Hidden
        });
    }
}