using App.Scripts.Libs.Services.Time.Tickable;

namespace App.Scripts.Libs.Services.Time.Timer
{
    public interface ITimer : ITickable
    {
        public TimerEventData AddEvent(TimerEventData timedEventData, float delay);

        public void CancelEvent(TimerEventData timerEventData);
    }
}