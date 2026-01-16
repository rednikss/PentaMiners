using UnityEngine;

namespace App.Scripts.Game.Modules.Background
{
    public class BackgroundAdapter : IBackgroundAdapter
    {
        private readonly SpriteRenderer _backSprite;

        private readonly Transform _backTransform;

        private readonly Camera _camera;

        public BackgroundAdapter(SpriteRenderer backSprite, Transform backTransform, Camera camera)
        {
            _backSprite = backSprite;
            _backTransform = backTransform;
            _camera = camera;
        }

        public void SetSize(Vector2 size)
        {
            _backSprite.size = size;
            
            var pos = _camera.ScreenToWorldPoint(Vector3.zero);
            pos.z = _backTransform.position.z;
            _backTransform.position = pos;

            var scaleFactor = _camera.orthographicSize * 2 * _camera.aspect / size.x;
            _backTransform.localScale = Vector3.one * scaleFactor;
        }
    }
}