using App.Scripts.Libs.UI.Core.View.Config;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Libs.UI.Core.View.Element.Base
{
    public abstract class ElementView : MonoBehaviour
    {
        [field: SerializeField] public TweenConfig ShowConfig;
        
        [field: SerializeField] public TweenConfig HideConfig;
        
        protected Tween ShowTween;

        protected Tween HideTween;

        public abstract void Construct();
        
        public async UniTask ShowAnimated()
        {
            Show();
            
            HideTween.Rewind();
            ShowTween.Restart();
            await ShowTween.AsyncWaitForCompletion().AsUniTask();
        }

        public async UniTask HideAnimated()
        {
            ShowTween.Rewind();
            HideTween.Restart();
            await HideTween.ToUniTask();
            
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