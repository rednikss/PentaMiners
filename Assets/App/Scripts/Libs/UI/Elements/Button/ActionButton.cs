using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace App.Scripts.Libs.UI.Elements.Button
{
    public class ActionButton : Selectable, IPointerClickHandler, ISubmitHandler
    {
        public event Action OnClick;

        private void Press()
        {
            if (!IsActive() || !IsInteractable())
                return;

            OnClick?.Invoke();
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            Press();
        }

        public virtual void OnSubmit(BaseEventData eventData)
        {
            Press();

            if (!IsActive() || !IsInteractable()) return;

            DoStateTransition(SelectionState.Pressed, false);
            StartCoroutine(OnFinishSubmit());
        }

        private IEnumerator OnFinishSubmit()
        {
            var fadeTime = colors.fadeDuration;
            var elapsedTime = 0f;

            while (elapsedTime < fadeTime)
            {
                elapsedTime += Time.unscaledDeltaTime;
                yield return null;
            }

            DoStateTransition(currentSelectionState, false);
        }
    }
}