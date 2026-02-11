using UnityEngine;

namespace App.Scripts.Game.Level.Core.Grid.Data
{
    public interface IGridInfo
    {
        public void Init(Vector3 pos, float scale);
        
        public Vector2Int GetSize();
        
        public Vector3 IndexToWorldPos(int i, int j);
    }
}