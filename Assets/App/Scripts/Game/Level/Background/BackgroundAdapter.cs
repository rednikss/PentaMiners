using UnityEngine;

namespace App.Scripts.Game.Level.Background
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

        public void Init(Vector2Int size, Vector3 pos, float scale)
        {
            _backSprite.size = size;
            SetPosition(pos);
            _backTransform.localScale = Vector3.one * scale;
        }

        private void SetPosition(Vector3 pos)
        {
            pos.z = _backTransform.position.z;
            _backTransform.position = pos;
        }
    }
}