using UnityEngine;

namespace App.Scripts.Game.Modules.Background
{
    public class BackgroundAdapter : IBackgroundAdapter
    {
        private readonly SpriteRenderer _backSprite;

        private readonly Transform _backTransform;

        public BackgroundAdapter(SpriteRenderer backSprite, Transform backTransform)
        {
            _backSprite = backSprite;
            _backTransform = backTransform;
        }

        public void SetGridSize(Vector2 size)
        {
            _backSprite.size = size;
        }

        public void SetGridScale(float scale)
        {
            _backTransform.localScale = Vector3.one * scale;
        }

        public void SetPosition(Vector3 pos)
        {
            pos.z = _backTransform.position.z;
            _backTransform.position = pos;
        }
    }
}