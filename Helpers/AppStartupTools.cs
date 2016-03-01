namespace Noizio.Net.Helpers
  {
  public static class AppStartupTools
    {
    private const string RegKeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
    private static readonly string AppName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
    private static readonly string ExecutablePath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;

    public static bool IsLaunchedAtLogin()
      {
      var key = RegistryHelpers.GetRegistryKey(RegKeyPath);
      return key?.GetValue(AppName) != null;
      }

    public static void SetLaunchAtLogin(bool launch)
      {
      var key = RegistryHelpers.GetRegistryKey(RegKeyPath, true);
      if (launch) key?.SetValue(AppName, ExecutablePath);
      else if (key?.GetValue(AppName) != null) key.DeleteValue(AppName);
      }
    }
  }
