using System;

namespace TrafficMonitor
{
  public class TrafficEvent : IComparable <TrafficEvent>
  {
    public TrafficEvent(DateTime time, TimeSpan span, Stage stage, Func<Stage, TrafficEvent> callback)
    {
      Time = time;
      Span = span;
      Stage = stage;
      CallBack = callback;
    }

    public Stage Stage { get; set; }

    public Func<Stage, TrafficEvent> CallBack { get; set; }

    public DateTime Time { get; }
    public TimeSpan Span { get; set; }

    public TrafficEvent Process()
    {
      return CallBack(Stage);
    }

    public int CompareTo(TrafficEvent other)
    {
      return Time.CompareTo(other.Time);
    }
  }
}
