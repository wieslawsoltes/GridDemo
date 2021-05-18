using System;
using System.Collections.ObjectModel;
using Avalonia.Media;
using ReactiveUI;

namespace GridDemo.ViewModels.TileControl
{
    public class TileItem : ViewModelBase
    {
        private ObservableCollection<TilePreset>? _tilePresets;
        private int _tilePresetIndex;

        public ObservableCollection<TilePreset>? TilePresets
        {
            get => _tilePresets;
            set => this.RaiseAndSetIfChanged(ref _tilePresets, value);
        }

        public int TilePresetIndex
        {
            get => _tilePresetIndex;
            set => this.RaiseAndSetIfChanged(ref _tilePresetIndex, value);
        }

        public TileItem()
        {
            this.WhenAnyValue(x => x.TilePresetIndex)
                .Subscribe(_ => NotifyPresetChanged());
        }

        public int Column => CurrentTilePreset?.Column ?? 0;
        
        public int Row => CurrentTilePreset?.Row ?? 0;
        
        public int ColumnSpan => CurrentTilePreset?.ColumnSpan ?? 1;
        
        public int RowSpan => CurrentTilePreset?.RowSpan ?? 1;

        public TilePreset? CurrentTilePreset => TilePresets?[TilePresetIndex];
        
        public IBrush? Background { get; set; }

        private void NotifyPresetChanged()
        {
            this.RaisePropertyChanged(nameof(CurrentTilePreset));
            this.RaisePropertyChanged(nameof(Column));
            this.RaisePropertyChanged(nameof(Row));
            this.RaisePropertyChanged(nameof(ColumnSpan));
            this.RaisePropertyChanged(nameof(RowSpan));
        }

    }
}