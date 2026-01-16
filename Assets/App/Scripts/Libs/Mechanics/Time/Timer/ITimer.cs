using App.Scripts.Libs.Mechanics.Time.Tickable;

namespace App.Scripts.Libs.Mechanics.Time.Timer
{
    public interface ITimer : ITickable
    {
        public TimerEventData AddEvent(TimerEventData timedEventData, float delay);

        public void CancelEvent(TimerEventData timerEventData);
    }
}