using App.Scripts.Libs.UI.Core.Panel.Animator;
using App.Scripts.Libs.UI.Core.Panel.View;
using App.Scripts.Libs.UI.Elements.Button;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.UI.Panels.Lose.View
{
    public class LosePanelView : PanelView<RawImage, RectTransform>
    {
        [field: SerializeField] public ActionButton restartButton;

        public new void Construct(IPanelAnimator<RawImage, RectTransform> animator)
        {
            base.Construct(animator);
        }
    }
}