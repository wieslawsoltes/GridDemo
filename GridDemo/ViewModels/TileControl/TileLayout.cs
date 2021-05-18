using ReactiveUI;

namespace GridDemo.ViewModels.TileControl
{
	public class TileLayout : ViewModelBase
	{
		private string? _name;
		private string? _columnDefinitions;
		private string? _rowDefinitions;

		public string? Name
		{
			get => _name;
			set => this.RaiseAndSetIfChanged(ref _name, value);
		}

		public string? ColumnDefinitions
		{
			get => _columnDefinitions;
			set => this.RaiseAndSetIfChanged(ref _columnDefinitions, value);
		}

		public string? RowDefinitions
		{
			get => _rowDefinitions;
			set => this.RaiseAndSetIfChanged(ref _rowDefinitions, value);
		}

		public TileLayout()
		{
		}

		public TileLayout(string name, string columnDefinitions, string rowDefinitions)
		{
			Name = name;
			ColumnDefinitions = columnDefinitions;
			RowDefinitions = rowDefinitions;
		}
	}
}