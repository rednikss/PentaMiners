using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Libs.Services.Time.Tickable.Handler.Default
{
    public class MonoTickableHandler : MonoBehaviour, ITickableHandler
    {
        private readonly HashSet<ITickable> _tickables = new();
        
        private void Update()
        {
            foreach (var tickable in _tickables)
            {
                tickable.Tick(UnityEngine.Time.deltaTime);
            }
        }

        public void AddTickable(ITickable tickable) => _tickables.Add(tickable);
        
        public void RemoveTickable(ITickable tickable) => _tickables.Remove(tickable);
    }
}