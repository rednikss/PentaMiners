using UnityEngine;

namespace App.Scripts.Libs.Services.Screen
{
    public class ProjectScreen : IProjectScreen
    {
        private readonly Camera _camera;
        
        private readonly Vector2 _unitSize;
        
        public Vector3 Position => _camera.transform.position;
        
        public ProjectScreen(Camera camera)
        {
            _camera = camera;

            _unitSize.y = _camera.orthographicSize * 2;
            _unitSize.x = _unitSize.y * _camera.aspect;
        }

        public Vector2 GetUnitSize() => _unitSize;
        
        public Vector2 GetPixelSize() =>_camera.pixelRect.size;

        public float GetAspect() => _camera.aspect;
        
        public Vector2 PixelToUnit(Vector2 pixel)
        {
            return pixel * GetUnitSize() / GetPixelSize();
        }

        public Vector3 GetPositionByPercent(Vector2 screenPercent)
        {
            screenPercent -= Vector2.one * 0.5f;
            Vector2 pos = Position;
            
            return pos + screenPercent * _unitSize;
        }

    }
}