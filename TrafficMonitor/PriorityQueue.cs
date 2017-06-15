using System;
using System.Collections.Generic;

namespace TrafficMonitor
{
  public class PriorityQueue<T> where T : IComparable<T>
  {
    private IList<T> _queue = new List<T>();
    public int Count { get; private set; }

    public void Add(T item)
    {
      _queue.Add(item);
      ++Count;
      var ci = _queue.Count - 1;

      while (ci > 0)
      {
        var pi = (ci - 1) / 2;
        if (_queue[ci].CompareTo(_queue[pi]) >= 0) break;
        var tmp = _queue[ci];
        _queue[ci] = _queue[pi];
        _queue[pi] = tmp;
        ci = pi;
      }
    }

    public T Peek() => _queue[0];

    public T Pop()
    {
      var head = _queue[0];
      _queue.RemoveAt(0);
      --Count;
      return head;
    }
  }
}
