using System;
using System.Collections.ObjectModel;
using Avalonia.Media;
using ReactiveUI;

namespace GridDemo
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<TileItem> _tiles;
        private ObservableCollection<GridLayout> _layouts;
        private int _layoutIndex;

        public ObservableCollection<TileItem> Tiles
        {
            get => _tiles;
            set => this.RaiseAndSetIfChanged(ref _tiles, value);
        }

        public ObservableCollection<GridLayout> Layouts
        {
            get => _layouts;
            set => this.RaiseAndSetIfChanged(ref _layouts, value);
        }

        public int LayoutIndex
        {
            get => _layoutIndex;
            set
            {
                this.RaiseAndSetIfChanged(ref _layoutIndex, value);
                this.RaisePropertyChanged(nameof(CurrentLayout));
            }
        }

        public GridLayout CurrentLayout => Layouts[LayoutIndex];

        public MainWindowViewModel()
        {
            LayoutIndex = 2;

            Layouts = new ObservableCollection<GridLayout>()
            {
                new GridLayout("Small", "228,228,228,228,228", "126"),
                new GridLayout("Normal", "228,228,228", "126,252"),
                new GridLayout("Wide", "228,228", "126,252,252"),
            };

            Tiles = new ObservableCollection<TileItem>()
            {
                // 0
                new TileItem()
                {
                    Background = Brushes.Red,
                    TilePresets = new ObservableCollection<TilePreset>()
                    {
                        new TilePreset(0, 0, 1, 1),
                        new TilePreset(0, 0, 1, 1),
                        new TilePreset(0, 0, 1, 1),
                    },
                    TilePresetIndex = LayoutIndex
                },
                // 1
                new TileItem()
                {
                    Background = Brushes.Green,
                    TilePresets = new ObservableCollection<TilePreset>()
                    {
                        new TilePreset(1, 0, 1, 1),
                        new TilePreset(1, 0, 1, 1),
                        new TilePreset(1, 0, 1, 1),
                    },
                    TilePresetIndex = LayoutIndex
                },
                // 2
                new TileItem()
                {
                    Background = Brushes.Blue,
                    TilePresets = new ObservableCollection<TilePreset>()
                    {
                        new TilePreset(2, 0, 1, 1),
                        new TilePreset(2, 0, 1, 1),
                        new TilePreset(0, 1, 1, 1),
                    },
                    TilePresetIndex = LayoutIndex
                },
                // 3
                new TileItem()
                {
                    Background = Brushes.Yellow,
                    TilePresets = new ObservableCollection<TilePreset>()
                    {
                        new TilePreset(3, 0, 1, 1),
                        new TilePreset(0, 1, 1, 1),
                        new TilePreset(1, 1, 1, 1),
                    },
                    TilePresetIndex = LayoutIndex
                },
                // 4
                new TileItem()
                {
                    Background = Brushes.Black,
                    TilePresets = new ObservableCollection<TilePreset>()
                    {
                        new TilePreset(4, 0, 1, 1),
                        new TilePreset(1, 1, 2, 1),
                        new TilePreset(0, 2, 2, 1),
                    },
                    TilePresetIndex = LayoutIndex
                },
            };

            this.WhenAnyValue(x => x.LayoutIndex)
                .Subscribe(x => UpdateTiles());
        }

        private void UpdateTiles()
        {
            foreach (var tile in Tiles)
            {
                tile.TilePresetIndex = LayoutIndex;
            }
        }
    }
}