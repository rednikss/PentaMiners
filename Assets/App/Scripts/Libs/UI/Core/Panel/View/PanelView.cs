using App.Scripts.Libs.UI.Core.Panel.Animator;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Libs.UI.Core.Panel.View
{
    public abstract class PanelView : MonoBehaviour
    {
        protected Tween ShowTween;

        protected Tween HideTween;
        
        public async UniTask ShowAnimated()
        {
            Show();
            
            HideTween.Complete();
            ShowTween.Restart();
            
            await ShowTween.AsyncWaitForCompletion().AsUniTask();
        }

        public async UniTask HideAnimated()
        {
            ShowTween.Complete();
            HideTween.Restart();
            
            await HideTween.AsyncWaitForCompletion().AsUniTask();
            
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
    
    public class PanelView<T> : PanelView where T : Component
    {
        [SerializeField] private T _component;

        protected void Construct(IPanelAnimator<T> config)
        {
            ShowTween = config.GetShowTween(_component);
            HideTween = config.GetHideTween(_component);
        }
    }
    
    public class PanelView<T1, T2> : PanelView where T1 : Component where T2 : Component
    {
        [SerializeField] private T1 _firstComponent;

        [SerializeField] private T2 _secondComponent;

        protected void Construct(IPanelAnimator<T1, T2> config)
        {
            ShowTween = config.GetShowTween(_firstComponent, _secondComponent);
            HideTween = config.GetHideTween(_firstComponent, _secondComponent);
        }
    }
}