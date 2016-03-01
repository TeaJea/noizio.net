using System;
using System.IO;
using System.Windows;

namespace Noizio.Net.Models
  {
  public class MediaPlayer : IDisposable
    {
    private readonly System.Windows.Media.MediaPlayer _player;
    private readonly Uri _mediaUri;

    private bool _isPlaying;

    public MediaPlayer(Media media)
      {
      Media = media;
      _mediaUri = _getMediaUrl(media.Path);
      _player = new System.Windows.Media.MediaPlayer();
      _player.Open(_mediaUri);
      _player.Volume = 0.0;

      _player.MediaEnded += (s, a) =>
        {
        if (!_isPlaying) return;
        _player.Open(_mediaUri);
        _player.Play();
        };
      }

    public bool IsPlaying
      {
      get { return _isPlaying; }
      set
        {
        _isPlaying = value;
        if (_isPlaying) _player.Play();
        else _player.Pause(); 
        }
      }

    public double Volume
      {
      get { return _player.Volume; }
      set { _player.Volume = value; }
      }

    public Media Media { get; }

    public void Dispose()
      {
      _player.Stop();
      }

    private static readonly string TempFolder = Path.GetTempPath();

    private static Uri _getMediaUrl(string path)
      {
      var uri = Path.Combine(TempFolder, "Noizio", path.Replace('/', '\\'));
      if (File.Exists(uri)) return new Uri(uri);

      var dir = Path.GetDirectoryName(uri);
      if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

      var uriResource = new Uri("/Resources/" + path, UriKind.Relative);
      var resourceInfo = Application.GetResourceStream(uriResource);
      using (var file = new FileStream(uri, FileMode.OpenOrCreate))
        {
        resourceInfo?.Stream.CopyTo(file);
        }

      return new Uri(uri);
      }
    }
  }
