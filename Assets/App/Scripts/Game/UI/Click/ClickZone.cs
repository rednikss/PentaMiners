using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace App.Scripts.Game.UI.Click
{
    public class ClickZone : MonoBehaviour, IPointerClickHandler
    {
        public event Action<Vector2> OnClick;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke(eventData.position);
        }
    }
}