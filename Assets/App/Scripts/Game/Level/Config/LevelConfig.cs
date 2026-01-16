using System;
using UnityEngine;

namespace App.Scripts.Game.Level.Config
{
    [Serializable]
    public class LevelConfig
    {
        [Min(1)] public int Width;
        [Min(1)] public int Height;
        
        public Color[][] Blocks;

        [Min(0)] public float GravityScale;
    }
}