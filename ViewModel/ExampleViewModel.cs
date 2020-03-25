using System;
using System.ComponentModel;

namespace ViewModelExample
{
	public class ExampleViewModel : ViewModel.Implementations.BaseViewModel
	{
		private Model.ExampleModel _exampleModel = new Model.ExampleModel();
		private int _increment = 2;
		private int _multiplier = 1;
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
				NotifyPropertyChanged(ActionName);
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

		public int Multiplier { 
			get => _multiplier;
			set
			{
				_multiplier = value;
				NotifyPropertyChanged(ActionName);
			}
		}


		public string ActionName
		{
			get { return "Advance to " + (_exampleModel.Counter + _multiplier * _increment); }
		}
		public ExampleViewModel()
		{
			_cmd = new ViewModel.Implementations.NamedAction() {
				Name = ActionName,
				Action = (object sender, EventArgs e) => {
					_exampleModel.Update(Increment*Multiplier);
					NotifyPropertyChanged(nameof(CounterValue));
				}
			};
		}
	}
}
