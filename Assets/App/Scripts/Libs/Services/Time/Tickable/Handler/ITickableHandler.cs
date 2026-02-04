namespace App.Scripts.Libs.Services.Time.Tickable.Handler
{
    public interface ITickableHandler
    {
        public void AddTickable(ITickable tickable);
        
        public void RemoveTickable(ITickable tickable);
    }
}