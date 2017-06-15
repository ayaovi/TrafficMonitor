using System;

namespace TrafficMonitor
{
  public class TrafficEvent : IComparable <TrafficEvent>
  {
    public TrafficEvent(DateTime time, Stage stage, Action<Stage> callback)
    {
      Time = time;
      Stage = stage;
      CallBack = callback;
    }

    public Stage Stage { get; set; }

    public Action<Stage> CallBack { get; set; }

    public DateTime Time { get; }

    public void Process()
    {
      CallBack(Stage);
    }

    public int CompareTo(TrafficEvent other)
    {
      return Time.CompareTo(other.Time);
    }
  }
}
