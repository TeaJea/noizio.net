namespace Noizio.Net.Models
  {
  public struct Media
    {
    public string Name { get; set; }
    public string Icon { get; set; }
    public string Path { get; set; }

    public Media(string name, string icon, string path)
      {
      Name = name;
      Icon = icon;
      Path = path;
      }
    }
  }
