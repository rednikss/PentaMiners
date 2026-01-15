using App.Scripts.Libs.UI.View.Element.Base;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Libs.UI.View.Element.Fade
{
    public class FadeElementView : ElementView
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        
        public void Construct()
        {
            ShowTween = _canvasGroup.DOFade(1f, ShowConfig.Duration)
                .SetEase(ShowConfig.Ease)
                .SetLink(_canvasGroup.gameObject);

            HideTween = _canvasGroup.DOFade(0f, HideConfig.Duration)
                .SetEase(HideConfig.Ease)
                .SetLink(_canvasGroup.gameObject);
        }
    }
}
