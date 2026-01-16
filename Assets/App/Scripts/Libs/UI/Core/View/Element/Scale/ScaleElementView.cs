using App.Scripts.Libs.UI.Core.View.Element.Base;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Libs.UI.Core.View.Element.Scale
{
    public class ScaleElementView : ElementView
    {
        [SerializeField] private Transform _transform;
        
        public override void Construct()
        {
            ShowTween = _transform.DOScale(1f, ShowConfig.Duration)
                .SetEase(ShowConfig.Ease)
                .SetLink(_transform.gameObject);

            HideTween = _transform.DOScale(0f, HideConfig.Duration)
                .SetEase(HideConfig.Ease)
                .SetLink(_transform.gameObject);
        }
    }
}
