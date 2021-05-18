using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;

namespace GridDemo
{
    public partial class MainWindow : Window
    {
        private ItemsControl TilesItemsControl { get; set; }

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            TilesItemsControl = this.Find<ItemsControl>("TilesItemsControl");
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void LayoutComboBox_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            (this.DataContext as MainWindowViewModel)?.UpdateTiles();

            // TilesItemsControl?.InvalidateMeasure();
            // TilesItemsControl?.InvalidateArrange();

            // if (TilesItemsControl != null)
            // {
            //     var customGrid = TilesItemsControl.GetVisualChildren().FirstOrDefault().GetVisualChildren().FirstOrDefault().GetVisualChildren().FirstOrDefault() as CustomGrid;
            //     if (customGrid != null)
            //     {
            //         customGrid.InvalidateDefinitions();
            //     }
            // }
        }
    }
}