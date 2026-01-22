using App.Scripts.Game.Level.Config;

namespace App.Scripts.Game.Level.Loader
{
    public interface ILevelLoader
    {
        public LevelConfig LoadLevel(int number);
    }
}