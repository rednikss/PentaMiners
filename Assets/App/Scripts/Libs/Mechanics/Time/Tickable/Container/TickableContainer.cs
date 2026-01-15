using System.Collections;
using System.Collections.Generic;
using App.Scripts.Libs.Mechanics.Time.Timer;

namespace App.Scripts.Libs.Mechanics.Time.Tickable.Container
{
    public class TickableContainer<T> : IEnumerable<T>, ITickable where T : ITickable
    {
        private readonly IEnumerable<T> _tickables;

        public TickableContainer(IEnumerable<T> tickables)
        {
            _tickables = tickables;
        }
            
        public void Tick(float deltaTime)
        {
            foreach (var tickable in _tickables)
            {
                tickable.Tick(deltaTime);
            }
        }

        public IEnumerator<T> GetEnumerator() => _tickables.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}