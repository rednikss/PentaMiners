using System;

namespace App.Scripts.Libs.Core.Project.Model.Config
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