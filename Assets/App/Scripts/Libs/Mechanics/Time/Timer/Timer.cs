using System;
using System.Collections.Generic;
using App.Scripts.Libs.Mechanics.Time.Tickable;

namespace App.Scripts.Libs.Mechanics.Time.Timer
{
    public class Timer : ITickable
    {
        private float _currentTime;

        private readonly Dictionary<TimerEventData, Action> _events = new();

        public void Tick(float deltaTime)
        {
            _currentTime += deltaTime;

            foreach (var (key, value) in _events)
            {
                EventCheck(key, value);
            }
        }

        public TimerEventData AddEvent(Action action, float delay, bool isLooping = false)
        {
            var data = new TimerEventData(_currentTime + delay, isLooping);
            _events.Add(data, action);
            
            return data;
        }

        public void CancelEvent(TimerEventData data)
        {
            _events.Remove(data);
        }

        private void EventCheck(TimerEventData data, Action action)
        {
            if (data.Time > _currentTime) return;
            
            if (!data.IsLooping) _events.Remove(data);
            
            action?.Invoke();
        }
    }
    
    public class TimerEventData
    {
        public readonly float Time;
        
        public readonly bool IsLooping;
        
        public TimerEventData(float invokeTime, bool isLooping = false)
        {
            Time = invokeTime;
            IsLooping = isLooping;
        }
    }
}