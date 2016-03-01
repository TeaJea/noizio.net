namespace Noizio.Net.Models
  {
  public static class MediaStorage
    {
    public const string ResourceBase = @"pack://application:,,,/Resources/";

    public static readonly Media[] AllMedia =
      {
      new Media("North Sea",      "Icons/sea.png",      @"Audio/north_sea.mp3"),
      new Media("Forest Birds",   "Icons/forest.png",   @"Audio/forest_birds.wav"),
      new Media("Autumn Rain",    "Icons/rain.png",     @"Audio/heavy_rain.mp3"),
      new Media("Mountain River", "Icons/river.png",    @"Audio/mountain_river.wav"),
      new Media("Paris Cafe",     "Icons/food.png",     @"Audio/paris_cafe.mp3"),
      new Media("Wind Chimes",    "Icons/music.png",    @"Audio/chimes.mp3"),
      new Media("Campfire",       "Icons/fire.png",     @"Audio/fire.mp3"),
      new Media("Free Willy",     "Icons/willy.png",    @"Audio/whale.mp3"),
      new Media("Summer Night",   "Icons/moon.png",     @"Audio/summer_night.mp3"),
      };
    }
  }
