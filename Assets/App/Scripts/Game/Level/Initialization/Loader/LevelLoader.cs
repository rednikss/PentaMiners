using System.IO;
using App.Scripts.Game.Level.Initialization.Config;
using Newtonsoft.Json;
using UnityEngine;

namespace App.Scripts.Game.Level.Initialization.Loader
{
    public class LevelLoader : ILevelLoader
    {
        private readonly string _levelPath;

        public LevelLoader(string levelPath)
        {
            _levelPath = levelPath;
        }

        public LevelConfig LoadLevel(int number)
        {
            var name = Path.Combine(_levelPath, number.ToString());
            var serLevel = Resources.Load<TextAsset>(name).text; 
    
            var levelData = JsonConvert.DeserializeObject<LevelConfig>(serLevel);

            return levelData;
        }
    }
}