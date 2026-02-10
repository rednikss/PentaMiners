using System;
using App.Scripts.Libs.Services.Time.Tickable;

namespace App.Scripts.Game.Level.Core.Cycle
{
    public interface ILevelCycle : ITickable
    {
        public event Action OnLevelFail;
        
        public event Action OnLevelComplete;
        
        public void SetSpeed(float speed);

        public void Start();
        
        public void Stop();
    }
}