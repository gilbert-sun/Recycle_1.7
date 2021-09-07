using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.ViewModels
{
	public class ObservableQueue<T> : Queue<T>, INotifyCollectionChanged
	{
		public virtual event NotifyCollectionChangedEventHandler CollectionChanged;

		public new virtual void Clear()
		{
			base.Clear();
			RaiseCollectionChanged();
		}

		public new virtual T Dequeue()
		{
			var item = base.Dequeue();
			RaiseCollectionChanged(NotifyCollectionChangedAction.Remove, item);
			return item;
		}

		public new virtual void Enqueue(T item)
		{
			base.Enqueue(item);
			RaiseCollectionChanged(NotifyCollectionChangedAction.Add, item);
		}

		private void RaiseCollectionChanged() => CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

		private void RaiseCollectionChanged(NotifyCollectionChangedAction action, T item) => CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, item));
	}
}
