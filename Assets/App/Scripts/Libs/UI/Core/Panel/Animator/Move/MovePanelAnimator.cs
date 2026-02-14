using App.Scripts.Libs.Services.Screen;
using App.Scripts.Libs.UI.Core.Panel.View.Config;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Libs.UI.Core.Panel.Animator.Move
{
    public class MovePanelAnimator : IPanelAnimator<RectTransform>
    {
        private readonly PanelViewConfig _config;

        private readonly Vector3 _showPosition;
        
        private readonly Vector3 _hidePosition;
        
        public MovePanelAnimator(PanelViewConfig config, Vector2 direction, IProjectScreen screen)
        {
            _config = config;

            var posPercent = 0.5f * Vector2.one;
            _showPosition = screen.GetPixelByPercent(posPercent);
            _hidePosition = screen.GetPixelByPercent(posPercent - direction.normalized);
        }

        public Tween GetShowTween(RectTransform comp)
        {
            var t = comp.DOAnchorPos3D(_showPosition, _config.Show.Duration)
                .SetEase(_config.Show.Ease)
                .SetUpdate(UpdateType.Normal)
                .SetLink(comp.gameObject);
            
            t.timeScale = 1;
            return t;
        }

        public Tween GetHideTween(RectTransform comp)
        {
            return comp.DOAnchorPos3D(_hidePosition, _config.Hide.Duration)
                .SetEase(_config.Hide.Ease)
                .SetUpdate(UpdateType.Normal)
                .SetLink(comp.gameObject);
        }
    }
}