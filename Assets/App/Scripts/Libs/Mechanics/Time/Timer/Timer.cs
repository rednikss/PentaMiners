using System.Collections.Generic;
using App.Scripts.Libs.Mechanics.Time.Tickable;

namespace App.Scripts.Libs.Mechanics.Time.Timer
{
    public class Timer : ITickable
    {
        private float _currentTime;

        private readonly List<TimerEvent> _timerEvents = new();

        public void Tick(float deltaTime)
        {
            _currentTime += deltaTime;

            for (var i = 0; i < _timerEvents.Count; i++)
            {
                EventCheck(_timerEvents[i]);
            }
        }

        public TimerEvent AddEvent(TimedEvent timedEvent, float delay)
        {
            var timerEvent = new TimerEvent(timedEvent, _currentTime + delay);
            _timerEvents.Add(timerEvent);
            
            return timerEvent;
        }

        public void CancelEvent(TimerEvent timerEvent)
        {
            _timerEvents.Remove(timerEvent);
        }

        private void EventCheck(TimerEvent timerEvent)
        {
            if (timerEvent.Time > _currentTime) return;
            
            _timerEvents.Remove(timerEvent);
            timerEvent.Event?.Invoke();
        }
        
        public class TimerEvent
        {
            public readonly float Time;
            
            public readonly TimedEvent Event;

            public TimerEvent(TimedEvent newEvent, float invokeTime)
            {
                Event = newEvent;
                Time = invokeTime;
            }
        }
        
        public delegate void TimedEvent();
    }
    
}