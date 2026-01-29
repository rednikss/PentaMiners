using System;
using App.Scripts.Game.Block.Base.Color;
using App.Scripts.Game.Block.Base.Rock;
using UnityEngine;

namespace App.Scripts.Game.Level.Initialization.Config.Blocks
{
    [CreateAssetMenu(fileName = "Level Blocks Config", menuName = "Config/Level/Level Block", order = 0)]
    public class LevelBlockConfig : ScriptableObject
    {
        [field: SerializeField] public ColorBlock colorBlock;
        
        [field: SerializeField] public IDValuePair<Color>[] _colors;
        
        [field: SerializeField] public IDValuePair<RockBlock> rockBlock;
        
        public Color GetColor(int index)
        {
            foreach (var pair in _colors)
            {
                if (pair.ID == index)
                {
                    return pair.Value;
                }
            }
            
            Debug.LogError($"Can't find color with id = {index}");
            
            return default;
        }
    }

    [Serializable]
    public class IDValuePair<TValue>
    {
        [field: SerializeField] public int ID;
        
        [field: SerializeField] public TValue Value;
    }
}