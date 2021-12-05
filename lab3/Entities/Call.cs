using System;

namespace lab1
{
	class Call
	{
		public int Duration;
		public Rate Rate; 

		public Call(int duration, Rate rate)
		{
			Duration = duration;
			Rate = rate;
		}
	}
}
