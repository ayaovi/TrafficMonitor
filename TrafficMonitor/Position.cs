using System;
using System.Diagnostics;

namespace TrafficMonitor
{
  public struct Position
  {
    public Position(int value) : this()
    {
      if (value < 0 || value > 3) throw new Exception("Invalid Position Exception.");
      Value = value;
    }

    public int Value { get; set; }

    public static bool operator ==(Position lhs, Position rhs) => lhs.Value == rhs.Value;
    public static bool operator !=(Position lhs, Position rhs) => lhs.Value != rhs.Value;
  }
}
