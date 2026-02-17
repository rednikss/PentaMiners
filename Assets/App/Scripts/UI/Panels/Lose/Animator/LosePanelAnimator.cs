using App.Scripts.Libs.Services.Screenshot;
using App.Scripts.Libs.UI.Core.Panel.Animator;
using App.Scripts.UI.Panels.Lose.Config;
using App.Scripts.UI.Panels.Lose.View;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.UI.Panels.Lose.Animator
{
    public class LosePanelAnimator : IPanelAnimator<RawImage, RectTransform>
    {
        private readonly LosePanelViewConfig _config;
        
        private readonly IScreenshotProvider _screenshotProvider;
        
        private readonly LosePanelView _view;

        public LosePanelAnimator(LosePanelViewConfig config, LosePanelView view, 
            IScreenshotProvider screenshotProvider)
        {
            _config = config;
            _screenshotProvider = screenshotProvider;
            _view = view;
        }

        public Tween GetShowTween(RawImage fComp, RectTransform sComp)
        {
            var t = DOTween.Sequence();
            t.Insert(0, sComp.DOScale(sComp.localScale, _config.Show.Duration).From(Vector3.one));
            
            var endValue = Vector3.forward * _config.Rotation;
            t.Insert(0, sComp.DORotate(endValue, _config.Show.Duration, RotateMode.LocalAxisAdd));

            t.PrependInterval(_config.preAnimationPauseTime)
                .OnPlay(() => SetScreenShot(fComp, sComp))
                .SetUpdate(UpdateType.Normal)
                .SetEase(_config.Show.Ease)
                .SetLink(sComp.gameObject);
            
            return t;
        }

        public Tween GetHideTween(RawImage fComp, RectTransform sComp)
        {
            return sComp.DOScale(Vector3.one, _config.Show.Duration)
            .SetEase(_config.Show.Ease)
            .SetUpdate(UpdateType.Normal)
            .SetLink(sComp.gameObject);
        }

        private async void SetScreenShot(RawImage image, RectTransform rectTransform)
        {
            _view.Hide();
            var texture = await _screenshotProvider.TakeScreenshot();
            image.texture = texture;
            
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;
            _view.Show();
        }
    }
}