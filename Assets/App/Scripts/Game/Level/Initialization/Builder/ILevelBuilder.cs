using App.Scripts.Game.Level.Core.Manager;
using App.Scripts.Game.Level.Initialization.Config;

namespace App.Scripts.Game.Level.Initialization.Builder
{
    public interface ILevelBuilder
    {
        public IGameManager Build(LevelConfig levelConfig);
    }
}