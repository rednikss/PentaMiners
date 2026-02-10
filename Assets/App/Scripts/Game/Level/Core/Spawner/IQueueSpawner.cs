using App.Scripts.Game.Level.Core.Spawner.Queue;

namespace App.Scripts.Game.Level.Core.Spawner
{
    public interface IQueueSpawner
    {
        public void Init(IBlockQueue queue);
        
        public void SpawnNext();
    }
}