using System;
using System.Collections.ObjectModel;
using Avalonia.Media;
using GridDemo.ViewModels.TileControl;
using ReactiveUI;

namespace GridDemo.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		private ObservableCollection<TileViewModel>? _tiles;
		private ObservableCollection<TileLayoutViewModel>? _layouts;
		private int _layoutIndex;

		public ObservableCollection<TileViewModel>? Tiles
		{
			get => _tiles;
			set => this.RaiseAndSetIfChanged(ref _tiles, value);
		}

		public ObservableCollection<TileLayoutViewModel>? Layouts
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

		public TileLayoutViewModel? CurrentLayout => Layouts?[LayoutIndex];

		public MainWindowViewModel()
		{
			LayoutIndex = 2;

			Layouts = new ObservableCollection<TileLayoutViewModel>()
			{
				new TileLayoutViewModel("Small", "228,228,228,228,228", "126"),
				new TileLayoutViewModel("Normal", "228,228,228", "126,252"),
				new TileLayoutViewModel("Wide", "228,228", "126,252,252"),
			};

			Tiles = new ObservableCollection<TileViewModel>()
			{
				// 0
				new TileViewModel()
				{
					Background = Brushes.Red,
					TilePresets = new ObservableCollection<TilePresetViewModel>()
					{
						new TilePresetViewModel(0, 0, 1, 1),
						new TilePresetViewModel(0, 0, 1, 1),
						new TilePresetViewModel(0, 0, 1, 1),
					},
					TilePresetIndex = LayoutIndex
				},
				// 1
				new TileViewModel()
				{
					Background = Brushes.Green,
					TilePresets = new ObservableCollection<TilePresetViewModel>()
					{
						new TilePresetViewModel(1, 0, 1, 1),
						new TilePresetViewModel(1, 0, 1, 1),
						new TilePresetViewModel(1, 0, 1, 1),
					},
					TilePresetIndex = LayoutIndex
				},
				// 2
				new TileViewModel()
				{
					Background = Brushes.Blue,
					TilePresets = new ObservableCollection<TilePresetViewModel>()
					{
						new TilePresetViewModel(2, 0, 1, 1),
						new TilePresetViewModel(2, 0, 1, 1),
						new TilePresetViewModel(0, 1, 1, 1),
					},
					TilePresetIndex = LayoutIndex
				},
				// 3
				new TileViewModel()
				{
					Background = Brushes.Yellow,
					TilePresets = new ObservableCollection<TilePresetViewModel>()
					{
						new TilePresetViewModel(3, 0, 1, 1),
						new TilePresetViewModel(0, 1, 1, 1),
						new TilePresetViewModel(1, 1, 1, 1),
					},
					TilePresetIndex = LayoutIndex
				},
				// 4
				new TileViewModel()
				{
					Background = Brushes.Black,
					TilePresets = new ObservableCollection<TilePresetViewModel>()
					{
						new TilePresetViewModel(4, 0, 1, 1),
						new TilePresetViewModel(1, 1, 2, 1),
						new TilePresetViewModel(0, 2, 2, 1),
					},
					TilePresetIndex = LayoutIndex
				},
			};

			this.WhenAnyValue(x => x.LayoutIndex)
				.Subscribe(_ => UpdateTiles());
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