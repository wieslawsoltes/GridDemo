using System;
using System.Collections.Generic;
using Avalonia.Media;
using ReactiveUI;

namespace GridDemo.ViewModels.TileControl
{
	public class TileViewModel : ViewModelBase
	{
		private IList<TilePresetViewModel>? _tilePresets;
		private int _tilePresetIndex;

		public IList<TilePresetViewModel>? TilePresets
		{
			get => _tilePresets;
			set => this.RaiseAndSetIfChanged(ref _tilePresets, value);
		}

		public int TilePresetIndex
		{
			get => _tilePresetIndex;
			set => this.RaiseAndSetIfChanged(ref _tilePresetIndex, value);
		}

		public TileViewModel()
		{
			this.WhenAnyValue(x => x.TilePresetIndex)
				.Subscribe(_ => NotifyPresetChanged());
		}

		public int Column => CurrentTilePreset?.Column ?? 0;

		public int Row => CurrentTilePreset?.Row ?? 0;

		public int ColumnSpan => CurrentTilePreset?.ColumnSpan ?? 1;

		public int RowSpan => CurrentTilePreset?.RowSpan ?? 1;

		public TilePresetViewModel? CurrentTilePreset => TilePresets?[TilePresetIndex];

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