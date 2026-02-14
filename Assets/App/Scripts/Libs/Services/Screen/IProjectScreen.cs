
using UnityEngine;

namespace App.Scripts.Libs.Services.Screen
{
    public interface IProjectScreen
    {
        public Vector2 GetUnitSize();
        
        public Vector2 GetPixelSize();
        
        public Vector2 PixelToUnit(Vector2 pixel);
        
        public Vector3 GetWorldByPercent(Vector2 screenPercent);

        public Vector3 GetPixelByPercent(Vector2 screenPercent);

    }
}