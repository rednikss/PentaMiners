using UnityEngine;

namespace App.Scripts.Game.Modules.Background
{
    public interface IBackgroundAdapter
    {
        public void SetGridSize(Vector2 size);

        public void SetGridScale(float scale);

        public void SetPosition(Vector3 bottomLeftPosition);
    }
}