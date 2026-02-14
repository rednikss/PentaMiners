using App.Scripts.Libs.UI.Core.Panel.View.Config;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Libs.UI.Core.Panel.Animator.Scale
{
    public class ScalePanelAnimator : IPanelAnimator<Transform>
    {
        private readonly PanelViewConfig _config;

        public ScalePanelAnimator(PanelViewConfig config)
        {
            _config = config;
        }

        public Tween GetShowTween(Transform comp)
        {
            return comp.DOScale(1f, _config.Show.Duration)
                .SetEase(_config.Show.Ease)
                .SetUpdate(UpdateType.Normal)
                .SetLink(comp.gameObject);
        }

        public Tween GetHideTween(Transform comp)
        {
            var t = comp.DOScale(0f, _config.Hide.Duration)
                .SetEase(_config.Hide.Ease)
                .SetUpdate(UpdateType.Normal)
                .SetLink(comp.gameObject);
            
            t.timeScale = 1;
            return t;
        }
    }
}
