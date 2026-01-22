using System;

namespace App.Scripts.Game.Player.Stats.Config
{
    [Serializable]
    public class PlayerStatsConfig
    {
        public int CurrentLevel;

        public PlayerStatsConfig()
        {
            CurrentLevel = 0;
        }
    }
}