using System.Linq;
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

        // static CustomGrid()
        // {
        //     AffectsParentMeasure<CustomGrid>(ColumnDefinitionsSourceProperty, RowDefinitionsSourceProperty);
        // }

        public void InvalidateDefinitions()
        {
            if (ColumnDefinitionsSource is not null && RowDefinitionsSource is not null)
            {
                var columns = GridLength.ParseLengths(ColumnDefinitionsSource).Select(x => new ColumnDefinition(x));
                ColumnDefinitions.Clear();
                ColumnDefinitions.AddRange(columns);

                var rows = GridLength.ParseLengths(RowDefinitionsSource).Select(x => new RowDefinition(x));
                RowDefinitions.Clear();
                RowDefinitions.AddRange(rows);

                InvalidateMeasure();
                InvalidateArrange();
            }
        }
    }
}