using ReactiveUI;

namespace GridDemo.ViewModels.TileControl
{
	public class TilePresetViewModel : ViewModelBase
	{
		private int _column;
		private int _row;
		private int _columnSpan;
		private int _rowSpan;

		public int Column
		{
			get => _column;
			set => this.RaiseAndSetIfChanged(ref _column, value);
		}

		public int Row
		{
			get => _row;
			set => this.RaiseAndSetIfChanged(ref _row, value);
		}

		public int ColumnSpan
		{
			get => _columnSpan;
			set => this.RaiseAndSetIfChanged(ref _columnSpan, value);
		}

		public int RowSpan
		{
			get => _rowSpan;
			set => this.RaiseAndSetIfChanged(ref _rowSpan, value);
		}

		public TilePresetViewModel()
		{
		}

		public TilePresetViewModel(int column, int row, int columnSpan, int rowSpan)
		{
			Column = column;
			Row = row;
			ColumnSpan = columnSpan;
			RowSpan = rowSpan;
		}
	}
}