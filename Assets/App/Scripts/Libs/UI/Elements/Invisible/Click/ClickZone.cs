using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace App.Scripts.Libs.UI.Elements.Invisible.Click
{
    public class ClickZone : Graphic, IPointerClickHandler
    {
        public event Action<Vector2> OnClick;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke(eventData.position);
        }
    }
}