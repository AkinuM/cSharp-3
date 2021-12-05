using System;

namespace lab1
{
	class NoItemException<T> : Exception
	{
		public T Item { get; }
		public NoItemException(string message, T item) : base(message)
		{
			Item = item;
		}
	}
}