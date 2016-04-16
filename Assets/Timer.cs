using UnityEngine;
using System;

public class Timer {

    protected DateTime time;

    protected bool running;

    public double elapsedTime {
        get {
            DateTime now = DateTime.UtcNow;
            TimeSpan dif = now.Subtract(time);
            return dif.TotalSeconds;
        }
    }

    public bool Running {
        get { return running; }
        set { running = value; }
    }

    public Timer() {
        Reset();
        running = true;
    }

    public void Reset() {
        time = DateTime.UtcNow;
    }

}
