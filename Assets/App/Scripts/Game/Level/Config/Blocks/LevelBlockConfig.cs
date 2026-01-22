using System;
using System.Collections.Generic;
using App.Scripts.Game.Level.Block.View;
using UnityEngine;

namespace App.Scripts.Game.Level.Config.Blocks
{
    [CreateAssetMenu(fileName = "Level Blocks Config", menuName = "Config/Level/Level Block", order = 0)]
    public class LevelBlockConfig : ScriptableObject
    {
        [field: SerializeField] public BlockView colorBlock;
        
        [field: SerializeField] public IDValuePair<Color>[] _colors;
        
        [field: SerializeField] public IDValuePair<BlockView>[] _bonuses;

        public List<string> GetBlockTypeList()
        {
            var list = new List<string>();
            
            foreach (var c in _colors) list.Add(c.ID);
            foreach (var b in _bonuses) list.Add(b.ID);

            return list;
        }
        
    }

    [Serializable]
    public class IDValuePair<TValue>
    {
        [field: SerializeField] public string ID;
        
        [field: SerializeField] public TValue Value;
    }
}