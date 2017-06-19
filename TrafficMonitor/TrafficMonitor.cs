﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TrafficMonitor
{
  public class TrafficMonitor
  {
    public IList<Light> Lights { get; set; }
    public IList<Stage> Stages { get; set; }
    public PriorityQueue<TrafficEvent> EventQueue { get; set; }
    public DateTime SystemTime { get; set; }

    public TrafficMonitor()
    {
      Lights = Enumerable.Range(0, 4).Select(i => new Light(Colour.Red, new Position(i))).ToList();
      Stages = Enumerable.Range(0, 3).Select(i => new Stage(i) { Lights = Lights }).ToList();

      Stages[0].Next = Stages[1];
      Stages[1].Next = Stages[2];
      Stages[2].Next = Stages[0];

      EventQueue = new PriorityQueue<TrafficEvent>();
    }

    public void Start()
    {
      EventQueue.Add(new TrafficEvent(SystemTime, new Stage(), stage => stage.Activate(SystemTime)));
    }
  }
}