using System;
using System.Windows;
using System.Windows.Controls;

namespace Noizio.Net.Controls
  {
  /// <summary>
  /// Interaction logic for MetroImageButton.xaml
  /// </summary>
  public partial class MetroImageButton : Button
    {
    public MetroImageButton()
      {
      InitializeComponent();
      }

    public static readonly DependencyProperty BrushProperty =
      DependencyProperty.Register( "Brush", typeof(object),
      typeof(MetroImageButton), new FrameworkPropertyMetadata(null));

    // .NET Property wrapper
    public object Brush
      {
      get { return (DateTime) GetValue(BrushProperty); }
      set { SetValue(BrushProperty, value); }
      }
    }
  }
