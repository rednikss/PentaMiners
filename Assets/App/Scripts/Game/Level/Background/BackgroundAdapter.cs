using UnityEngine;

namespace App.Scripts.Game.Level.Background
{
    public class BackgroundAdapter : IBackgroundAdapter
    {
        private readonly SpriteRenderer _backSprite;

        private readonly Transform _backTransform;
        

        public BackgroundAdapter(SpriteRenderer backSprite, Transform backTransform, Vector3 position)
        {
            _backSprite = backSprite;
            _backTransform = backTransform;
            SetPosition(position);
        }

        public void SetGrid(Vector2 size, float scale)
        {
            _backSprite.size = size;
            _backTransform.localScale = Vector3.one * scale;
        }

        public void SetPosition(Vector3 pos)
        {
            pos.z = _backTransform.position.z;
            _backTransform.position = pos;
        }
    }
}