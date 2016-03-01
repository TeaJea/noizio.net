using Noizio.Net.Helpers;
using PropertyChanged;

namespace Noizio.Net.ViewModels
  {
  [ImplementPropertyChanged]
  public class SettingsViewModel : INoizioViewModel
    {
    public bool StartAtLogin
      {
      get { return AppStartupTools.IsLaunchedAtLogin(); }
      set { AppStartupTools.SetLaunchAtLogin(value); }
      }

    public bool PlayAfterLaunch
      {
      get { return Properties.Settings.Default.PlayOnLaunch; }
      set { Properties.Settings.Default.PlayOnLaunch = value; Properties.Settings.Default.Save(); }
      }

    public double Volume {
      get { return Properties.Settings.Default.GlobalVolume; }
      set { Properties.Settings.Default.GlobalVolume = value; Properties.Settings.Default.Save(); } }
    }
  }
