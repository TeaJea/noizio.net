using System;
using Microsoft.Win32;

namespace Noizio.Net.Helpers
  {
  public class RegistryHelpers
    {
    public static RegistryKey GetRegistryKey()
      {
      return GetRegistryKey(null);
      }

    public static RegistryKey GetRegistryKey(string keyPath, bool writable = false)
      {
      var localMachineRegistry = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser,
                                      Environment.Is64BitOperatingSystem
                                          ? RegistryView.Registry64
                                          : RegistryView.Registry32);

      return string.IsNullOrEmpty(keyPath)
          ? localMachineRegistry
          : localMachineRegistry.OpenSubKey(keyPath, writable);
      }

    public static object GetRegistryValue(string keyPath, string keyName)
      {
      var registry = GetRegistryKey(keyPath);
      return registry.GetValue(keyName);
      }
    }
  }
