using App.Scripts.Game.Level.Core.Cycle;
using App.Scripts.Game.Level.Initialization.Config;

namespace App.Scripts.Game.Level.Initialization.Builder
{
    public interface ILevelBuilder
    {
        public ILevelCycle Build(LevelConfig levelConfig);
    }
}