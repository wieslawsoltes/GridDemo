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
            // HACK
            // s_listenToNotifications.SetValue(this, true);
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

        private static readonly FieldInfo? s_data = 
            typeof(Grid).GetField("_data", BindingFlags.NonPublic | BindingFlags.Instance);

        private static readonly PropertyInfo? s_listenToNotifications = 
            typeof(Grid).GetProperty("ListenToNotifications", BindingFlags.NonPublic | BindingFlags.Instance);

        private static readonly PropertyInfo? s_cellsStructureDirty = 
            typeof(Grid).GetProperty("CellsStructureDirty", BindingFlags.NonPublic | BindingFlags.Instance);
        
        private static readonly PropertyInfo? s_columnDefinitionsDirty = 
            typeof(Grid).GetProperty("ColumnDefinitionsDirty", BindingFlags.NonPublic | BindingFlags.Instance);

        private static readonly PropertyInfo? s_rowDefinitionsDirty = 
            typeof(Grid).GetProperty("RowDefinitionsDirty", BindingFlags.NonPublic | BindingFlags.Instance);

        private static readonly MethodInfo? s_validateCells = 
            typeof(Grid).GetMethod("ValidateCells", BindingFlags.NonPublic | BindingFlags.Instance);

        private static readonly MethodInfo? s_invalidate = 
            typeof(Grid).GetMethod("Invalidate", BindingFlags.NonPublic | BindingFlags.Instance);

        static CustomGrid()
        {
            AffectsParentMeasure<CustomGrid>(ColumnDefinitionsSourceProperty, RowDefinitionsSourceProperty);
        }

        public void InvalidateDefinitions()
        {
            if (ColumnDefinitionsSource is not null && RowDefinitionsSource is not null)
            {
                // HACK
                // s_data.SetValue(this, null);

                (this.DataContext as MainWindowViewModel)?.UpdateTiles();

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
                // s_columnDefinitionsDirty.SetValue(this, true);
                // s_rowDefinitionsDirty.SetValue(this, true);
                // s_cellsStructureDirty.SetValue(this, true);
                // s_validateCells.Invoke(this, new object[]{});
                // s_invalidate.Invoke(this, new object[]{});

                InvalidateMeasure();
                InvalidateArrange();
                // InvalidateVisual();

                // foreach (var child in Children)
                // {
                //     child.InvalidateMeasure();
                //     child.InvalidateArrange();
                // }
            }
        }
    }
}