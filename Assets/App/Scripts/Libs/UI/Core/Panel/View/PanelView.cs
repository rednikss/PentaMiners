using App.Scripts.Libs.UI.Core.Panel.Animator;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Libs.UI.Core.Panel.View
{
    public class PanelView<T> : MonoBehaviour, IPanelView where T : Component
    {
        [SerializeField] private T _component;

        private Tween _showTween;

        private Tween _hideTween;

        protected void Construct(IPanelAnimator<T> config)
        {
            _showTween = config.GetShowTween(_component);
            _hideTween = config.GetHideTween(_component);
        }
        
        public async UniTask ShowAnimated()
        {
            Show();
            
            _hideTween.Complete();
            _showTween.Restart();
            
            await _showTween.AsyncWaitForCompletion().AsUniTask();
        }

        public async UniTask HideAnimated()
        {
            _showTween.Complete();
            _hideTween.Restart();
            
            await _hideTween.AsyncWaitForCompletion().AsUniTask();
            
            Hide();
        }

        public void Show()
        {
            transform.SetAsLastSibling();
            gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}