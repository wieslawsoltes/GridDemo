using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

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
            TilesItemsControl?.InvalidateMeasure();
            TilesItemsControl?.InvalidateArrange();
        }
    }
}