using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Media;
using GridDemo.ViewModels.TileControl;
using ReactiveUI;

namespace GridDemo.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		private IList<TileViewModel>? _tiles;
		private IList<TileLayoutViewModel>? _layouts;
		private int _layoutIndex;

		public IList<TileViewModel>? Tiles
		{
			get => _tiles;
			set => this.RaiseAndSetIfChanged(ref _tiles, value);
		}

		public IList<TileLayoutViewModel>? Layouts
		{
			get => _layouts;
			set => this.RaiseAndSetIfChanged(ref _layouts, value);
		}

		public int LayoutIndex
		{
			get => _layoutIndex;
			set => this.RaiseAndSetIfChanged(ref _layoutIndex, value);
		}

		public TileLayoutViewModel? CurrentLayout => Layouts?[LayoutIndex];

		public MainWindowViewModel()
		{
			Layouts = new ObservableCollection<TileLayoutViewModel>()
			{
				new("Small", "228,228,228,228,228", "126"),
				new("Normal", "228,228,228", "126,252"),
				new("Wide", "228,228", "126,252,252")
			};

			LayoutIndex = 1;

			Tiles = new ObservableCollection<TileViewModel>()
			{
				// 0
				new()
				{
					Background = Brushes.Red,
					TilePresets = new ObservableCollection<TilePresetViewModel>()
					{
						new(0, 0, 1, 1),
						new(0, 0, 1, 1),
						new(0, 0, 1, 1)
					},
					TilePresetIndex = LayoutIndex
				},
				// 1
				new()
				{
					Background = Brushes.Green,
					TilePresets = new ObservableCollection<TilePresetViewModel>()
					{
						new(1, 0, 1, 1),
						new(1, 0, 1, 1),
						new(1, 0, 1, 1)
					},
					TilePresetIndex = LayoutIndex
				},
				// 2
				new()
				{
					Background = Brushes.Blue,
					TilePresets = new ObservableCollection<TilePresetViewModel>()
					{
						new(2, 0, 1, 1),
						new(2, 0, 1, 1),
						new(0, 1, 1, 1)
					},
					TilePresetIndex = LayoutIndex
				},
				// 3
				new()
				{
					Background = Brushes.Yellow,
					TilePresets = new ObservableCollection<TilePresetViewModel>()
					{
						new(3, 0, 1, 1),
						new(0, 1, 1, 1),
						new(1, 1, 1, 1)
					},
					TilePresetIndex = LayoutIndex
				},
				// 4
				new()
				{
					Background = Brushes.Black,
					TilePresets = new ObservableCollection<TilePresetViewModel>()
					{
						new(4, 0, 1, 1),
						new(1, 1, 2, 1),
						new(0, 2, 2, 1)
					},
					TilePresetIndex = LayoutIndex
				},
			};

			this.WhenAnyValue(x => x.LayoutIndex)
				.Subscribe(_ => NotifyLayoutChanged());

			this.WhenAnyValue(x => x.LayoutIndex)
				.Subscribe(_ => UpdateTiles());
		}

		private void NotifyLayoutChanged()
		{
			this.RaisePropertyChanged(nameof(CurrentLayout));
		}

		private void UpdateTiles()
		{
			if (Tiles != null)
			{
				foreach (var tile in Tiles)
				{
					tile.TilePresetIndex = LayoutIndex;
				}
			}
		}
	}
}