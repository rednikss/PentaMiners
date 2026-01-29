using App.Scripts.Game.Level.Initialization.Config;

namespace App.Scripts.Game.Level.Initialization.Builder
{
    public interface ILevelBuilder
    {
        public void Build(LevelConfig levelConfig);
    }
}