namespace Noizio.Net.ViewModels
  {
  public class NoizioHeaderViewModel
    {
    public ApplicationViewModel AppViewModel { get; set; }

    public NoizioHeaderViewModel(ApplicationViewModel appViewModel)
      {
      AppViewModel = appViewModel;
      }
    }

  public class CurrentSoundHeaderViewModel : NoizioHeaderViewModel
    {
    public CurrentSoundHeaderViewModel(ApplicationViewModel appViewModel) : base(appViewModel) {}
    }

  public class SettingsHeaderViewModel : NoizioHeaderViewModel
    {
    public SettingsHeaderViewModel(ApplicationViewModel appViewModel) : base(appViewModel) {}
    }

  public class AboutHeaderViewModel : NoizioHeaderViewModel
    {
    public AboutHeaderViewModel(ApplicationViewModel appViewModel) : base(appViewModel) { }
    }
  }
