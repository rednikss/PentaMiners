using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Libs.Mechanics.Time.Tickable.Handler.Fixed
{
    public class FixedTickableHandler : MonoBehaviour, ITickableHandler
    {
        private readonly List<ITickable> _tickables = new();
        
        private void FixedUpdate()
        {
            for (var i = 0; i < _tickables.Count; i++)
            {
                _tickables[i].Tick(UnityEngine.Time.deltaTime);
            }
        }

        public void AddTickable(ITickable tickable) => _tickables.Add(tickable);
        
        public void RemoveTickable(ITickable tickable) => _tickables.Remove(tickable);
    }
}