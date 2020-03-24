using System;

namespace Model
{
	public class ExampleModel
	{
		private int _counter = 0;
		public int Counter
		{
			get
			{
				return _counter;
			}

		}
		public void Update(int increment)
		{
			_counter += increment;
		}
	}
}
