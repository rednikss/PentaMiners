namespace App.Scripts.Game.Player.Stats
{
    public interface IPlayerModel
    {
        public int GetCurrentLevelCounter();

        public void IncreaseCurrentLevelCounter();
    }
}