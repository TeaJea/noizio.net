using System;
using System.Collections.Generic;
using System.Linq;
using Noizio.Net.Models;
using PropertyChanged;

namespace Noizio.Net.ViewModels
  {
  [ImplementPropertyChanged]
  public class CurrentSoundViewModel : INoizioViewModel
    {
    private bool _isPlaying;
    private double _volume = Properties.Settings.Default.GlobalVolume;
    private readonly Media[] _allMedia = MediaStorage.AllMedia;
    private readonly List<MediaPlayer> _activePlayers = new List<MediaPlayer>();
    
    public CurrentSoundViewModel()
      {
      MediaViewModels = _allMedia.Select(m => new MediaViewModel(m)).ToList();
      MediaViewModels.ForEach(mvm => mvm.PropertyChanged +=
        (s, e) => { if (e.PropertyName == "Volume") { _updateVolume((MediaViewModel) s); _saveMediaVolumes(); } });
      Properties.Settings.Default.PropertyChanged +=
        (s, e) => { if (e.PropertyName == "GlobalVolume") _updateGlobalVolume(); };

      _restoreMediaVolumes();
      _updateGlobalVolume();
      IsPlaying = Properties.Settings.Default.PlayOnLaunch;
      }

    public List<MediaViewModel> MediaViewModels { get; protected set; }

    public bool IsPlaying
      {
      get { return _isPlaying; }
      set
        {
        if (_isPlaying != value) _activePlayers.ForEach(p => p.IsPlaying = value);
        _isPlaying = value;
        }
      }

    private void _updateGlobalVolume()
      {
      _volume = Properties.Settings.Default.GlobalVolume;
      MediaViewModels.ForEach(_updateVolume);
      }

    private void _updateVolume(MediaViewModel mvm)
      {
      var player = _activePlayers.FirstOrDefault(p => p.Media.Name == mvm.Media.Name);
      if (mvm.Volume < 0.01 && player != null)
        {
        player.Dispose();
        _activePlayers.Remove(player);
        }
      else if (mvm.Volume >= 0.01)
        {
        if (player == null)
          {
          player = new MediaPlayer(mvm.Media);
          _activePlayers.Add(player);
          }
        player.Volume = mvm.Volume * _volume;
        player.IsPlaying = _isPlaying;
        }
      }

    private void _restoreMediaVolumes()
      {
      var volumes = Properties.Settings.Default.MediaVolumes.Split(';')
        .Select(vol => vol.Split('=')).ToDictionary(vol => vol[0], vol => Convert.ToDouble(vol.ElementAtOrDefault(1)));
      MediaViewModels.ForEach(mvm => { if (volumes.ContainsKey(mvm.Media.Name)) mvm.Volume = volumes[mvm.Media.Name]; });
      }

    private void _saveMediaVolumes()
      {
      Properties.Settings.Default.MediaVolumes =
        string.Join(";", MediaViewModels.Select(mvm => $"{mvm.Media.Name}={mvm.Volume}"));
      Properties.Settings.Default.Save();
      }
    }
  }
