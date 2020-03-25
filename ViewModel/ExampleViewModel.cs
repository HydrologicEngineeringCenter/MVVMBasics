using System;
using System.ComponentModel;

namespace ViewModelExample
{
	public class ExampleViewModel : ViewModel.Implementations.BaseViewModel // System.ComponentModel.NotifyPropertyChanged
	{
		private Model.ExampleModel _exampleModel = new Model.ExampleModel();
		private int _increment = 2;
		private ViewModel.Implementations.NamedAction _cmd;
		public int Increment
		{
			get
			{
				return _increment;
			}
			set
			{
				_increment = value;
				NotifyPropertyChanged();
			}
		}
		public int CounterValue
		{
			get
			{
				return _exampleModel.Counter;
			}
		}
		public ViewModel.Implementations.NamedAction Command
		{
			get
			{
				return _cmd;
			}
		}
		public ExampleViewModel()
		{
			_cmd = new ViewModel.Implementations.NamedAction() {
				Name = "Advance By Increment",
				Action = (object sender, EventArgs e) => {
					_exampleModel.Update(Increment);
					NotifyPropertyChanged(nameof(CounterValue));
				}
			};
		}
	}
}
