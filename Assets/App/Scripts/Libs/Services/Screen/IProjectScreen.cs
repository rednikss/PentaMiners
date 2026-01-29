
using UnityEngine;

namespace App.Scripts.Libs.Services.Screen
{
    public interface IProjectScreen
    {
        public Vector2 GetUnitSize();
        
        public Vector3 GetPositionByPercent(Vector2 screenPercent);

        public float GetAspect();
    }
}