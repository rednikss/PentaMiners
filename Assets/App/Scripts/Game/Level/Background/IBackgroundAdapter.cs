using UnityEngine;

namespace App.Scripts.Game.Level.Background
{
    public interface IBackgroundAdapter
    {
        public void SetGrid(Vector2 size, float scale);

        public void SetPosition(Vector3 bottomLeftPosition);
    }
}