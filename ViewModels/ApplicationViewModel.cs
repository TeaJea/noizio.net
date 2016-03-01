using System.Windows;
using System.Windows.Input;
using Noizio.Net.Helpers;
using PropertyChanged;

namespace Noizio.Net.ViewModels
  {
  [ImplementPropertyChanged]
  public class ApplicationViewModel
    {
    private readonly CurrentSoundViewModel _currentSound;
    private readonly SettingsViewModel _settings;
    private readonly AboutViewModel _about;

    public ApplicationViewModel()
      {
      _currentSound = new CurrentSoundViewModel();
      _settings = new SettingsViewModel();
      _about = new AboutViewModel();
      ActiveViewModel = _currentSound;
      }

    public INoizioViewModel ActiveViewModel { get; protected set; }

    public NoizioHeaderViewModel HeaderViewModel =>
      ActiveViewModel == _settings  ? new SettingsHeaderViewModel(this) :
      ActiveViewModel == _about     ? new AboutHeaderViewModel(this) :
                                      new CurrentSoundHeaderViewModel(this) as NoizioHeaderViewModel;

    public ICommand OpenSettings => new RelayCommand<object>(_ => ActiveViewModel = _settings, _ => ActiveViewModel != _settings);
    public ICommand OpenAbout => new RelayCommand<object>(_ => ActiveViewModel = _about, _ => ActiveViewModel != _about);

    public ICommand BackToSounds => new RelayCommand<object>(_ => ActiveViewModel = _currentSound);
    public ICommand BackToSettings => new RelayCommand<object>(_ => ActiveViewModel = _settings);

    public ICommand QuitApp => new RelayCommand<object>(_ => Application.Current.Shutdown());

    public bool IsPlaying
      {
      get { return _currentSound.IsPlaying; }
      set { _currentSound.IsPlaying = value; }
      }

    public int ContentPresenterHeight => _currentSound.MediaViewModels.Count * 46;
    }
  }
