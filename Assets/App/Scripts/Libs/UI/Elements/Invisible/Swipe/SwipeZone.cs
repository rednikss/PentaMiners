using System;
using App.Scripts.Libs.Services.Screen;
using UnityEngine;
using UnityEngine.EventSystems;

namespace App.Scripts.Libs.UI.Elements.Invisible.Swipe
{
    public class SwipeZone : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private float _maxSwipeTime = 0.5f;
        
        [SerializeField] private float _minSwipeLength = 1f;
        
        private IProjectScreen _projectScreen;
        
        private Vector2 _swipeStartPoint;
        
        private float _swipeDuration;

        public event Action<Vector2> OnSwipe;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _swipeDuration = 0;
            _swipeStartPoint = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _swipeDuration += Time.deltaTime;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_swipeDuration > _maxSwipeTime) return;
            
            var vector = eventData.position - _swipeStartPoint; 
            vector = _projectScreen.PixelToUnit(vector);
            
            if (vector.sqrMagnitude < _minSwipeLength * _minSwipeLength) return;
            
            OnSwipe?.Invoke(vector);
        }

        public void Construct(IProjectScreen projectScreen)
        {
            _projectScreen = projectScreen;
        }
    }
}