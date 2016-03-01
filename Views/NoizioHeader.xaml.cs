using System.Windows;
using System.Windows.Controls;

namespace Noizio.Net.Views
  {
  /// <summary>
  /// Interaction logic for NoizioHeader.xaml
  /// </summary>
  public partial class NoizioHeader : UserControl
    {
    public NoizioHeader()
      {
      InitializeComponent();
      }

    // Dependency Property
    public static readonly DependencyProperty LeftButtonProperty =
      DependencyProperty.Register( "LeftButton", typeof(DataTemplate),
      typeof(NoizioHeader), new FrameworkPropertyMetadata(null));

    public static readonly DependencyProperty RightButtonProperty =
      DependencyProperty.Register( "RightButton", typeof(DataTemplate),
      typeof(NoizioHeader), new FrameworkPropertyMetadata(null));

    // .NET Property wrapper
    public DataTemplate LeftButton
      {
      get { return (DataTemplate) GetValue(LeftButtonProperty); }
      set { SetValue(LeftButtonProperty, value); }
      }

    public DataTemplate RightButton
      {
      get { return (DataTemplate) GetValue(RightButtonProperty); }
      set { SetValue(RightButtonProperty, value); }
      }
    }
  }
