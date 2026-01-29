using App.Scripts.Game.Level.Initialization.Config;

namespace App.Scripts.Game.Level.Initialization.Loader
{
    public interface ILevelLoader
    {
        public LevelConfig LoadLevel(int number);
    }
}