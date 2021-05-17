using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using Avalonia;
using Avalonia.Controls;

namespace GridDemo
{
    public class CustomGrid : Grid
    {
        public static readonly StyledProperty<string?> ColumnDefinitionsSourceProperty = 
            AvaloniaProperty.Register<CustomGrid, string?>(nameof(ColumnDefinitionsSource));

        public static readonly StyledProperty<string?> RowDefinitionsSourceProperty = 
            AvaloniaProperty.Register<CustomGrid, string?>(nameof(RowDefinitionsSource));

        public string? ColumnDefinitionsSource
        {
            get => GetValue(ColumnDefinitionsSourceProperty);
            set => SetValue(ColumnDefinitionsSourceProperty, value);
        }

        public string? RowDefinitionsSource
        {
            get => GetValue(RowDefinitionsSourceProperty);
            set => SetValue(RowDefinitionsSourceProperty, value);
        }

        public CustomGrid()
        {
            InvalidateDefinitions();
        }

        protected override void OnPropertyChanged<T>(AvaloniaPropertyChangedEventArgs<T> change)
        {
            base.OnPropertyChanged(change);

            if (change.Property == ColumnDefinitionsSourceProperty
                || change.Property == RowDefinitionsSourceProperty)
            {
                InvalidateDefinitions();
            }
        }

        private static readonly FieldInfo? s_cellsStructureDirty = typeof(Grid).GetField("CellsStructureDirty ", BindingFlags.NonPublic | BindingFlags.Instance);
        
        private void InvalidateDefinitions()
        {
            if (ColumnDefinitionsSource is not null && RowDefinitionsSource is not null)
            {
                // ColumnDefinitions = ColumnDefinitions.Parse(ColumnDefinitionsSource);
                var columns = GridLength.ParseLengths(ColumnDefinitionsSource).Select(x => new ColumnDefinition(x));
                ColumnDefinitions.Clear();
                ColumnDefinitions.AddRange(columns);

                // RowDefinitions = RowDefinitions.Parse(RowDefinitionsSource);
                var rows = GridLength.ParseLengths(RowDefinitionsSource).Select(x => new RowDefinition(x));
                RowDefinitions.Clear();
                RowDefinitions.AddRange(rows);

                // HACK
                // ChildrenChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                s_cellsStructureDirty.SetValue(true, this);

                InvalidateMeasure();
                InvalidateArrange();
            }
        }
    }
}