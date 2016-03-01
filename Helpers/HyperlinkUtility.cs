using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace Noizio.Net.Helpers
  {
  public static class HyperlinkUtility
    {
    public static readonly DependencyProperty LaunchDefaultBrowserProperty =
      DependencyProperty.RegisterAttached("LaunchDefaultBrowser", typeof(bool), typeof(HyperlinkUtility), new PropertyMetadata(false, HyperlinkUtility_LaunchDefaultBrowserChanged));

    public static bool GetLaunchDefaultBrowser(DependencyObject d)
      {
      return (bool) d.GetValue(LaunchDefaultBrowserProperty);
      }

    public static void SetLaunchDefaultBrowser(DependencyObject d, bool value)
      {
      d.SetValue(LaunchDefaultBrowserProperty, value);
      }

    private static void HyperlinkUtility_LaunchDefaultBrowserChanged(object sender, DependencyPropertyChangedEventArgs e)
      {
      DependencyObject d = (DependencyObject) sender;
      if ((bool) e.NewValue)
        (d as ContentElement).AddHandler(Hyperlink.RequestNavigateEvent, new RequestNavigateEventHandler(Hyperlink_RequestNavigateEvent));
      else
        (d as ContentElement).RemoveHandler(Hyperlink.RequestNavigateEvent, new RequestNavigateEventHandler(Hyperlink_RequestNavigateEvent));
      }

    private static void Hyperlink_RequestNavigateEvent(object sender, RequestNavigateEventArgs e)
      {
      Process.Start(e.Uri.AbsoluteUri);
      e.Handled = true;
      }
    }
  }