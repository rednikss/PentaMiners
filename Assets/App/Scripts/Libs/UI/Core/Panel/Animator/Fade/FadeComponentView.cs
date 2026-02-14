using App.Scripts.Libs.UI.Core.Panel.View.Config;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Libs.UI.Core.Panel.Animator.Fade
{
    public class FadePanelAnimator : IPanelAnimator<CanvasGroup>
    {
        private readonly PanelViewConfig _config;

        public FadePanelAnimator(PanelViewConfig config)
        {
            _config = config;
        }

        public Tween GetShowTween(CanvasGroup comp)
        {
            return comp.DOFade(1f, _config.Show.Duration)
            .SetEase(_config.Show.Ease)
            .SetUpdate(UpdateType.Normal)
            .SetLink(comp.gameObject);
        }

        public Tween GetHideTween(CanvasGroup comp)
        {
            return comp.DOFade(0f, _config.Hide.Duration)
            .SetEase(_config.Hide.Ease)
            .SetUpdate(UpdateType.Normal)
            .SetLink(comp.gameObject);
        }
    }
}
