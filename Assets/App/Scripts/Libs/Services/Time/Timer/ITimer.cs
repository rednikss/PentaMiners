using App.Scripts.Libs.Time.Tickable;

namespace App.Scripts.Libs.Time.Timer
{
    public interface ITimer : ITickable
    {
        public TimerEventData AddEvent(TimerEventData timedEventData, float delay);

        public void CancelEvent(TimerEventData timerEventData);
    }
}