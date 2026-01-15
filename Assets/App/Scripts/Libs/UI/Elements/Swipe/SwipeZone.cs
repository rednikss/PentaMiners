using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace App.Scripts.Libs.UI.Elements.Swipe
{
    public class SwipeZone : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public event Action<Vector2> OnValueSet;
        
        private Camera _activeCamera;
        
        private float _minSwipeLength;
        
        private Vector2 _swipeStartPoint;
        
        private Vector2 _value;
        
        public void Construct(Camera activeCamera, float minSwipeLength)
        {
            _activeCamera = activeCamera;
            _minSwipeLength = minSwipeLength;
        }
        
        public Vector2 GetValue() => _value;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _swipeStartPoint = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _value = CalculateValue(_swipeStartPoint, eventData.position);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_value.magnitude >= _minSwipeLength)
            {
                OnValueSet?.Invoke(_value);
            }
            
            _value = Vector2.zero;
        }

        private Vector2 CalculateValue(Vector2 pixelStartPosition, Vector2 pixelEndPosition)
        {
            var posDelta = pixelStartPosition - pixelEndPosition;
            posDelta *= _activeCamera.orthographicSize * 2 / _activeCamera.pixelHeight;
            
            return posDelta;
        }
    }
}