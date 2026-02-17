using App.Scripts.Libs.UI.Core.Panel.Animator;
using App.Scripts.Libs.UI.Core.Panel.View;
using App.Scripts.Libs.UI.Elements.Button;
using UnityEngine;

namespace App.Scripts.UI.Panels.Pause.View
{
    public class PausePanelView : PanelView<RectTransform>
    {
        [field: SerializeField] public ActionButton resumeButton;
        
        [field: SerializeField] public ActionButton restartButton;
        
        public new void Construct(IPanelAnimator<RectTransform> animator)
        {
            base.Construct(animator);
        }
    }
}