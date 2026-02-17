using App.Scripts.Libs.Services.Time.Tickable;

namespace App.Scripts.Game.Level.Core.Cycle
{
    public interface ILevelCycle : ITickable
    {
        public void SetSpeed(float speed);

        public void Start();
        
        public void Stop();
    }
}