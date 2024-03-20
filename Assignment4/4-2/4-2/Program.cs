using System;
using System.Threading;

public class AlarmClock
{
    public event EventHandler Tick;
    public event EventHandler Alarm;

    public void Start(int durationSeconds)
    {
        Console.WriteLine($"闹钟已设置，将在 {durationSeconds} 秒后响铃。");
        Thread.Sleep(durationSeconds * 1000);

        OnTick();
        OnAlarm();
    }

    protected virtual void OnTick()
    {
        Tick?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnAlarm()
    {
        Alarm?.Invoke(this, EventArgs.Empty);
    }
}

class Program
{
    static void Main(string[] args)
    {
        AlarmClock alarmClock = new AlarmClock();
        alarmClock.Tick += (sender, e) => Console.WriteLine("嘀嗒，嘀嗒");
        alarmClock.Alarm += (sender, e) => Console.WriteLine("该起床了！");

        // 设置闹钟
        alarmClock.Start(5);
    }
}
