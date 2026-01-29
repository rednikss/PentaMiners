using System;
using UnityEngine;

namespace App.Scripts.Game.Level.Initialization.Config
{
    [Serializable]
    public class LevelConfig
    {
        public int[,] Blocks;

        public float TickSpeed;
        
        public LevelConfig(Vector2Int gridSize)
        {
            Blocks = new int[gridSize.x, gridSize.y];
            TickSpeed = 1;
        }

        public int GetWidth() => Blocks.GetLength(0);
        
        public int GetHeight() => Blocks.GetLength(1);
    }
}