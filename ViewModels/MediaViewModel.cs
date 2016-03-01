using System.ComponentModel;
using Noizio.Net.Models;

namespace Noizio.Net.ViewModels
  {
  public class MediaViewModel : INotifyPropertyChanged
    {
    public MediaViewModel(Media media)
      {
      Media = media;
      }

    public Media Media { get; protected set; }
    public double Volume { get; set; }

    public string Image => $"{MediaStorage.ResourceBase}{Media.Icon}";
    public event PropertyChangedEventHandler PropertyChanged;
    }
  }
