using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Libs.UI.Core.Panel.Animator
{
    public interface IPanelAnimator<in T> where T : Component
    {
        public Tween GetShowTween(T comp);
        
        public Tween GetHideTween(T comp);
    }
}