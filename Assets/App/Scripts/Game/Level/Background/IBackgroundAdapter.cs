using UnityEngine;

namespace App.Scripts.Game.Level.Background
{
    public interface IBackgroundAdapter
    {
        public void Init(Vector2Int size, Vector3 pos, float scale);
    }
}