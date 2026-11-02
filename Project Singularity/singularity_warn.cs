using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

class Launcher
{
    [STAThread]
    static void Main()
    {
        DialogResult result = MessageBox.Show(
            "WARNING! THIS IS NOT A JOKE. ARE YOU SURE YOU WANT TO CONTINUE?",
            "Warning",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2 // defaults focus to "No" so an accidental Enter press doesn't confirm
        );

        if (result != DialogResult.Yes)
        {
            return; // user clicked No — exit immediately, nothing runs
        }

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