using System.Collections.ObjectModel;
using Avalonia.Media;
using ReactiveUI;

namespace GridDemo
{
    public class TileItem : ViewModelBase
    {
        private ObservableCollection<TilePreset> _tilePresets;
        private int _tilePresetIndex;

        public ObservableCollection<TilePreset> TilePresets
        {
            get => _tilePresets;
            set => this.RaiseAndSetIfChanged(ref _tilePresets, value);
        }

        public int TilePresetIndex
        {
            get => _tilePresetIndex;
            set
            {
                this.RaiseAndSetIfChanged(ref _tilePresetIndex, value);
                this.RaisePropertyChanged(nameof(CurrentTilePreset));
            }
        }

        public TilePreset CurrentTilePreset => TilePresets[TilePresetIndex];
        
        public IBrush Background { get; set; }
    }
}