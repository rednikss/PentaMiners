namespace App.Scripts.Libs.Mechanics.Time.Tickable.Handler
{
    public interface ITickableHandler
    {
        public void AddTickable(ITickable tickable);
        
        public void RemoveTickable(ITickable tickable);
    }
}