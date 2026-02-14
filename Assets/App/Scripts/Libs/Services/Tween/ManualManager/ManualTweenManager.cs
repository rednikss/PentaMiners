using DG.Tweening;

namespace App.Scripts.Libs.Services.Tween.ManualManager
{
    public class ManualTweenManager : ITweenManager
    {
        public void Tick(float deltaTime)
        {
            DOTween.ManualUpdate(deltaTime, 1f);
        }
    }
}