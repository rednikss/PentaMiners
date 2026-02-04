using System;
using App.Scripts.Libs.Services.Time.Tickable;

namespace App.Scripts.Game.Level.Core.Manager
{
    public interface IGameManager : ITickable
    {
        public event Action OnLevelFail;
        
        public event Action OnLevelComplete;

        public void Start();
        
        public void SetSpeed(float speed);
        
        public void DashBlock(int column);
        
        public void Stop();
    }
}