using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Libs.UI.Core.Panel.Animator
{
    public interface IPanelAnimator<in T> where T : Component
    {
        public Tween GetShowTween(T comp);
        
        public Tween GetHideTween(T comp);
    }
    
    public interface IPanelAnimator<in T1, in T2> where T1 : Component where T2 : Component
    {
        public Tween GetShowTween(T1 fComp, T2 sComp);
        
        public Tween GetHideTween(T1 fComp, T2 sComp);
    }
}